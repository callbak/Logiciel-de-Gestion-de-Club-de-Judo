using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class feesForm_manageFees : Form
    {
        // db managment variables
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");


        // variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // athlete data
        private int AthleteSport;

        // Global Lists to store data
        private static List<(int subscriptionID, String subscriptionPaidFees)> SubscriptionsData = null;
        private static List<(string athleteName, int subscriptionID, String subscriptionPaidFees)> AthleteData = null;

        public feesForm_manageFees ()
        {
            InitializeComponent();

            // On form load, position elements 
            this.Load += new EventHandler(Form_position);
            // On form resize, position elements
            this.Resize += new EventHandler(Form_position);

            // On option change event handler
            this.sportMenu.SelectedIndexChanged += new EventHandler(Menu_Selection);

            // Add mouse event handlers
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
            this.MouseUp += new MouseEventHandler(Form_MouseUp);
        }

        private void feesForm_manageFees_Load (object sender, EventArgs e)
        {
            try
            {
                sportMenu.Items.Add("JUDO -- EQUIPE CNRS");
                sportMenu.Items.Add("JUDO -- SALLE DE SPORT DALLAS");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading this activity : " + ex.Message);
            }
        }

        private void Menu_Selection (object sender, EventArgs e)
        {
            int ix = sportMenu.SelectedIndex;
            switch (ix)
            {
                case 0:
                    {
                        AthleteSport = 1;
                        ClearDataAndDataGrid();
                        LoadSubscriptionsData(1);
                        break;
                    }
                case 1:
                    {
                        AthleteSport = 2;
                        ClearDataAndDataGrid();
                        LoadSubscriptionsData(2);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Select from the menu options.");
                        break;
                    }
            }
        }

        private async void LoadSubscriptionsData (int sport)
        {
            switch (sport)
            {
                case 1:
                    {
                        try
                        {
                            await LoadSubscriptionState(1);
                            await LoadAthlete();
                            DisplayFoundAthletes(1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error loading this activity : " + ex.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            await LoadSubscriptionState(2);
                            await LoadAthlete();
                            DisplayFoundAthletes(2);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error loading this activity : " + ex.Message);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Sport not found.");
                        break;
                    }
            }
        }

        // load athlete memberhsip state
        private async Task LoadSubscriptionState (int query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM subscription WHERE subscription_type=@st", conn))
                    {
                        if (query == 1)
                            cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = "JUDO -- EQUIPE CNRS";
                        else if (query == 2)
                            cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = "JUDO -- SALLE DE SPORT DALLAS";

                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune donnée trouvée concernant les abonnements expires");
                            }

                            SubscriptionsData = new List<(int subscriptionID, String subscriptionPaidFees)>();

                            while (await rdr.ReadAsync())
                            {
                                decimal paidFees = rdr.IsDBNull(rdr.GetOrdinal("price")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("price"));
                                
                                string paid_Fees = paidFees == Math.Floor(paidFees) ?
                                paidFees.ToString("0") :
                                paidFees.ToString("0.##");

                                SubscriptionsData.Add((Convert.ToInt32(rdr["subscription_id"]), paid_Fees));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the athlete subscription data : " + ex.Message);
                    return;
                }
            }
        }

        private async Task LoadAthlete ()
        {
            foreach (var (SubId, SubPaidFees) in SubscriptionsData)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        await conn.OpenAsync();

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete WHERE subscription_id=@subID", conn))
                        {
                            cmd.Parameters.Add("@subID", SqlDbType.Int).Value = SubId;

                            using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                            {
                                if (!rdr.HasRows)
                                {
                                    MessageBox.Show("Aucune données trouvées pour les athlètes");
                                    return;
                                }
                                if (IsListNullOrEmpty(AthleteData))
                                {
                                    AthleteData = new List<(string athleteName, int subscriptionID, String subscriptionPaidFees)>();
                                }
                                rdr.Read();
                                AthleteData.Add((rdr[1].ToString(), SubId, SubPaidFees));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading athlete data or subscription : " + ex.Message);
                    }
                }
            }
        }

        private void DisplayFoundAthletes (int query)
        {
            foreach (var (AthleteName, SubId, SubPaidFees) in AthleteData)
            {
                // add & get row
                int rowIndex = SubscriptionFeesDataGrid.Rows.Add(AthleteName, SubId, SubPaidFees);

                // get column of row
                DataGridViewCell subEndDate_cell = SubscriptionFeesDataGrid.Rows[rowIndex].Cells[2];

                // customized column based on fetched value
                subEndDate_cell.Style.ForeColor = Color.SeaGreen;

                Bitmap transparentImage = new Bitmap(50, 50);
                transparentImage.MakeTransparent();

                switch (query)
                {
                    case 1:
                        {
                            // green for fully paid, red for not fully paid
                            if (Convert.ToDecimal(SubPaidFees) < 10000)
                            {
                                subEndDate_cell.Style.ForeColor = Color.OrangeRed;                                         // Fees down CLUB FEES
                            }
                            // !! -> i've already handled this case, the manager can't exceed the top barrier for payment
                            else if (Convert.ToDecimal(SubPaidFees) == 10000)
                            {
                                subEndDate_cell.Style.ForeColor = Color.SeaGreen;                                          // Fees match CLUB FEES
                                DataGridViewCell action_cell = SubscriptionFeesDataGrid.Rows[rowIndex].Cells[3];
                                action_cell.Value = transparentImage;                                                      // Can't manage fees here in this case 
                            }   
                            break;
                        }

                    case 2:
                        {
                            // green for fully paid, red for not fully paid
                            if (Convert.ToDecimal(SubPaidFees) < 1500)
                            {
                                subEndDate_cell.Style.ForeColor = Color.OrangeRed;
                            }
                            // !! -> i've already handled this case, the manager can't exceed the top barrier for payment
                            else if (Convert.ToDecimal(SubPaidFees) == 1500)
                            {
                                subEndDate_cell.Style.ForeColor = Color.SeaGreen;
                                DataGridViewCell action_cell = SubscriptionFeesDataGrid.Rows[rowIndex].Cells[3];        
                                action_cell.Value = transparentImage;                                                     // Can't manage fees here in this case 
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Can't handle the display");
                            break;
                        }
                }
            }
        }

        private async void ExpiredSubscriptionDataGrid_CellContentClick (object sender, DataGridViewCellEventArgs e)
        {
            // get selected row columns
            string colName = SubscriptionFeesDataGrid.Columns[e.ColumnIndex].Name;

            // Select operation
            if (colName == "settle")
            {
                try
                {
                    using (subscriptionPaymentModuleForm form = new subscriptionPaymentModuleForm())
                    {
                        // Pass current data to the form
                        await form.LoadAthleteAndSubscriptionData(
                            SubscriptionFeesDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            Convert.ToInt32(SubscriptionFeesDataGrid.Rows[e.RowIndex].Cells[1].Value),
                            AthleteSport
                        );
                        form.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading athletes: " + ex.Message);
                }
            }

            // Load athletes after operations
            try
            {
                ClearDataAndDataGrid();
                LoadSubscriptionsData(AthleteSport);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading deleted athletes : " + ex.Message);
            }
        }

        private static bool IsListNullOrEmpty (List<(string athleteName, int subId, String subPf)> list)
        {
            return list == null || list.Count == 0;
        }

        private void ClearDataAndDataGrid ()
        {
            if (SubscriptionsData != null && AthleteData != null)
            {
                SubscriptionsData.Clear();
                AthleteData.Clear();
            }
            SubscriptionFeesDataGrid.Rows.Clear();
        }



        // Form and window control  -------------------------------------------------------------------------------------
        private void Form_position (object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls ()
        {
            header1.Location = new Point(((this.ClientSize.Width - header1.Width) / 2),50);

            SubscriptionFeesDataGrid.Height = (int)(this.ClientSize.Height * 0.65);
            SubscriptionFeesDataGrid.Width = (int)(this.ClientSize.Width * 0.95);
            SubscriptionFeesDataGrid.Location = new Point((this.ClientSize.Width - SubscriptionFeesDataGrid.Width) / 2, 190);

            search_panel.Location = new Point(SubscriptionFeesDataGrid.Location.X - 14, 90);
        }

        private void pictureBox5_Click_1 (object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click_1 (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1 (object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void pictureBox1_Click_1 (object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Mouse events  -------------------------------------------------------------------------------------
        // Mouse down event
        private void Form_MouseDown (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        // Mouse move event
        private void Form_MouseMove (object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the difference
                Point dif = new Point(Cursor.Position.X - dragCursorPoint.X, Cursor.Position.Y - dragCursorPoint.Y);
                // Update the form's location
                this.Location = new Point(dragFormPoint.X + dif.X, dragFormPoint.Y + dif.Y);
            }
        }

        // Mouse up event
        private void Form_MouseUp (object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

    }
}

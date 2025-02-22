using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class consultationForm_unpaidMemberships : Form
    {
        // db managment variables
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");


        // variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        // Global Lists to store data
        private static List<(int subscriptionID, decimal subscriptionPrice)> SubscriptionsData = null;
        private static List<(string athleteName, int subscriptionID, decimal subscriptionPrice)> AthleteData = null;


        public consultationForm_unpaidMemberships ()
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

        private void consultationForm_unpaidMemberships_Load (object sender, EventArgs e)
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
            switch (ix) {
                case 0:
                    {
                        ClearDataAndDataGrid();
                        LoadUnpaidSubscriptions(1);
                        break;
                    }
                case 1:
                    {
                        ClearDataAndDataGrid();
                        LoadUnpaidSubscriptions(2);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Select from the menu options.");
                        break;
                    }
            }
        }

        private async void LoadUnpaidSubscriptions (int sport)
        {
            switch (sport)
            {
                case 1:
                    {
                        try
                        {
                            await LoadSubscriptionState(1);
                            await LoadAthlete();
                            DisplayFoundAthletes();
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
                            DisplayFoundAthletes(); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error loading this activity : " + ex.Message);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("No sport.");
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
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM subscription WHERE subscription_type=@st AND (price=0 OR price<6000)", conn))
                    {
                        if (query == 1)
                            cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = "JUDO -- EQUIPE CNRS";
                        else if (query == 2)
                            cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = "JUDO -- SALLE DE SPORT DALLAS";

                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune donnée trouvée concernant son abonnement");
                            }
                            SubscriptionsData = new List<(int subscriptionID, decimal subscriptionPrice)>();
                            while (await rdr.ReadAsync())
                            {
                                if (Convert.ToDecimal(rdr["price"]) == 0)
                                {
                                    SubscriptionsData.Add((Convert.ToInt32(rdr["subscription_id"]), 6000));
                                }
                                else if (Convert.ToDecimal(rdr["price"]) < 6000)
                                {
                                    SubscriptionsData.Add((Convert.ToInt32(rdr["subscription_id"]), 6000 - Convert.ToDecimal(rdr["price"])));
                                }
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
            foreach (var (SubId, SubFees) in SubscriptionsData)
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
                                    AthleteData = new List<(string athleteName, int subscriptionID, decimal subscriptionPrice)>();
                                }
                                rdr.Read();
                                AthleteData.Add((rdr[1].ToString(),SubId,SubFees));
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

        private void DisplayFoundAthletes()
        {
            foreach (var (AthleteName, SubId, SubFees) in AthleteData)
            {         
                    // add & get row
                    int rowIndex = unpaidSubscriptionDataGrid.Rows.Add(AthleteName, SubId, SubFees);

                    // get column of row
                    DataGridViewCell subState_cell = unpaidSubscriptionDataGrid.Rows[rowIndex].Cells[2];

                // customized column based on fetched value
                    subState_cell.Value += " DA";
                    subState_cell.Style.ForeColor = Color.OrangeRed;
            }
        }

        private static bool IsListNullOrEmpty (List<(string athleteName, int subscriptionID, decimal subscriptionPrice)> list)
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
            unpaidSubscriptionDataGrid.Rows.Clear();
        }

        private void Form_position (object sender, EventArgs e)
        {
            CenterControls();
        }


        private void CenterControls ()
        {
            header1.Location = new Point(((this.ClientSize.Width - header1.Width) / 2), 50);

            unpaidSubscriptionDataGrid.Height = (int)(this.ClientSize.Height * 0.75);
            unpaidSubscriptionDataGrid.Width = (int)(this.ClientSize.Width * 0.95);
            unpaidSubscriptionDataGrid.Location = new Point((this.ClientSize.Width - unpaidSubscriptionDataGrid.Width) / 2, 190);

            search_panel.Location = new Point(unpaidSubscriptionDataGrid.Location.X - 14, 90);
        }

        private void pictureBox5_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click (object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void pictureBox1_Click (object sender, EventArgs e)
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

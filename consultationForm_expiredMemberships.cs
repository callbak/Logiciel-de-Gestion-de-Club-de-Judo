using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class consultationForm_expiredMemberships : Form
    {
        // db managment variables
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");


        // variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        // Global Lists to store data
        private static List<(int subscriptionID, DateTime subscriptionEndDate)> SubscriptionsData = null;
        private static List<(string athleteName, int subscriptionID, DateTime subscriptionEndDate)> AthleteData = null;

        public consultationForm_expiredMemberships ()
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

        private void consultationForm_expiredMemberships_Load (object sender, EventArgs e)
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
            ClearDataAndDataGrid();
            switch (ix)
            {
                case 0:
                    {
                        LoadExpiredSubscriptions(1);
                        break;
                    }
                case 1:
                    {
                        LoadExpiredSubscriptions(2);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Select from the menu options.");
                        break;
                    }
            }
        }

        private async void LoadExpiredSubscriptions (int sport)
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
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM subscription WHERE subscription_type=@st AND subscription_end_date<@cd", conn))
                    {
                        if (query == 1)
                            cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = "JUDO -- EQUIPE CNRS";
                        else if (query == 2)
                            cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = "JUDO -- SALLE DE SPORT DALLAS";

                        cmd.Parameters.Add("@cd", SqlDbType.DateTime).Value = DateTime.Now;

                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune donnée trouvée concernant les abonnements expires");
                            }
                            SubscriptionsData = new List<(int subscriptionID, DateTime subscriptionEnd)>();
                            DateTime endDate;
                            while (await rdr.ReadAsync())
                            {
                                if (!rdr.IsDBNull(rdr.GetOrdinal("subscription_end_date")))
                                {
                                    endDate = rdr.GetDateTime(rdr.GetOrdinal("subscription_end_date"));
                                }
                                else
                                {
                                    MessageBox.Show("End date is null. Setting to today's date.");
                                    endDate = DateTime.Now;
                                }

                                SubscriptionsData.Add((Convert.ToInt32(rdr["subscription_id"]), endDate));
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
            foreach (var (SubId, SubEndDate) in SubscriptionsData)
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
                                    AthleteData = new List<(string athleteName, int subscriptionID, DateTime subscriptionEndDate)>();
                                }
                                rdr.Read();
                                AthleteData.Add((rdr[1].ToString(), SubId, SubEndDate));
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

        private void DisplayFoundAthletes ()
        {
            foreach (var (AthleteName, SubId, SubEndDate) in AthleteData)
            {
                // add & get row
                int rowIndex = expiredSubscriptionDataGrid.Rows.Add(AthleteName, SubId, SubEndDate);

                // get column of row
                DataGridViewCell subEndDate_cell = expiredSubscriptionDataGrid.Rows[rowIndex].Cells[2];

                // customized column based on fetched value
                subEndDate_cell.Style.ForeColor = Color.Red;
            }
        }

        private static bool IsListNullOrEmpty (List<(string athleteName, int subscriptionID, DateTime subscriptionEndDate)> list)
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
            expiredSubscriptionDataGrid.Rows.Clear();
        }


        // Form and window control  -------------------------------------------------------------------------------------
        private void Form_position (object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls ()
        {
            header1.Location = new Point(((this.ClientSize.Width - header1.Width) / 2), 50);

            expiredSubscriptionDataGrid.Height = (int)(this.ClientSize.Height * 0.75);
            expiredSubscriptionDataGrid.Width = (int)(this.ClientSize.Width * 0.95);
            expiredSubscriptionDataGrid.Location = new Point((this.ClientSize.Width - expiredSubscriptionDataGrid.Width) / 2, 190);

            search_panel.Location = new Point(expiredSubscriptionDataGrid.Location.X - 14, 90);
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

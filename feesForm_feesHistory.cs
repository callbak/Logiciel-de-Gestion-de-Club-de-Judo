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
    public partial class feesForm_feesHistory : Form
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

        public feesForm_feesHistory ()
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

        private void feesForm_feesHistory_Load (object sender, EventArgs e)
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
                        LoadHistoric(1);
                        break;
                    }
                case 1:
                    {
                        AthleteSport = 2;
                        ClearDataAndDataGrid();
                        LoadHistoric(2);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Select from the menu options.");
                        break;
                    }
            }
        }

        private async void LoadHistoric (int sport)
        {
            switch (sport)
            {
                case 1:
                    {
                        try
                        {
                            await DisplayHistoricBasedOnSport(1);
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
                            await DisplayHistoricBasedOnSport(2);
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
        private async Task DisplayHistoricBasedOnSport (int query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM fees_regulations WHERE subscription_type=@st", conn))
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

                            while (await rdr.ReadAsync())
                            {
                                SubscriptionRegulationsDataGrid.Rows.Add(rdr[2], rdr[1], rdr[3], rdr[4]);
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

        private void ClearDataAndDataGrid ()
        {
            if (SubscriptionsData != null && AthleteData != null)
            {
                SubscriptionsData.Clear();
                AthleteData.Clear();
            }
            SubscriptionRegulationsDataGrid.Rows.Clear();
        }


        // Form and window control  -------------------------------------------------------------------------------------
        private void Form_position (object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls ()
        {
            header1.Location = new Point(((this.ClientSize.Width - header1.Width) / 2), 50);

            SubscriptionRegulationsDataGrid.Height = (int)(this.ClientSize.Height * 0.65);
            SubscriptionRegulationsDataGrid.Width = (int)(this.ClientSize.Width * 0.95);
            SubscriptionRegulationsDataGrid.Location = new Point((this.ClientSize.Width - SubscriptionRegulationsDataGrid.Width) / 2, 190);

            search_panel.Location = new Point(SubscriptionRegulationsDataGrid.Location.X - 14, 90);
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

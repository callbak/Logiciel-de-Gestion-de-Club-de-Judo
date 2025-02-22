using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class membershipfForm_renewMembership : Form
    {
        // db managment variables
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");


        // variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        // Text Event handling
        private CancellationTokenSource cts;

        // delay time
        const int delayTime = 300;


        public membershipfForm_renewMembership ()
        {
            InitializeComponent();

            // On form load, position elements 
            this.Load += new EventHandler(Form_position);
            // On form resize, position elements
            this.Resize += new EventHandler(Form_position);

            // Add mouse event handlers
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
            this.MouseUp += new MouseEventHandler(Form_MouseUp);
        }

        private void Form_position (object sender, EventArgs e)
        {
            CenterControls();
        }
        private void CenterControls ()
        {
            header1.Location = new Point(((this.ClientSize.Width - header1.Width) / 2), 70);

            search_panel.Location = new Point(30, 125);

            subscriptionsDataGrid.Height = (int)(this.ClientSize.Height * 0.65);
            subscriptionsDataGrid.Width = (int)(this.ClientSize.Width * 0.95);
            subscriptionsDataGrid.Location = new Point(44, 225);
        }

        private async void membershipfForm_renewMembership_Load (object sender, EventArgs e)
        {
            try
            {
                await LoadAthlete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subscription : " + ex.Message);
            }
        }
        private async void nameTextBox_TextChanged (object sender, EventArgs e)
        {
            cts?.Cancel(); // Cancel previous search if still running
            cts = new CancellationTokenSource();

            // Get text and verify
            string searchText = nameTextBox.Text;
            if (searchText == "")
            {
                await LoadAthlete(cts.Token);
                return;
            }

            try
            {                                                         // Call the search function asynchronously, using debouncing to avoid multiple rapid requests
                await Task.Delay(delayTime, cts.Token);               // 300 ms delay for debouncing
                if (!cts.Token.IsCancellationRequested)
                {
                    // fetch data by name
                    await FetchAthlete(searchText, cts.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // Task was cancelled, which is expected during rapid typing/deleting
            }
        }
        private async Task LoadAthlete ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    ClearGrid();
                    await conn.OpenAsync();

                    // List to hold athlete data ( name , subscription id )  
                    var athleteData = new List<(string athleteName, int subscriptionID, int SubscriptionState)>();

                    // Load athlete
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete", conn))
                    {
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune données trouvées pour les athlètes");
                                return;
                            }
                            while (await rdr.ReadAsync())
                            {
                                string athleteName = rdr[1].ToString();
                                int athleteSubId = Convert.ToInt32(rdr[6]);
                                int SubscriptionState = await LoadSubscriptionState(Convert.ToInt32(rdr["subscription_id"]));
                                athleteData.Add((athleteName, athleteSubId, SubscriptionState));
                            }
                        }
                    }

                    Bitmap transparentImage = new Bitmap(50, 50);
                    transparentImage.MakeTransparent();

                    // Load each athlete subscription 
                    foreach (var (Name, Id, SubState) in athleteData)
                    {
                        // add & get row
                        int rowIndex = subscriptionsDataGrid.Rows.Add(Name, Id, SubState);

                        // get column of row
                        DataGridViewCell subState_cell = subscriptionsDataGrid.Rows[rowIndex].Cells[2]; 

                        // customized column based on fetched value
                        if (SubState == 1)
                        {
                            subState_cell.Value = "ACTIF";
                            subState_cell.Style.ForeColor = Color.Green;
                            subscriptionsDataGrid.Rows[rowIndex].Cells[3].Value    = transparentImage;
                            subscriptionsDataGrid.Rows[rowIndex].Cells[3].ReadOnly = true;
                        }
                        else
                        {
                            subState_cell.Value = "NON ACTIF";
                            subState_cell.Style.ForeColor = Color.Red;
                            subscriptionsDataGrid.Rows[rowIndex].Cells[3].ReadOnly = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading athlete data or subscription : " + ex.Message);
                }
            }
        }
        private async Task FetchAthlete (String name, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    ClearGrid();
                    await conn.OpenAsync(cancellationToken);

                    // List to hold athlete data ( name , subscription id )  
                    var athleteData = new List<(string athleteName, int subscriptionID)>();

                    // Load athlete
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete WHERE name=@an", conn))
                    {
                        cmd.Parameters.AddWithValue("@an", name);
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr.HasRows)
                            {
                                ClearGrid();
                            }
                            while (await rdr.ReadAsync(cancellationToken))
                            {
                                string athleteName = rdr[1].ToString();
                                int athleteSubId = Convert.ToInt32(rdr[6]);
                                athleteData.Add((athleteName, athleteSubId));
                            }
                        }
                    }

                    // Load each athlete subscription 
                    foreach (var (Name, Id) in athleteData)
                    {
                        string subscriptionType = await LoadSubscription(conn, Id);
                        subscriptionsDataGrid.Rows.Add(Name, Id, subscriptionType);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading athlete data or subscription : " + ex.Message);
                }
            }
        }

        private async Task LoadAthlete (CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    ClearGrid();
                    await conn.OpenAsync(cancellationToken);

                    // List to hold athlete data ( name , subscription id )  
                    var athleteData = new List<(string athleteName, int subscriptionID)>();

                    // Load athlete
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete", conn))
                    {
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune données trouvées pour les athlètes");
                                return;
                            }
                            while (await rdr.ReadAsync(cancellationToken))
                            {
                                string athleteName = rdr[1].ToString();
                                int athleteSubId = Convert.ToInt32(rdr[6]);
                                athleteData.Add((athleteName, athleteSubId));
                            }
                        }
                    }

                    // Load each athlete subscription 
                    foreach (var (Name, Id) in athleteData)
                    {
                        string subscriptionType = await LoadSubscription(conn, Id);
                        subscriptionsDataGrid.Rows.Add(Name, Id, subscriptionType);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading athlete data or subscription : " + ex.Message);
                }
            }
        }
        private async Task<string> LoadSubscription (SqlConnection conn, int subscriptionId)
        {
            // Load subscription
            using (SqlCommand cmd_ = new SqlCommand("SELECT * FROM subscription WHERE subscription_id=@id", conn))
            {
                cmd_.Parameters.Add("@id", SqlDbType.Int).Value = subscriptionId;
                using (SqlDataReader rdr = await cmd_.ExecuteReaderAsync())
                {
                    if (!await rdr.ReadAsync())
                    {
                        MessageBox.Show("No data found for the athlete subscription.");
                        return null;
                    }
                    // Extract and select the type of subscription
                    if (!rdr.IsDBNull(rdr.GetOrdinal("subscription_type")))
                    {
                        return !rdr.IsDBNull(rdr.GetOrdinal("subscription_type")) ? rdr["subscription_type"].ToString() : null;
                    }
                }
            }
            return null;
        }

        // load athlete memberhsip state
        private async Task<int> LoadSubscriptionState (int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SELECT is_active FROM subscription WHERE subscription_id=@id", conn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (!rdr.Read())
                            {
                                MessageBox.Show("Aucune donnée trouvée concernant son l'abonnement");
                                return 0;
                            }
                            return Convert.ToInt32(rdr["is_active"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the athlete subscription data : " + ex.Message);
                    return 0;
                }
            }
        }

        private async void subscriptionsDataGrid_CellContentClick (object sender, DataGridViewCellEventArgs e)
        {
            // get selected row columns
            string colName = subscriptionsDataGrid.Columns[e.ColumnIndex].Name;

            // Select operation
            if (colName == "renew")
            {
                try
                {
                    using (subscriptionModuleForm form = new subscriptionModuleForm())
                    {
                        // Pass current data to the form
                        await form.LoadAthleteAndSubscriptionData(
                            subscriptionsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            Convert.ToInt32(subscriptionsDataGrid.Rows[e.RowIndex].Cells[1].Value) 
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
                await LoadAthlete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading deleted athletes : " + ex.Message);
            }
        }


        // clear athlete data grid
        private void ClearGrid ()
        {
            subscriptionsDataGrid.Rows.Clear();
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

        // window control  -------------------------------------------------------------------------------------
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

    }
}

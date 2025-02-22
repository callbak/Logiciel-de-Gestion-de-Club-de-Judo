using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class membersForm_modifyMember : Form
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

        public membersForm_modifyMember ()
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
            header1.Location = new Point(((this.ClientSize.Width - header1.Width) / 2), 50);

            search_panel.Location = new Point(30, 125);

            athleteDataGrid.Height = (int)(this.ClientSize.Height * 0.65);
            athleteDataGrid.Width = (int)(this.ClientSize.Width * 0.95);
            athleteDataGrid.Location = new Point(44, 225);
        }


        // data related operations  -------------------------------------------------------------------------------------
        // load athlete --default--
        private async void MembersForm_modifyMember_Load (object sender, EventArgs e)
        {
            try
            {
                await LoadAthlete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading athletes : " + ex.Message);
            }
        }

        private async Task LoadAthlete ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    athleteDataGrid.Rows.Clear();
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete", conn))
                    {
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune données trouvées pour les athlètes");
                                return;
                            }
                            int i = 0;
                            String birthdate = String.Empty;
                            while (await rdr.ReadAsync())
                            {
                                if (!rdr.IsDBNull(rdr.GetOrdinal("birth_date")))
                                {
                                    DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("birth_date"));
                                    birthdate = endDate.ToString("dd-MM-yyyy");
                                }
                                athleteDataGrid.Rows.Add(i++, rdr[1].ToString(), birthdate, rdr[3].ToString(), rdr[4].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the athlete data : " + ex.Message);
                }
            }
        }
        private async Task LoadAthlete (CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    athleteDataGrid.Rows.Clear();
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete", conn))
                    {
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune données trouvées pour les athlètes");
                                return;
                            }
                            int i = 0;
                            String birthdate = String.Empty;
                            while (await rdr.ReadAsync(cancellationToken))
                            {
                                if (!rdr.IsDBNull(rdr.GetOrdinal("birth_date")))
                                {
                                    DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("birth_date"));
                                    birthdate = endDate.ToString("dd-MM-yyyy");
                                }
                                athleteDataGrid.Rows.Add(i++, rdr[1].ToString(), birthdate, rdr[3].ToString(), rdr[4].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the athlete data : " + ex.Message);
                }
            }
        }

        // search athlete by entered data
        private async void nameTextBox_TextChanged_1 (object sender, EventArgs e)
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
                    await FetchAthleteData(searchText, cts.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // Task was cancelled, which is expected during rapid typing/deleting
            }
        }
        private async void birthDateTextBox_TextChanged (object sender, EventArgs e)
        {
            cts?.Cancel(); // Cancel previous search if still running
            cts = new CancellationTokenSource();

            // Get text and verify
            string searchText = birthDateTextBox.Text;
            if (searchText == "")
            {
                await LoadAthlete(cts.Token);
                return;
            }
            if (!int.TryParse(birthDateTextBox.Text, out int year))
            {
                MessageBox.Show("Please enter a valid date.");
                return;
            }

            try
            {
                await Task.Delay(delayTime, cts.Token);
                if (!cts.Token.IsCancellationRequested)
                {
                    // fetch data by birth year
                    await FetchAthleteData(year, cts.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // Task was cancelled, which is expected during rapid typing/deleting
            }
        }
        private async Task FetchAthleteData (string name, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete WHERE name=@an", conn))
                    {
                        cmd.Parameters.AddWithValue("@an", name);
                        using (SqlDataReader rdr_ = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr_.HasRows)
                            {
                                ClearGrid();
                            }
                            athleteDataGrid.Rows.Clear();
                            int i = 0;
                            String birthdate = String.Empty;
                            while (await rdr_.ReadAsync(cancellationToken))
                            {
                                if (!rdr_.IsDBNull(rdr_.GetOrdinal("birth_date")))
                                {
                                    DateTime endDate = rdr_.GetDateTime(rdr_.GetOrdinal("birth_date"));
                                    birthdate = endDate.ToString("dd-MM-yyyy");
                                }
                                athleteDataGrid.Rows.Add(i++, rdr_[1].ToString(), birthdate, rdr_[3].ToString(), rdr_[4].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the athlete data : " + ex.Message);
                }
            }
        }
        private async Task FetchAthleteData (int birthYear, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete WHERE YEAR(birth_date) = @abd", conn))
                    {
                        cmd.Parameters.AddWithValue("@abd", birthYear);
                        using (SqlDataReader rdr_ = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr_.HasRows)
                            {
                                ClearGrid();
                            }
                            athleteDataGrid.Rows.Clear();
                            int i = 0;
                            String birthdate = String.Empty;
                            while (await rdr_.ReadAsync(cancellationToken))
                            {
                                if (!rdr_.IsDBNull(rdr_.GetOrdinal("birth_date")))
                                {
                                    DateTime endDate = rdr_.GetDateTime(rdr_.GetOrdinal("birth_date"));
                                    birthdate = endDate.ToString("dd-MM-yyyy");
                                }
                                athleteDataGrid.Rows.Add(i++, rdr_[1].ToString(), birthdate, rdr_[3].ToString(), rdr_[4].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the athlete data : " + ex.Message);
                }
            }
        }
        private async void athleteDataGrid_CellContentClick (object sender, DataGridViewCellEventArgs e)
        {
            using (athleteModuleForm form = new athleteModuleForm())
            {
                // Pass current data to the form
                await form.LoadAthleteData(
                    athleteDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), // fullname
                    athleteDataGrid.Rows[e.RowIndex].Cells[4].Value.ToString()  // phone
                );
                form.ShowDialog();
            }
            try
            {
                await LoadAthlete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading athletes : " + ex.Message);
            }
        }

        // clear athlete data grid
        private void ClearGrid ()
        {
            athleteDataGrid.Rows.Clear();
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

    }
}

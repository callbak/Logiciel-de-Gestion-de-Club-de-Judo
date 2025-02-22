using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class membersForm_viewMember : Form
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

        // dictionary to hold the cached images
        private Dictionary<string, Image> ImageCache = new Dictionary<string, Image>();


        public membersForm_viewMember ()
        {
            InitializeComponent();

            // On form load, position elements 
            this.Load += new EventHandler(Form_position);
            // On form resize, position elements
            this.Resize += new EventHandler(Form_position);

            // text change event handlers
            nameTextBox.TextChanged += new EventHandler(nameTextBox_TextChanged);
            birthDateTextBox.TextChanged += new EventHandler(birthDateTextBox_TextChanged);

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
            athleteDataGrid.Width = (int)(this.ClientSize.Width * 0.65);
            athleteDataGrid.Location = new Point(44, 225);

            // Calculate 90% of the form's width for the X position
            int xPos = (int)(this.ClientSize.Width * 0.65);

            // Position the elements at 90% width and increment the Y position
            athleteInfo.Location = new Point(xPos + 115, 125);
            athletePicture.Location = new Point(xPos + 123, 205);
            fullName.Location = new Point(xPos + 116, 485);
            birthDate.Location = new Point(xPos + 116, 525);
            sexe.Location = new Point(xPos + 116, 565);
            phoneNumber.Location = new Point(xPos + 116, 605);
            membershipState.Location = new Point(xPos + 116, 645);
        }

        private async void membersForm_viewMember_Load (object sender, EventArgs e)
        {
            if (cts == null)
            {
                cts = new CancellationTokenSource();
            }
            try
            {
                await LoadAthlete(cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading athletes: " + ex.Message);
            }
        }

        private async void athleteDataGrid_CellClick (object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (e.RowIndex >= 0) // Ensure a row is selected
                {
                    DataGridViewRow row = athleteDataGrid.Rows[e.RowIndex];
                    if (row.Cells["aName"].Value != null)
                    {
                        await FetchAthleteData(row.Cells["aName"].Value.ToString(), row.Cells["phone_number"].Value.ToString(), Convert.ToDateTime(row.Cells["birth_Date"].Value), cts.Token);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the athlete data : " + ex.Message);
            }
            finally { Cursor = Cursors.Default; }
        }

        // data related operations              -------------------------------------------------------------------------------------
        // load athlete --default--
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
                            int i = 1;
                            DateTime birth_Date;
                            while (await rdr.ReadAsync(cancellationToken))
                            {
                                if (!rdr.IsDBNull(rdr.GetOrdinal("birth_date")))
                                {
                                    birth_Date = rdr.GetDateTime(rdr.GetOrdinal("birth_date"));
                                }
                                else
                                {
                                    MessageBox.Show("Birth date is null. Setting to today's date.");
                                    birth_Date = DateTime.Now;
                                }

                                athleteDataGrid.Rows.Add(i++, rdr[1].ToString(), birth_Date, rdr[3].ToString(), rdr[4].ToString());
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

        // load athlete data when ligne clicked
        private async Task FetchAthleteData (string name, string phone, DateTime birthdate, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete WHERE name=@an AND phone_number = @apn AND birth_date = @abd", conn))
                    {
                        cmd.Parameters.AddWithValue("@an", name);
                        cmd.Parameters.AddWithValue("@apn", phone);
                        cmd.Parameters.AddWithValue("@abd", birthdate);
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune donnée trouvée pour cet athlète");
                                ClearAthleteData();
                                return;
                            }
                            while (await rdr.ReadAsync(cancellationToken))
                            {          
                                // Load and display athlete image
                                string imagePath = rdr["image_path"].ToString();
                                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                                {
                                    athletePicture.Image = null;
                                }
                                else
                                {
                                    await DisplayAthleteImage(imagePath, cancellationToken);
                                }

                                // display the rest of athlete data
                                data_1.Text = rdr["name"].ToString();
                                if (!rdr.IsDBNull(rdr.GetOrdinal("birth_date")))
                                {
                                    DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("birth_date"));
                                    data_2.Text = endDate.ToString("dd-MM-yyyy");
                                }
                                data_3.Text = rdr["sexe"].ToString();
                                data_4.Text = rdr["phone_number"].ToString();

                                // Load and display athlete subscription state
                                int SubscriptionState = await LoadSubscriptionState(Convert.ToInt32(rdr["subscription_id"]), cancellationToken);

                                if (SubscriptionState == 1)
                                {
                                    data_5.Text = "ACTIF";
                                    data_5.ForeColor = Color.Green;
                                }
                                else
                                {
                                    data_5.Text = "NON ACTIF";
                                    data_5.ForeColor = Color.Red;
                                }
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
                            int i = 1;
                            DateTime birth_Date;
                            while (await rdr_.ReadAsync(cancellationToken))
                            {
                                if (!rdr_.IsDBNull(rdr_.GetOrdinal("birth_date")))
                                {
                                    birth_Date = rdr_.GetDateTime(rdr_.GetOrdinal("birth_date"));
                                }
                                else
                                {
                                    MessageBox.Show("Birth date is null. Setting to today's date.");
                                    birth_Date = DateTime.Now;
                                }

                                athleteDataGrid.Rows.Add(i++, rdr_[1].ToString(), birth_Date, rdr_[3].ToString(), rdr_[4].ToString());
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
                            int i = 1;
                            DateTime birth_Date;
                            while (await rdr_.ReadAsync(cancellationToken))
                            {
                                if (!rdr_.IsDBNull(rdr_.GetOrdinal("birth_date")))
                                {
                                    birth_Date = rdr_.GetDateTime(rdr_.GetOrdinal("birth_date"));
                                }
                                else
                                {
                                    MessageBox.Show("Birth date is null. Setting to today's date.");
                                    birth_Date = DateTime.Now;
                                }

                                athleteDataGrid.Rows.Add(i++, rdr_[1].ToString(), birth_Date, rdr_[3].ToString(), rdr_[4].ToString());
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


        // load athlete memberhsip state
        private async Task<int> LoadSubscriptionState (int id, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT is_active FROM subscription WHERE subscription_id=@id", conn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync(cancellationToken))
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


        // load athlete image
        private async Task DisplayAthleteImage (string imagePath, CancellationToken cancellationToken)
        {
            try
            {
                if (ImageCache.TryGetValue(imagePath, out Image cachedImage))
                {
                    athletePicture.Image = ResizeImage(cachedImage, athletePicture.Width, athletePicture.Height);
                }
                else
                {
                    Image img = await LoadImageAsync(imagePath, cancellationToken);
                    if (img != null)
                    {
                        // load image
                        athletePicture.Image = ResizeImage(img, athletePicture.Width, athletePicture.Height);      // resize image
                        ImageCache[imagePath] = img;                                                               // add to cache
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions during the image loading process
                MessageBox.Show("Error loading image: " + ex.Message);
                athletePicture.Image = null; // Clear the previous image on error
            }
        }
        private async Task<Image> LoadImageAsync (string imagePath, CancellationToken cancellationToken)
        {
            const int bufferSize = 4 * 1024 * 1024; // 4MB 

            try
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await fs.CopyToAsync(ms);      // Asynchronously copy file contents to memory stream
                        ms.Position = 0;               // Reset the memory stream position to the beginning
                        return Image.FromStream(ms);   // Load the image from the memory stream
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading image file: " + ex.Message);
                return null;
            }
        }
        public Image ResizeImage (Image image, int width, int height)
        {
            // Create a new bitmap with the desired size
            var resizedBitmap = new Bitmap(width, height);
            // Draw the original image onto the new bitmap, scaling it to fit
            using (var graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedBitmap;
        }

        // clear athlete data grid
        private void ClearGrid ()
        {
            athleteDataGrid.Rows.Clear();
        }
        private void ClearAthleteData ()
        {
            athletePicture.Image = null;
            data_1.Text = null;
            data_2.Text = null;
            data_3.Text = null;
            data_4.Text = null;
        }

        // window control              -------------------------------------------------------------------------------------
        private void pictureBox5_Click (object sender, EventArgs e)
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


        // Mouse events              -------------------------------------------------------------------------------------
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

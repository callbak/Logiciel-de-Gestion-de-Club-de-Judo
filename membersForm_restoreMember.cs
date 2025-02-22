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
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class membersForm_restoreMember : Form
    {
        // db managment variables
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");


        // variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // athlete credentials
        private int athleteSubId;

        // Athlete data
        private Subscription DeletedSubscribtionData;
        private Athlete DeletedAthleteData;


        // Text Event handling
        private CancellationTokenSource cts;

        // delay time
        const int delayTime = 300;


        public membersForm_restoreMember ()
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

            deletedAthleteDataGrid.Height = (int)(this.ClientSize.Height * 0.65);
            deletedAthleteDataGrid.Width = (int)(this.ClientSize.Width * 0.95);
            deletedAthleteDataGrid.Location = new Point(44, 225);
        }


        // data related operations  -------------------------------------------------------------------------------------
        // load athlete --default--
        private async void membersForm_restoreMember_Load (object sender, EventArgs e)
        {
            try
            {
                await LoadDeletedAthlete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading deleted athletes : " + ex.Message);
            }
        }


        private async Task LoadDeletedAthlete ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    deletedAthleteDataGrid.Rows.Clear();
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete_archive", conn))
                    {
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune données trouvées pour les athlètes");
                                return;
                            }
                            int i = 1;
                            while (await rdr.ReadAsync())
                            {
                                deletedAthleteDataGrid.Rows.Add(i++, rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString());
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

        private async Task LoadDeletedAthlete (CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    deletedAthleteDataGrid.Rows.Clear();
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete_archive", conn))
                    {
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("Aucune données trouvées pour les athlètes");
                                return;
                            }
                            int i = 1;
                            while (await rdr.ReadAsync(cancellationToken))
                            {
                                deletedAthleteDataGrid.Rows.Add(i++, rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString());
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

        private async void nameTextBox_TextChanged (object sender, EventArgs e)
        {
            cts?.Cancel(); // Cancel previous search if still running
            cts = new CancellationTokenSource();

            // Get text and verify
            string searchText = nameTextBox.Text;
            if (searchText == "")
            {
                await LoadDeletedAthlete(cts.Token);
                return;
            }

            try
            {                                                         // Call the search function asynchronously, using debouncing to avoid multiple rapid requests
                await Task.Delay(delayTime, cts.Token);               // 300 ms delay for debouncing
                if (!cts.Token.IsCancellationRequested)
                {
                    // fetch data by name
                    await FetchDeletedAthleteData(searchText, cts.Token);
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
                await LoadDeletedAthlete(cts.Token);
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
                    await FetchDeletedAthleteData(year, cts.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // Task was cancelled, which is expected during rapid typing/deleting
            }

        }

        private async Task FetchDeletedAthleteData (string name, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete_archive WHERE name=@an", conn))
                    {
                        cmd.Parameters.AddWithValue("@an", name);
                        using (SqlDataReader rdr_ = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr_.HasRows)
                            {
                                ClearGrid();
                            }
                            deletedAthleteDataGrid.Rows.Clear();
                            int i = 1;
                            while (await rdr_.ReadAsync(cancellationToken))
                            {
                                deletedAthleteDataGrid.Rows.Add(i++, rdr_[1].ToString(), rdr_[2].ToString(), rdr_[3].ToString(), rdr_[4].ToString());
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


        private async Task FetchDeletedAthleteData (int birthYear, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync(cancellationToken);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete_archive WHERE YEAR(birth_date) = @abd", conn))
                    {
                        cmd.Parameters.AddWithValue("@abd", birthYear);
                        using (SqlDataReader rdr_ = await cmd.ExecuteReaderAsync(cancellationToken))
                        {
                            if (!rdr_.HasRows)
                            {
                                ClearGrid();
                            }
                            deletedAthleteDataGrid.Rows.Clear();
                            int i = 1;
                            while (await rdr_.ReadAsync(cancellationToken))
                            {
                                deletedAthleteDataGrid.Rows.Add(i++, rdr_[1].ToString(), rdr_[2].ToString(), rdr_[3].ToString(), rdr_[4].ToString());
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
            // get selected row columns
            string colName = deletedAthleteDataGrid.Columns[e.ColumnIndex].Name;
            string name    = deletedAthleteDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            string phone   = deletedAthleteDataGrid.Rows[e.RowIndex].Cells[4].Value.ToString();

            // Load deleted data in subscription and athlete 
            await LoadDeletedAthleteAndSubscriptionData(name, phone);

            // Select operation
            if (colName == "restore")
            {
                if (MessageBox.Show("You sure about restoring the athlete ?", "Restore record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        await RestoreAthlete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading athletes: " + ex.Message);
                    }
                }
            }
            else if (colName == "delete")
            {
                if (MessageBox.Show("You sure about deleting the athlete completely ?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        await DeleteAthlete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading athletes: " + ex.Message);
                    }
                }
            }

            // Load athletes after operations
            try
            {
                await LoadDeletedAthlete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading deleted athletes : " + ex.Message);
            }
        }

        // data related operations  -------------------------------------------------------------------------------------
        public async Task LoadDeletedAthleteAndSubscriptionData (string name, string phone)
        {
            // GET athlete data
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();

                    // Fetch Deleted athlete and subscription data
                    // Set data within
                    await LoadDeletedAthleteData(name, phone, conn, transaction);
                    await LoadDeletedSubscriptionData(athleteSubId, conn, transaction);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Erreur lors du chargement des données de l'athlète : " + ex.Message);
                }
            }
        }

        private async Task LoadDeletedAthleteData (string name, string phone, SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete_archive WHERE name=@an AND phone_number=@pn", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@an", name);
                cmd.Parameters.AddWithValue("@pn", phone);
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    if (!rdr.HasRows)
                    {
                        MessageBox.Show("No data found for the athlete.");
                        return;
                    }
                    while (await rdr.ReadAsync())
                    {
                        // SET deleted athlete data
                        DeletedAthleteData = new Athlete(
                                    id: 0,
                                    name: rdr[1].ToString(),
                                    birthDate: rdr.GetDateTime(rdr.GetOrdinal("birth_date")),
                                    sexe: rdr[3].ToString(),
                                    phoneNumber: rdr[4].ToString(),
                                    imagepath: rdr[5].ToString(),
                                    subscription: DeletedSubscribtionData
                        );
                        athleteSubId = Convert.ToInt32(rdr[7]);
                    }
                }
            }
        }

        private async Task LoadDeletedSubscriptionData (int subscriptionId, SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM subscription_archive WHERE subscription_id=@id", conn, transaction))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = subscriptionId;
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    if (!await rdr.ReadAsync())
                    {
                        MessageBox.Show("No data found for the athlete subscription.");
                        return;
                    }
                    // SET deleted subscription data
                    DeletedSubscribtionData = new Subscription(
                      id: 0,
                      price: Convert.ToDecimal(rdr["price"]),
                      type: rdr["subscription_type"].ToString(),
                      startDate: rdr.GetDateTime(rdr.GetOrdinal("subscription_start_date")),
                      endDate: rdr.GetDateTime(rdr.GetOrdinal("subscription_end_date"))
                    );
                }
            }
        }

        private async Task RestoreAthlete ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    int newSubscriptionId;
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();

                    // Insert into subscription 
                    using (SqlCommand cmdArchiveSubscription = new SqlCommand(
                       "INSERT INTO subscription (price, subscription_type, subscription_start_date, subscription_end_date, is_active) " +
                       "OUTPUT INSERTED.subscription_id " +
                       "SELECT price, subscription_type, subscription_start_date, subscription_end_date, " +
                       "CASE WHEN subscription_end_date >= GETDATE() THEN 1 ELSE 0 END AS is_active " +                  // Calculate is_active based on end_date
                       "FROM subscription_archive " +
                       "WHERE subscription_id = @subId ", conn, transaction))
                    {
                        cmdArchiveSubscription.Parameters.Add("@subId", SqlDbType.Int).Value = athleteSubId;

                        newSubscriptionId = Convert.ToInt32(await cmdArchiveSubscription.ExecuteScalarAsync());
                    }

                    // Insert into athlete 
                    using (SqlCommand cmdArchiveAthlete = new SqlCommand(
                            "INSERT INTO athlete (name, birth_date, sexe, phone_number, image_path, subscription_id) " +
                            "SELECT name, birth_date, sexe, phone_number, image_path, @subId " +
                            "FROM athlete_archive WHERE " +
                            "name = @name AND phone_number = @phone ", conn, transaction))
                    {
                        cmdArchiveAthlete.Parameters.AddWithValue("@name",  DeletedAthleteData.Name);
                        cmdArchiveAthlete.Parameters.AddWithValue("@phone", DeletedAthleteData.PhoneNumber);
                        cmdArchiveAthlete.Parameters.AddWithValue("@subId", newSubscriptionId);
                        await cmdArchiveAthlete.ExecuteNonQueryAsync();
                    }

                    // Delete from subscription archive
                    using (SqlCommand cmdDeleteDeletedSubscription = new SqlCommand("DELETE FROM subscription_archive WHERE subscription_id = @id", conn, transaction))
                    {
                        cmdDeleteDeletedSubscription.Parameters.Add("@id", SqlDbType.Int).Value = athleteSubId;
                        await cmdDeleteDeletedSubscription.ExecuteNonQueryAsync();
                    }

                    // Delete from athlete archive
                    using (SqlCommand cmdDeleteDeletedAthlete = new SqlCommand("DELETE FROM athlete_archive WHERE name = @athletename AND phone_number = @athletephone", conn, transaction))
                    {
                        cmdDeleteDeletedAthlete.Parameters.AddWithValue("@athletename", DeletedAthleteData.Name);
                        cmdDeleteDeletedAthlete.Parameters.AddWithValue("@athletephone", DeletedAthleteData.PhoneNumber);

                        await cmdDeleteDeletedAthlete.ExecuteNonQueryAsync();
                    }


                    transaction.Commit();
                    MessageBox.Show("Athlete data restored successfully.");
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    MessageBox.Show("Error restoring athlete data or subscription : " + ex.Message);
                }
            }
        }

        private async Task DeleteAthlete ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();

                    // Delete from subscription archive
                    using (SqlCommand cmdDeleteDeletedSubscription = new SqlCommand("DELETE FROM subscription_archive WHERE subscription_id = @id", conn, transaction))
                    {
                        cmdDeleteDeletedSubscription.Parameters.Add("@id", SqlDbType.Int).Value = athleteSubId;
                        await cmdDeleteDeletedSubscription.ExecuteNonQueryAsync();
                    }

                    // Delete from athlete archive
                    using (SqlCommand cmdDeleteDeletedAthlete = new SqlCommand("DELETE FROM athlete_archive WHERE name = @athletename AND phone_number = @athletephone", conn, transaction))
                    {
                        cmdDeleteDeletedAthlete.Parameters.AddWithValue("@athletename", DeletedAthleteData.Name);
                        cmdDeleteDeletedAthlete.Parameters.AddWithValue("@athletephone", DeletedAthleteData.PhoneNumber);

                        await cmdDeleteDeletedAthlete.ExecuteNonQueryAsync();
                    }


                    transaction.Commit();
                    MessageBox.Show("Athlete data deleted permanentely.");
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    MessageBox.Show("Error permanentely deleting athlete data or subscription : " + ex.Message);
                }
            }
        }

        // clear athlete data grid
        private void ClearGrid ()
        {
            deletedAthleteDataGrid.Rows.Clear();
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


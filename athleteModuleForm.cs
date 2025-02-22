using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Club_manager
{
    public partial class athleteModuleForm : Form
    {
        // db managment variable
        private string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");

        // athlete credentials
        private int athleteSubId;
        private DateTime? BirthDate;
        
        // Text Event handling
        private CancellationTokenSource cts;

        public athleteModuleForm ()
        {
            InitializeComponent();
        }

        // data related operations  -------------------------------------------------------------------------------------
        public async Task LoadAthleteData (string name, string phone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    await LoadAthleteData(name, phone, conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des données de l'athlète : " + ex.Message);
                }
            }
        }

        private async Task LoadAthleteData (string name, string phone, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM athlete WHERE name=@an AND phone_number=@pn", conn))
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
                        this.name.Text = rdr[1].ToString();

                        if (!rdr.IsDBNull(rdr.GetOrdinal("birth_date")))
                        {
                            DateTime birthDate_ = rdr.GetDateTime(rdr.GetOrdinal("birth_date"));
                            birthDate.Text = birthDate_.ToString("dd-MM-yyyy");
                        }

                        // set and customize gender
                        gender.Items.Add("homme");
                        gender.Items.Add("femme");
                        gender.SelectedIndex = 0;

                        // Extract and select the gender
                        if (!rdr.IsDBNull(rdr.GetOrdinal("sexe")) && rdr.GetString(rdr.GetOrdinal("sexe")) != gender.SelectedItem.ToString())
                        {
                           gender.SelectedIndex = 1;
                        } 
                        
                        phoneNumber.Text = rdr[4].ToString();
                        imagePath.Text = rdr[5].ToString();

                        athleteSubId = Convert.ToInt32(rdr[6]);
                    }
                }
            }
        }

        // Form managment  -------------------------------------------------------------------------------------
        private async void updateBTN_Click (object sender, EventArgs e)
        {

            if (!ValidateAthleteData()) return;     // check athlete data
            BirthDate = ValidateAthleteBirthdate(); // check athlete birthdate
            if (BirthDate == null) return;

            // update athlete data
            if (MessageBox.Show("Etes-vous sûr de vouloir modifier les informations de cet athlète ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await UpdateAthleteData();
                this.Close();
            }
            else { this.Close(); }
        }


        private async void DeleteBTN_Click (object sender, EventArgs e)
        {
            if (!ValidateAthleteData()) return;     // check athlete data
            BirthDate = ValidateAthleteBirthdate(); // check athlete birthdate

            // delete member
            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer l'athlète ?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await DeleteAndRegisterAthleteAndSubscriptionData();
                this.Close();
            }
            else { this.Close(); }
        }

        private void clearBTN_Click (object sender, EventArgs e)
        {
            name.Clear();
            birthDate.Clear(); 
            gender.SelectedItem = null;
            phoneNumber.Clear();
            imagePath.Clear();
        }

        // Modify athlete data  -------------------------------------------------------------------------------------
        private async Task UpdateAthleteData ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                { 
                    await conn.OpenAsync();

                    if (athleteSubId <= 0)
                    {
                        MessageBox.Show("Invalid Subscription ID.");
                        return;
                    }

                    // personal data update
                    using (SqlCommand cmd = new SqlCommand("UPDATE athlete SET name=@name, birth_date=@birthdate, sexe=@gender, phone_number=@phone, image_path=@imgPath WHERE subscription_id=@athleteSubId", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", this.name.Text);
                        cmd.Parameters.AddWithValue("@birthdate", BirthDate);
                        cmd.Parameters.AddWithValue("@gender", this.gender.Text);
                        cmd.Parameters.AddWithValue("@phone", this.phoneNumber.Text);
                        cmd.Parameters.AddWithValue("@imgPath", this.imagePath.Text);
                        cmd.Parameters.AddWithValue("@athleteSubId", this.athleteSubId);

                        await cmd.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show("Les informations de l'athlète ont été modifiées avec succès.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Les informations de l'athlète n'ont pas été modifiées avec succès : " + ex.Message);
                }
            }
        }

        // Delete athlete data  -------------------------------------------------------------------------------------
        private async Task DeleteAndRegisterAthleteAndSubscriptionData ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    int newSubscriptionId;
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();

                    // Insert into subscription archive
                    using (SqlCommand cmdArchiveSubscription = new SqlCommand(
                       "INSERT INTO subscription_archive (price, subscription_type, subscription_start_date, subscription_end_date, is_active, deleted_at) " +
                       "OUTPUT INSERTED.subscription_id " +
                       "SELECT price, subscription_type, subscription_start_date, subscription_end_date, is_active, GETDATE() " +
                       "FROM subscription " +
                       "WHERE subscription_id = @subId ", conn, transaction))
                    {
                        cmdArchiveSubscription.Parameters.Add("@subId", SqlDbType.Int).Value = athleteSubId;

                        newSubscriptionId = Convert.ToInt32(await cmdArchiveSubscription.ExecuteScalarAsync());
                    }

                    // Insert into athlete archive
                    using (SqlCommand cmdArchiveAthlete = new SqlCommand(
                             "INSERT INTO athlete_archive (name, birth_date, sexe, phone_number, image_path, subscription_id, deleted_at) " +
                             "VALUES (@name, @birthDate, @sexe, @phone, @imagePath, @subscriptionId, GETDATE())", conn, transaction))
                    {
                        cmdArchiveAthlete.Parameters.AddWithValue("@name", this.name.Text);
                        cmdArchiveAthlete.Parameters.AddWithValue("@birthDate", this.BirthDate);
                        cmdArchiveAthlete.Parameters.AddWithValue("@sexe", this.gender.Text);
                        cmdArchiveAthlete.Parameters.AddWithValue("@phone", this.phoneNumber.Text);
                        cmdArchiveAthlete.Parameters.AddWithValue("@imagePath", this.imagePath.Text);
                        cmdArchiveAthlete.Parameters.AddWithValue("@subscriptionId", newSubscriptionId); // Use the newly inserted subscription id 

                        await cmdArchiveAthlete.ExecuteNonQueryAsync();
                    }

                    // Delete from subscription
                    using (SqlCommand cmdDeleteSubscription = new SqlCommand("DELETE FROM subscription WHERE subscription_id=@id", conn, transaction))
                    {
                        cmdDeleteSubscription.Parameters.Add("@id", SqlDbType.Int).Value = athleteSubId;

                        await cmdDeleteSubscription.ExecuteNonQueryAsync();
                    }

                    // Delete from athlete
                    using (SqlCommand cmdDeleteAthlete = new SqlCommand("DELETE FROM athlete WHERE name = @athletename AND phone_number = @athletephone", conn, transaction))
                    {
                        cmdDeleteAthlete.Parameters.AddWithValue("@athletename",  this.name.Text);
                        cmdDeleteAthlete.Parameters.AddWithValue("@athletephone", this.athleteSubId);

                        await cmdDeleteAthlete.ExecuteNonQueryAsync();
                    }

                    transaction.Commit();
                    MessageBox.Show("Athlete data deleted successfully.");
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    MessageBox.Show("Error Deleting athlete data or subscription : " + ex.Message);
                }
            }
        }

        private bool ValidateAthleteData ()
        {
            // Check for empty fields
            if (gender.SelectedItem == null || String.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("REMPLISSEZ TOUS LES CHAMPS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true; // All validations passed
        }

        private DateTime? ValidateAthleteBirthdate ()
        {
            DateTime BirthDate;

            // Try to parse the birth date
            if (! DateTime.TryParseExact(birthDate.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out BirthDate))
            {
                MessageBox.Show("FORMAT DE DATE DE NAISSANCE ERRONÉ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // Check if the birth date is in the future
            if (BirthDate > DateTime.Now)
            {
                MessageBox.Show("DATE DE NAISSANCE ERRONÉ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return BirthDate;
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Club_manager
{
    public partial class subscriptionModuleForm : Form
    {
        // db managment variable
        private string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");

        // athlete credentials
        private int athleteSubId;
        private decimal athleteSubFees;

        private Subscription SubscribtionData;


        public subscriptionModuleForm ()
        {
            InitializeComponent();
        }

        // data related operations  -------------------------------------------------------------------------------------
        public async Task LoadAthleteAndSubscriptionData (String name, int sub_id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    nom.Text   = name;
                    subID.Text = sub_id.ToString();

                    athleteSubId = sub_id;
                    await LoadSubscriptionData(athleteSubId, conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des données de l'abonnement l'athlète : " + ex.Message);
                }
            }
        }

        private async Task LoadSubscriptionData (int subscriptionId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM subscription WHERE subscription_id=@id", conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = subscriptionId;
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    if (!await rdr.ReadAsync())
                    {
                        MessageBox.Show("No data found for the athlete subscription.");
                        return;
                    }

                    // Extract subscription fees
                    athleteSubFees = Convert.ToDecimal(rdr["price"]);

                    decimal price = rdr.IsDBNull(rdr.GetOrdinal("price")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("price"));

                    subFees.Text = price == Math.Floor(price) ?
                        price.ToString("0") :
                        price.ToString("0.##");

                    // set and customize gender
                    sport.Items.Add("JUDO -- EQUIPE CNRS");
                    sport.Items.Add("JUDO -- SALLE DE SPORT DALLAS");
                    sport.SelectedIndex = 0;

                    // Extract and select the type of subscription
                    if (!rdr.IsDBNull(rdr.GetOrdinal("subscription_type")))
                    {
                        string subscriptionType = rdr.GetString(rdr.GetOrdinal("subscription_type"));
                        sport.SelectedItem = sport.Items.Cast<string>().FirstOrDefault(x => x.Contains(subscriptionType));
                    }


                    // Fetch and set dates
                    if (!rdr.IsDBNull(rdr.GetOrdinal("subscription_start_date")))
                    {
                        DateTime startDate = rdr.GetDateTime(rdr.GetOrdinal("subscription_start_date"));
                        dateDeDebut.Text = startDate.ToString("dd-MM-yyyy"); 
                    }
                    else
                    {
                        MessageBox.Show("Start date is null. Setting to today's date.");
                        dateDeDebut.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    }

                    if (!rdr.IsDBNull(rdr.GetOrdinal("subscription_end_date")))
                    {
                        DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("subscription_end_date"));
                        dateDeFin.Text = endDate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        MessageBox.Show("End date is null. Setting to today's date.");
                        dateDeFin.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    }
                }
            }
        }

        private async Task UpdateSubscriptionData ()
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

                    // subscription data update
                    using (SqlCommand cmd = new SqlCommand("UPDATE subscription SET price=@sf, subscription_type=@st, subscription_start_date=@std, subscription_end_date=@sed, is_active=@ia WHERE subscription_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id",  SqlDbType.Int).Value = athleteSubId;
                        cmd.Parameters.AddWithValue("@sf",  Convert.ToDecimal(this.subFees.Text));
                        cmd.Parameters.AddWithValue("@st",  this.sport.Text);


                        Boolean d1 = DateTime.TryParseExact(dateDeDebut.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime startDate);
                        Boolean d2 = DateTime.TryParseExact(dateDeFin.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime endDate);

                        if (!d1 || !d2)
                        {
                            MessageBox.Show("Date format is incorrect. Please use 'dd-MM-yyyy'.");
                            return;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@std", startDate);
                            cmd.Parameters.AddWithValue("@sed", endDate);
                            cmd.Parameters.AddWithValue("@ia",  endDate>= DateTime.Now ? 1 : 0);
                        }
                        await cmd.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show("Les informations de l'abonnement de l'athlète ont été modifiées avec succès.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Les informations de l'abonnement de l'athlète n'ont pas été modifiées avec succès : " + ex.Message);
                }
            }
        }

        // Form managment  -------------------------------------------------------------------------------------
        private async void updateBTN_Click (object sender, EventArgs e)
        {

            if (!ValidateSubscriptionData()) return;

            if (MessageBox.Show("Etes-vous sûr de vouloir modifier les informations de l'abonnement de cet athlète ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await UpdateSubscriptionData();
            }
            else { this.Close(); }
        }

        private void clearBTN_Click (object sender, EventArgs e)
        {
            nom.Clear();
            subID.Clear();
            sport.SelectedItem = null;
            dateDeDebut.Clear();
            dateDeFin.Clear();
        }

        private bool ValidateSubscriptionData ()
        {
            // Define the expected date format
            string dateFormat = "dd-MM-yyyy";

            // Check if the start date and end date are valid
            bool isStartDateValid = DateTime.TryParseExact(dateDeDebut.Text, dateFormat,
                                                           System.Globalization.CultureInfo.InvariantCulture,
                                                           System.Globalization.DateTimeStyles.None, out DateTime startDate);

            bool isEndDateValid = DateTime.TryParseExact(dateDeFin.Text, dateFormat,
                                                         System.Globalization.CultureInfo.InvariantCulture,
                                                         System.Globalization.DateTimeStyles.None, out DateTime endDate);

            if (!isStartDateValid)
            {
                MessageBox.Show("La date de début est incorrecte.'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!isEndDateValid)
            {
                MessageBox.Show("La date de fin est incorrecte.'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if start date is before end date
            if (startDate >= endDate)
            {
                MessageBox.Show("La date de fin doit être postérieure à la date de début.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /*private void setSubsctiptionDate ()
        {
            DateTime.TryParse(this.dateDeDebut.Text, out DateTime startDate);
            DateTime.TryParse(this.dateDeFin.Text, out DateTime   endDate);

            // Create the Athlete object
            SubscribtionData = new Subscription(
                id: ath,
                
            );
        }*/

    }
}

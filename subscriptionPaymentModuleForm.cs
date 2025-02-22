using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class subscriptionPaymentModuleForm : Form
    {
        // db managment variable
        private string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");

        // athlete credentials
        private int athleteSport;
        private string athlete_Sport;
        private string athlete_Name;
        private int athleteSubId;
        private decimal athleteSubFees;
        private decimal alp;

        public subscriptionPaymentModuleForm ()
        {
            InitializeComponent();

            // text change event handler
            this.paidFeesTb.TextChanged += new EventHandler(feesPaid_TextChanged);
        }

        // data related operations  -------------------------------------------------------------------------------------
        public async Task LoadAthleteAndSubscriptionData (String name, int sub_id, int sport)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    this.nameTb.Text  = name;
                    athlete_Name = name;
                    this.subIdTb.Text = sub_id.ToString();
                    this.athleteSport = sport;

                    if (this.athleteSport == 1) subFeesTb.Text = "10000 DA";
                    else if (this.athleteSport == 2) subFeesTb.Text = "1500 DA";

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

                    // Extract athlete subscription type
                    athlete_Sport  = Convert.ToString(rdr["subscription_type"]);

                    // Extract subscription fees
                    athleteSubFees = Convert.ToDecimal(rdr["price"]);

                    decimal price = rdr.IsDBNull(rdr.GetOrdinal("price")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("price"));

                    paidFeesTb.Text = price == Math.Floor(price) ?
                        price.ToString("0") :
                        price.ToString("0.##");

                    alp = price;

                    decimal fees = calculateFeesToBePaid(price);
                    DisplayRestFees(fees);
                }
            }
        }

        private async Task UpdateSubscriptionFeesData ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    // subscription data update
                    using (SqlCommand cmd = new SqlCommand("UPDATE subscription SET price=@sf WHERE subscription_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = athleteSubId;
                        cmd.Parameters.AddWithValue("@sf", Convert.ToDecimal(this.paidFeesTb.Text));

                        await cmd.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show("Les informations des frais de l'abonnement de l'athlète ont été modifiées avec succès.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Les informations des frais de l'abonnement de l'athlète n'ont pas été modifiées avec succès : " + ex.Message);
                }
            }
        }

        private async Task AddOperationToRecord ()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    // Record the operation
                    using (SqlCommand cmdArchiveOperation = new SqlCommand(
                             "INSERT INTO fees_regulations (athlete_name, subscription_type, price, payed_at) VALUES (@an, @as, @sf, GETDATE())", conn))
                    {
                        cmdArchiveOperation.Parameters.AddWithValue("@an", athlete_Name);
                        cmdArchiveOperation.Parameters.AddWithValue("@as", athlete_Sport);

                        decimal feesPayed = (Convert.ToDecimal(this.paidFeesTb.Text) > alp
                            ? Convert.ToDecimal(this.paidFeesTb.Text) - alp
                            : alp - Convert.ToDecimal(this.paidFeesTb.Text));

                        cmdArchiveOperation.Parameters.AddWithValue("@sf", feesPayed);

                        await cmdArchiveOperation.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show("Cette opération a été sauvegardée avec succès.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cette opération n'a pas été sauvegardée avec succès: " + ex.Message);
                }
            }
        }

        private void feesPaid_TextChanged (object sender, EventArgs e)
        {
            // Get text and verify
            string paidFees = this.paidFeesTb.Text;
            if (paidFees == "")
            {
                ClearFields();
                if (this.athleteSport == 1)      ftbpTb.Text = "10000 DA";
                else if (this.athleteSport == 2) ftbpTb.Text = "1500 DA";
                return;
            }

            // update remaining fees
            try
            {                                                         
                 decimal fees = calculateFeesToBePaid(Convert.ToDecimal(paidFees));
                 DisplayRestFees(fees);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot calculate and display fees data." + ex.Message);
                return;
            }
        }

        private decimal calculateFeesToBePaid (decimal fees)
        {
            if (athleteSport == 1)
            {
                return (10000 - fees);
            }
            else if (athleteSport == 2)
            {
                return (1500 - fees);
            }
            return 0;
        }

        private bool checkInvalidData ()
        {
            if (athleteSubId <= 0)
            {
                MessageBox.Show("Invalid Subscription ID.");
                return false;
            }
            switch (athleteSport)
            {
                case 1:
                    {
                        if(Convert.ToDecimal(paidFeesTb.Text) > 10000 || Convert.ToDecimal(paidFeesTb.Text) < 0)
                        {
                            MessageBox.Show("Invalid paid fees value. ( min : 0 DA , max : 10000 DA )");
                            return false;
                        }
                        break;
                    }
                case 2:
                    {
                        if (Convert.ToDecimal(paidFeesTb.Text) > 1500 || Convert.ToDecimal(paidFeesTb.Text) < 0)
                        {
                            MessageBox.Show("Invalid paid fees value. ( min : 0 DA , max : 1500 DA )");
                            return false;
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Invalid paid fees value. (can't determine subscription fees boundaries)");
                        return false;
                    }
            }
            return true;
        }


        // Form managment  -------------------------------------------------------------------------------------
        private async void updateBTN_Click_1 (object sender, EventArgs e)
        {
            if (!checkInvalidData()) return;

            if (MessageBox.Show("Etes-vous sûr de vouloir modifier les informations de l'abonnement de cet athlète ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await UpdateSubscriptionFeesData();
                await AddOperationToRecord();
            }
            else { this.Close(); }
        }

        private void clearBTN_Click_1 (object sender, EventArgs e)
        {
            paidFeesTb.Clear();
            ftbpTb.Clear();
        }

        private void DisplayRestFees (decimal fees)
        {
            this.ftbpTb.Text = fees == Math.Floor(fees) ?
                        fees.ToString("0") :
                        fees.ToString("0.##");
        }

        private void ClearFields ()
        {
            ftbpTb.Clear();
        }


    }
}

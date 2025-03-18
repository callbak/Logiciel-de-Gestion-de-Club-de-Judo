using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Club_manager
{
    public partial class membersForm_addMember : Form
    {
        // db managment variables
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");

        SqlCommand cmd = new SqlCommand();

        // variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Athlete Data
        Athlete NewAthlete;
        Subscription NewSubscription;
        private string image_path = "";

        public membersForm_addMember ()
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
            header1.Location = new Point(((this.ClientSize.Width - dataPanel.Width) / 2), 50);
            dataPanel.Location = new Point(((this.ClientSize.Width - dataPanel.Width) / 2), 225);

            addBTN.Location = new Point((int)(this.dataPanel.Location.X + 160), (int)(this.dataPanel.Location.Y + this.dataPanel.Height + 30));
            clearBTN.Location = new Point((int)(this.dataPanel.Location.X + 320), (int)(this.dataPanel.Location.Y + this.dataPanel.Height + 30));
            deleteBTN.Location = new Point((int)(this.dataPanel.Location.X + 480), (int)(this.dataPanel.Location.Y + this.dataPanel.Height + 30));
        }

        private void membersForm_addMember_Load (object sender, EventArgs e)
        {
            sport.Items.Add("JUDO -- EQUIPE CNRS");
            sport.Items.Add("JUDO -- SALLE DE SPORT DALLAS");
        }

        private async Task<bool> RegisterSub_and_Ath (Athlete athlete, Subscription subscription)
        {
            if (MessageBox.Show("Etes-vous sûr de vouloir inscrire cet athlète ?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlTransaction sqlTransaction = conn.BeginTransaction();

                    try
                    {
                        int? subscriptionId = null;

                        // Insert subscription
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [subscription] (price, subscription_type, subscription_start_date, subscription_end_date, is_active) VALUES(@sp, @st, @ssd, @sed, @sa); SELECT SCOPE_IDENTITY();", conn, sqlTransaction))
                        {
                            cmd.Parameters.AddWithValue("@sp", subscription.Price);
                            cmd.Parameters.AddWithValue("@st", subscription.SubscriptionType);
                            cmd.Parameters.AddWithValue("@ssd", subscription.SubscriptionStartDate);
                            cmd.Parameters.AddWithValue("@sed", subscription.SubscriptionEndDate);
                            cmd.Parameters.AddWithValue("@sa", subscription.IsActive);

                            var result = await cmd.ExecuteScalarAsync();
                            if (result != null)
                            {
                                subscriptionId = (int)(decimal)result; 
                            }
                            else
                            {
                                MessageBox.Show("Failed to retrieve the subscription ID.");
                                return false;
                            }
                        }

                        // Insert athlete
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [athlete] (name, birth_date, sexe, phone_number, image_path, subscription_id) VALUES(@an, @abd, @as, @apn, @aim, @asb)", conn, sqlTransaction))
                        {
                            cmd.Parameters.AddWithValue("@an", athlete.Name);
                            cmd.Parameters.AddWithValue("@abd", athlete.BirthDate);
                            cmd.Parameters.AddWithValue("@as", athlete.Sexe);
                            cmd.Parameters.AddWithValue("@apn", athlete.PhoneNumber);
                            cmd.Parameters.AddWithValue("@aim", athlete.ImagePath);
                            cmd.Parameters.AddWithValue("@asb", subscriptionId.Value); // Use Value since we know it's not null

                            await cmd.ExecuteNonQueryAsync();
                        }

                        sqlTransaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        MessageBox.Show("Error saving to the database: " + ex.Message);
                        return false;
                    }
                }
            }
            return false;
        }

        private string selectImage ()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Selectionner l'image de l'athlete";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null; // No image selected
        }

        private bool CheckFields ()
        {
            // Check if all fields are filled
            if (sport.SelectedItem == null ||
                String.IsNullOrWhiteSpace(nom.Text) || !dateDeNaissance.Checked || (!radioButton1.Checked && !radioButton2.Checked) ||
                 !dateDeDebut.Checked || !dateDeFin.Checked)
            {
                MessageBox.Show("REMPLISSEZ TOUS LES CHAMPS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool CheckData ()
        {
            // check the validty of the data being inserted
            if (dateDeNaissance.Value > DateTime.Now)
            {
                MessageBox.Show("DATE DE NAISSANCE ERRONÉ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateDeFin.Value <= dateDeDebut.Value)
            {
                MessageBox.Show("DATE DE FIN D'ABONNEMENT ERRONÉ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!String.IsNullOrWhiteSpace(montant.Text) && (!decimal.TryParse(montant.Text, out decimal price) || price < 0))
            {
                MessageBox.Show("MONTANT D'ABONNEMENT ERRONÉ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (sport.SelectedIndex==0  && (!decimal.TryParse(montant.Text, out decimal price_c1) || price_c1 >10000))
            {
                MessageBox.Show("MONTANT D'ABONNEMENT D'EQUIPE ERRONÉ (min: 0 DA , max : 10000 DA)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (sport.SelectedIndex == 1 &&  (!decimal.TryParse(montant.Text, out decimal price_c2) || price_c2 > 1500))
            {
                MessageBox.Show("MONTANT D'ABONNEMENT DE SALLE ERRONÉ (min: 0 DA , max: 1500 DA)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        // window control  --------------------------------------------------------------------------------
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
        private void addImage_Click (object sender, EventArgs e)
        {
            image_path = selectImage();
        }


        // Mouse events  --------------------------------------------------------------------------------
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


        // form managment buttons  --------------------------------------------------------------------------------
        private void clearBTN_Click (object sender, EventArgs e)
        {
            nom.Clear();
            dateDeNaissance.Value = DateTime.Now;
            num.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            sport.Text = string.Empty;
            dateDeDebut.Value = DateTime.Now;
            dateDeFin.Value = DateTime.Now;
            montant.Text = string.Empty;
        }
        private void deleteBTN_Click (object sender, EventArgs e)
        {
            Close();
        }
        private async void addBTN_Click (object sender, EventArgs e)
        {
            try
            {
                if (!CheckFields() || !CheckData()) { return; }

                if (!String.IsNullOrWhiteSpace(montant.Text))
                {
                    // Create subscription instance with the fees entered
                    NewSubscription = new Subscription(
                    id: 0,
                        price: Convert.ToDecimal(montant.Text),
                        type: sport.Text,
                        startDate: dateDeDebut.Value.Date,
                        endDate: dateDeFin.Value.Date
                    );
                }
                else
                {
                    // Create subscription instance with the fees equals to 0
                    NewSubscription = new Subscription(
                        id: 0,
                        price: 0,
                        type: sport.Text,
                        startDate: dateDeDebut.Value.Date,
                        endDate: dateDeFin.Value.Date
                    );
                }

                // Create athlete instance 
                NewAthlete = new Athlete(
                    id: 0,
                    name: nom.Text,
                    birthDate: dateDeNaissance.Value,
                    sexe: radioButton1.Checked ? "homme" : "femme",
                    phoneNumber: num.Text,
                    subscription: NewSubscription,
                    imagepath: image_path
                );

                // Registration in the database
                if (await RegisterSub_and_Ath(NewAthlete, NewSubscription))
                {
                    MessageBox.Show("l'athlète a été ajouté avec succès");
                    Close();
                }
                else
                {
                    MessageBox.Show("l'athlète n'a pas été ajouté avec succès");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

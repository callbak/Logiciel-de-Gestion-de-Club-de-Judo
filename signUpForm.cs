using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Club_manager
{
    public partial class signUpForm : MaterialForm
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");

        SqlCommand cmd = new SqlCommand();

        string usernamePattern = @"^[a-zA-Z]{1,10}[0-9_]*$";
        string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]:;""'<>,.?/~`-]).{8,}$";

        public signUpForm ()
        {
            InitializeComponent();
            // On form load, position elements 
            this.Load += new EventHandler(signUpForm_position);
            // On form resize, position elements
            this.Resize += new EventHandler(signUpForm_position);
        }

        private void signUpForm_position (object sender, EventArgs e)
        {
            CenterControls();
        }

        private void signUpForm_Load (object sender, EventArgs e)
        {
            optionMenu.Items.Add("Manager");
            optionMenu.Items.Add("Assistant");
        }

        private void CenterControls ()
        {
            // Horizontal position

            signUpLabel.Left = (this.ClientSize.Width - signUpLabel.Width) / 2;
            inputFields.Left = (this.ClientSize.Width - inputFields.Width) / 2;
            signUpBtn.Left = (this.ClientSize.Width - signUpBtn.Width) / 2;

            // Vertical position 
            //signUpLabel.Top = (this.ClientSize.Height - signUpLabel.Height) / 3;
            //inputFields.Top = (this.ClientSize.Height - inputFields.Height) / 2;
            //signUpBtn.Top   = (this.ClientSize.Height - signUpBtn.Height) / 3;
        }

        private async void signUpBtn_Click (object sender, EventArgs e)
        {
            try
            {
                await SignUp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur inattendue est survenue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SignUp ()
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir enregistrer cet utilisateur ?", "Enregistrement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validate input
                if (!CheckInput())
                {
                    return; // Exit if input is invalid
                }

                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // Check if the username already exists
                    using (SqlCommand Cmd = new SqlCommand("SELECT COUNT(*) FROM [user] WHERE username = @uUN", conn))
                    {
                        Cmd.Parameters.AddWithValue("@uUN", userName.Text);
                        await conn.OpenAsync();
                        int userExists = (int)await Cmd.ExecuteScalarAsync();

                        if (userExists > 0)
                        {
                            MessageBox.Show("Le nom d'utilisateur existe déjà. Veuillez choisir un nom d'utilisateur différent.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insert new user
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [user] (username, password, role) VALUES (@uUN, @uPS, @uRL)", conn))
                    {
                        cmd.Parameters.AddWithValue("@uUN", userName.Text);
                        cmd.Parameters.AddWithValue("@uPS", PasswordMaker.HashPassword(passWord1.Text));
                        cmd.Parameters.AddWithValue("@uRL", optionMenu.Text);

                        try
                        {
                            await cmd.ExecuteNonQueryAsync();
                            MessageBox.Show("Utilisateur enregistré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Une erreur est survenue lors de l'enregistrement de l'utilisateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool CheckInput ()
        {
            // Check if all input fields are filled
            if (String.IsNullOrWhiteSpace(optionMenu.Text) ||
                String.IsNullOrWhiteSpace(userName.Text) ||
                String.IsNullOrWhiteSpace(passWord1.Text) ||
                String.IsNullOrWhiteSpace(passWord2.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check the strength of the username
            if (!Regex.IsMatch(userName.Text, usernamePattern))
            {
                MessageBox.Show("Nom d'utilisateur incorrect", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check the strength of the password
            if (!Regex.IsMatch(passWord1.Text, passwordPattern))
            {
                MessageBox.Show("Le mot de passe ne répond pas aux critères requis", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if passwords match
            if (passWord1.Text != passWord2.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Club_manager
{
    public partial class restorePassword : MaterialForm
    {
        // database related objects
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");

        string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]:;""'<>,.?/~`-]).{8,}$";
        string originalPasswordHash;

        public restorePassword ()
        {
            InitializeComponent();
            // On form load, position elements 
            this.Load += new EventHandler(restorePForm_position);
            // On form resize, position elements
            this.Resize += new EventHandler(restorePForm_position);
        }

        private void restorePForm_position (object sender, EventArgs e)
        {
            CenterControls();
        }


        private void CenterControls ()
        {
            // Horizontal position
            label.Left = (this.ClientSize.Width - label.Width) / 2;
            dataPanel.Left = (this.ClientSize.Width - dataPanel.Width) / 2;

            // Vertical position 
            //dataPanel.Top = (this.ClientSize.Height - dataPanel.Height) / 2;
        }

        private async void updateBTN_Click (object sender, EventArgs e)
        {
            try
            {
                await RestorePassword();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur inattendue est survenue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RestorePassword ()
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
                    await conn.OpenAsync(); // Open the connection once

                    // Check if the username already exists
                    using (SqlCommand userCmd = new SqlCommand("SELECT COUNT(*) FROM [user] WHERE username = @uUN", conn))
                    {
                        userCmd.Parameters.AddWithValue("@uUN", usernameF.Text);
                        int userExists = (int)await userCmd.ExecuteScalarAsync();

                        if (userExists > 0)
                        {
                            // Check if the original password is correct
                            using (SqlCommand passwordCmd = new SqlCommand("SELECT password FROM [user] WHERE username = @uUN", conn))
                            {
                                passwordCmd.Parameters.AddWithValue("@uUN", usernameF.Text);
                                originalPasswordHash = (string)await passwordCmd.ExecuteScalarAsync();

                                if (!PasswordMaker.VerifyPassword(originalPassword.Text, originalPasswordHash))
                                {
                                    MessageBox.Show("Le ancien mot de passe est incorrect", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                // Check if old password is same as new one
                                if (PasswordMaker.VerifyPassword(password1N.Text, originalPasswordHash))
                                {
                                    MessageBox.Show("Le nouveau mot de passe est identique à l’ancien", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            // Modify the password of this user
                            using (SqlCommand cmd = new SqlCommand("UPDATE [user] SET password=@uPS WHERE username=@uUN", conn))
                            {
                                cmd.Parameters.AddWithValue("@uUN", usernameF.Text);
                                cmd.Parameters.AddWithValue("@uPS", PasswordMaker.HashPassword(password1N.Text));

                                try
                                {
                                    await cmd.ExecuteNonQueryAsync();
                                    MessageBox.Show("Nouveau mot de passe enregistré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Une erreur est survenue lors de la modification de mot de passe de l'utilisateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le nom d'utilisateur n'existe pas. Veuillez choisir un nom d'utilisateur différent.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
        }

        private bool CheckInput ()
        {
            // Check if all input fields are filled
            if (String.IsNullOrWhiteSpace(usernameF.Text) ||
                String.IsNullOrWhiteSpace(originalPassword.Text) ||
                String.IsNullOrWhiteSpace(password1N.Text) ||
                String.IsNullOrWhiteSpace(password1NC.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check the strength of the password
            if (!Regex.IsMatch(password1N.Text, passwordPattern))
            {
                MessageBox.Show("Le mot de passe ne répond pas aux critères requis", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if passwords match
            if (password1N.Text != password1NC.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void clearBTN_Click (object sender, EventArgs e)
        {
            usernameF.Clear();
            password1N.Clear();
            password1NC.Clear();
        }
    }
}

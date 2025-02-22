using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class loginForm : MaterialForm
    {
        // database related objects
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30");

        SqlCommand cmd = new SqlCommand();

        SqlDataReader reader = null;

        public loginForm ()
        {
            InitializeComponent();

            // On form load, position elements 
            this.Load += new EventHandler(loginForm_position);
            // On form resize, position elements
            this.Resize += new EventHandler(loginForm_position);
        }

        private void loginForm_position (object sender, EventArgs e)
        {
            CenterPictureBoxV();
            CenterButtonV();
            CenterLabelandTextBox();
        }

        private void CenterPictureBoxV ()
        {
            // Get the dimensions of the PictureBox and its container
            int pictureBoxWidth = judogi.Width; // Replace with actual width
            int containerWidth = this.ClientSize.Width;

            // Calculate the new position
            int newLeft = (containerWidth - pictureBoxWidth) / 2;

            // Set the new position
            judogi.Location = new Point(newLeft, 50);
        }

        private void CenterButtonV ()
        {
            // Get the dimensions of the button and form
            int buttonW = loginBTN.Width;
            int formW = this.ClientSize.Width;

            // Calculate the new position
            int newLeft = (formW - buttonW) / 2;

            // Set the new position
            loginBTN.Location = new Point(newLeft, 325);
        }

        private void CenterLabelandTextBox ()
        {
            // Get the dimensions of labels, text boxes, and form
            int usernameLabelW = usernameLabel.Width;
            int passwordLabelW = passwordLabel.Width;
            int usernameTextBoxW = username.Width;
            int passwordTextBoxW = password.Width;
            int loginButtonW = loginBTN.Width;
            int signUpLabelW = signUpLabel.Width;
            int restorePasswordW = passwordR.Width;
            int formW = this.ClientSize.Width;

            // Define vertical spacing
            int verticalSpacing = 15; // Adjust this value as needed
            int startY = 220; // Starting Y position for the first element

            // Calculate the new positions
            int newulLeft = (formW - usernameLabelW) / 2;
            int newutLeft = (formW - usernameTextBoxW) / 2;
            int newplLeft = (formW - passwordLabelW) / 2;
            int newptLeft = (formW - passwordTextBoxW) / 2;
            int newlbLeft = (formW - loginButtonW) / 2;
            int newsgLeft = (formW - signUpLabelW) / 2;
            int newrpLeft = (formW - restorePasswordW) / 2;

            // Set the new positions
            usernameLabel.Location = new Point(newulLeft, startY);
            username.Location = new Point(newutLeft, startY + usernameLabel.Height + verticalSpacing);
            passwordLabel.Location = new Point(newplLeft, startY + usernameLabel.Height + username.Height + 2 * verticalSpacing);
            password.Location = new Point(newptLeft, startY + usernameLabel.Height + username.Height + passwordLabel.Height + 3 * verticalSpacing);
            loginBTN.Location = new Point(newlbLeft, startY + usernameLabel.Height + username.Height + passwordLabel.Height + 4 * verticalSpacing + 15);
            signUpLabel.Location = new Point(newsgLeft, startY + usernameLabel.Height + username.Height + passwordLabel.Height + password.Height + 7 * verticalSpacing);
            passwordR.Location = new Point(newrpLeft, startY + usernameLabel.Height + username.Height + passwordLabel.Height + password.Height + signUpLabel.Height + 15/2 * verticalSpacing +4);
        }

        private async void loginBTN_Click (object sender, EventArgs e)
        {
            try
            {
                await LoginAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoginAsync ()
        {
            // Use a using statement to ensure the connection is closed properly
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1tite\Documents\mcDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                // SQL query to select both username and password from the database
                using (SqlCommand cmd = new SqlCommand("SELECT password, role FROM [user] WHERE username = @uUN", conn))
                {
                    cmd.Parameters.AddWithValue("@uUN", username.Text); // Avoid fetching all users; fetch only the entered username

                    try
                    {
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            // Check if the username exists and validate the password
                            if (reader.Read()) // If user exists
                            {
                                // reader[0] corresponds to the password column
                                if (PasswordMaker.VerifyPassword(password.Text, reader["password"].ToString()))
                                {
                                    // You can proceed to the next form or action here
                                    Form application_Form = new MainForm(username.Text, reader["role"].ToString());
                                    application_Form.WindowState = this.WindowState;
                                    application_Form.FormClosed += (s, args) =>
                                    {
                                        this.WindowState = application_Form.WindowState;
                                        this.Show();
                                    };
                                    this.Hide();
                                    application_Form.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log the error, show a message, etc.)
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void signUpLabel_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form signupForm = new signUpForm();
            signupForm.ShowDialog();
        }

        private void passwordR_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form restorePassword = new restorePassword();
            restorePassword.ShowDialog();
        }
    }
}

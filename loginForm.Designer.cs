namespace Club_manager
{
    partial class loginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginBTN = new MaterialSkin.Controls.MaterialButton();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.signUpLabel = new System.Windows.Forms.LinkLabel();
            this.judogi = new System.Windows.Forms.PictureBox();
            this.passwordR = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.judogi)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBTN
            // 
            this.loginBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginBTN.BackColor = System.Drawing.Color.Red;
            this.loginBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBTN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.loginBTN.Depth = 0;
            this.loginBTN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loginBTN.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBTN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginBTN.HighEmphasis = true;
            this.loginBTN.Icon = null;
            this.loginBTN.Location = new System.Drawing.Point(138, 428);
            this.loginBTN.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.loginBTN.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginBTN.Name = "loginBTN";
            this.loginBTN.NoAccentTextColor = System.Drawing.Color.Empty;
            this.loginBTN.Size = new System.Drawing.Size(64, 36);
            this.loginBTN.TabIndex = 2;
            this.loginBTN.Text = "Login";
            this.loginBTN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.loginBTN.UseAccentColor = false;
            this.loginBTN.UseVisualStyleBackColor = false;
            this.loginBTN.Click += new System.EventHandler(this.loginBTN_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(76, 327);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(196, 22);
            this.username.TabIndex = 3;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(76, 383);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(196, 22);
            this.password.TabIndex = 4;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.Black;
            this.usernameLabel.Location = new System.Drawing.Point(73, 306);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(120, 16);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "nom d\'utilisateur";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.Black;
            this.passwordLabel.Location = new System.Drawing.Point(73, 362);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(101, 16);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "mot de passe";
            // 
            // signUpLabel
            // 
            this.signUpLabel.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.BackColor = System.Drawing.Color.Transparent;
            this.signUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.signUpLabel.Location = new System.Drawing.Point(138, 482);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(77, 18);
            this.signUpLabel.TabIndex = 8;
            this.signUpLabel.TabStop = true;
            this.signUpLabel.Text = "s\'inscrire";
            this.signUpLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.signUpLabel_LinkClicked);
            // 
            // judogi
            // 
            this.judogi.Image = global::Club_manager.Properties.Resources.judogi;
            this.judogi.Location = new System.Drawing.Point(76, 65);
            this.judogi.Name = "judogi";
            this.judogi.Size = new System.Drawing.Size(196, 182);
            this.judogi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.judogi.TabIndex = 1;
            this.judogi.TabStop = false;
            // 
            // passwordR
            // 
            this.passwordR.AutoSize = true;
            this.passwordR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordR.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.passwordR.Location = new System.Drawing.Point(104, 508);
            this.passwordR.Name = "passwordR";
            this.passwordR.Size = new System.Drawing.Size(174, 18);
            this.passwordR.TabIndex = 9;
            this.passwordR.TabStop = true;
            this.passwordR.Text = "Mot de passe oublié ?";
            this.passwordR.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.passwordR_LinkClicked);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 553);
            this.Controls.Add(this.passwordR);
            this.Controls.Add(this.signUpLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.loginBTN);
            this.Controls.Add(this.judogi);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "loginForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                           Login";
            ((System.ComponentModel.ISupportInitialize)(this.judogi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox judogi;
        private MaterialSkin.Controls.MaterialButton loginBTN;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.LinkLabel signUpLabel;
        private System.Windows.Forms.LinkLabel passwordR;
    }
}


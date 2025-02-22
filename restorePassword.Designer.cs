namespace Club_manager
{
    partial class restorePassword
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
            this.updateBTN = new System.Windows.Forms.Button();
            this.clearBTN = new System.Windows.Forms.Button();
            this.password2 = new System.Windows.Forms.Label();
            this.password1NC = new System.Windows.Forms.TextBox();
            this.password1 = new System.Windows.Forms.Label();
            this.password1N = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.usernameF = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.originalPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateBTN
            // 
            this.updateBTN.BackColor = System.Drawing.Color.Lime;
            this.updateBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBTN.Location = new System.Drawing.Point(183, 159);
            this.updateBTN.Name = "updateBTN";
            this.updateBTN.Size = new System.Drawing.Size(94, 38);
            this.updateBTN.TabIndex = 25;
            this.updateBTN.Text = "Update";
            this.updateBTN.UseVisualStyleBackColor = false;
            this.updateBTN.Click += new System.EventHandler(this.updateBTN_Click);
            // 
            // clearBTN
            // 
            this.clearBTN.BackColor = System.Drawing.Color.Red;
            this.clearBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBTN.Location = new System.Drawing.Point(283, 159);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(94, 38);
            this.clearBTN.TabIndex = 24;
            this.clearBTN.Text = "Clear";
            this.clearBTN.UseVisualStyleBackColor = false;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // password2
            // 
            this.password2.AutoSize = true;
            this.password2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password2.Location = new System.Drawing.Point(16, 122);
            this.password2.Name = "password2";
            this.password2.Size = new System.Drawing.Size(156, 20);
            this.password2.TabIndex = 22;
            this.password2.Text = "Re-type Password :";
            // 
            // password1NC
            // 
            this.password1NC.Location = new System.Drawing.Point(194, 121);
            this.password1NC.Name = "password1NC";
            this.password1NC.Size = new System.Drawing.Size(304, 22);
            this.password1NC.TabIndex = 21;
            // 
            // password1
            // 
            this.password1.AutoSize = true;
            this.password1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password1.Location = new System.Drawing.Point(79, 87);
            this.password1.Name = "password1";
            this.password1.Size = new System.Drawing.Size(93, 20);
            this.password1.TabIndex = 20;
            this.password1.Text = "Password :";
            // 
            // password1N
            // 
            this.password1N.Location = new System.Drawing.Point(194, 86);
            this.password1N.Name = "password1N";
            this.password1N.Size = new System.Drawing.Size(304, 22);
            this.password1N.TabIndex = 19;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(76, 17);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(96, 20);
            this.username.TabIndex = 16;
            this.username.Text = "Username :";
            // 
            // usernameF
            // 
            this.usernameF.Location = new System.Drawing.Point(194, 16);
            this.usernameF.Name = "usernameF";
            this.usernameF.Size = new System.Drawing.Size(304, 22);
            this.usernameF.TabIndex = 15;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(322, 59);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(184, 25);
            this.label.TabIndex = 0;
            this.label.Text = "Restore password";
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.originalPassword);
            this.dataPanel.Controls.Add(this.label1);
            this.dataPanel.Controls.Add(this.username);
            this.dataPanel.Controls.Add(this.usernameF);
            this.dataPanel.Controls.Add(this.updateBTN);
            this.dataPanel.Controls.Add(this.clearBTN);
            this.dataPanel.Controls.Add(this.password1N);
            this.dataPanel.Controls.Add(this.password1);
            this.dataPanel.Controls.Add(this.password2);
            this.dataPanel.Controls.Add(this.password1NC);
            this.dataPanel.Location = new System.Drawing.Point(123, 137);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(565, 210);
            this.dataPanel.TabIndex = 28;
            // 
            // originalPassword
            // 
            this.originalPassword.Location = new System.Drawing.Point(194, 51);
            this.originalPassword.Name = "originalPassword";
            this.originalPassword.Size = new System.Drawing.Size(304, 22);
            this.originalPassword.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Original password :";
            // 
            // restorePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dataPanel);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "restorePassword";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "restorePassword";
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button updateBTN;
        public System.Windows.Forms.Button clearBTN;
        private System.Windows.Forms.Label password2;
        public System.Windows.Forms.TextBox password1NC;
        private System.Windows.Forms.Label password1;
        public System.Windows.Forms.TextBox password1N;
        private System.Windows.Forms.Label username;
        public System.Windows.Forms.TextBox usernameF;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel dataPanel;
        public System.Windows.Forms.TextBox originalPassword;
        private System.Windows.Forms.Label label1;
    }
}
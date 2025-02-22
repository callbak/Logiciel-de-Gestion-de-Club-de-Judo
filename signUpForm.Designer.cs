namespace Club_manager
{
    partial class signUpForm
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
            this.signUpBtn = new MaterialSkin.Controls.MaterialButton();
            this.userName = new System.Windows.Forms.TextBox();
            this.uLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passWord1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passWord2 = new System.Windows.Forms.TextBox();
            this.optionMenu = new System.Windows.Forms.ComboBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.signUpLabel = new System.Windows.Forms.Label();
            this.inputFields = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.inputFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // signUpBtn
            // 
            this.signUpBtn.AutoSize = false;
            this.signUpBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.signUpBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.signUpBtn.Depth = 0;
            this.signUpBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signUpBtn.HighEmphasis = true;
            this.signUpBtn.Icon = null;
            this.signUpBtn.Location = new System.Drawing.Point(343, 378);
            this.signUpBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.signUpBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.signUpBtn.Size = new System.Drawing.Size(110, 35);
            this.signUpBtn.TabIndex = 0;
            this.signUpBtn.Text = "s\'inscrire";
            this.signUpBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.signUpBtn.UseAccentColor = false;
            this.signUpBtn.UseVisualStyleBackColor = true;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(206, 61);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(254, 22);
            this.userName.TabIndex = 1;
            // 
            // uLabel
            // 
            this.uLabel.AutoSize = true;
            this.uLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uLabel.Location = new System.Drawing.Point(71, 65);
            this.uLabel.Name = "uLabel";
            this.uLabel.Size = new System.Drawing.Size(120, 16);
            this.uLabel.TabIndex = 2;
            this.uLabel.Text = "nom d\'utilisateur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot de passe";
            // 
            // passWord1
            // 
            this.passWord1.Location = new System.Drawing.Point(206, 114);
            this.passWord1.Name = "passWord1";
            this.passWord1.PasswordChar = '*';
            this.passWord1.Size = new System.Drawing.Size(254, 22);
            this.passWord1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirmer le mot de passe";
            // 
            // passWord2
            // 
            this.passWord2.Location = new System.Drawing.Point(206, 151);
            this.passWord2.Name = "passWord2";
            this.passWord2.PasswordChar = '*';
            this.passWord2.Size = new System.Drawing.Size(254, 22);
            this.passWord2.TabIndex = 5;
            // 
            // optionMenu
            // 
            this.optionMenu.FormattingEnabled = true;
            this.optionMenu.Location = new System.Drawing.Point(206, 21);
            this.optionMenu.Name = "optionMenu";
            this.optionMenu.Size = new System.Drawing.Size(121, 24);
            this.optionMenu.TabIndex = 7;
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleLabel.Location = new System.Drawing.Point(151, 27);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(40, 16);
            this.roleLabel.TabIndex = 8;
            this.roleLabel.Text = "Rôle";
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.Font = new System.Drawing.Font("Poppins SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLabel.Location = new System.Drawing.Point(334, 44);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(150, 50);
            this.signUpLabel.TabIndex = 10;
            this.signUpLabel.Text = "S\'inscrire";
            // 
            // inputFields
            // 
            this.inputFields.Controls.Add(this.materialLabel1);
            this.inputFields.Controls.Add(this.roleLabel);
            this.inputFields.Controls.Add(this.passWord1);
            this.inputFields.Controls.Add(this.passWord2);
            this.inputFields.Controls.Add(this.userName);
            this.inputFields.Controls.Add(this.label3);
            this.inputFields.Controls.Add(this.optionMenu);
            this.inputFields.Controls.Add(this.label2);
            this.inputFields.Controls.Add(this.uLabel);
            this.inputFields.Location = new System.Drawing.Point(75, 124);
            this.inputFields.Name = "inputFields";
            this.inputFields.Size = new System.Drawing.Size(663, 213);
            this.inputFields.TabIndex = 11;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Red;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Overline;
            this.materialLabel1.ForeColor = System.Drawing.Color.Red;
            this.materialLabel1.Location = new System.Drawing.Point(71, 87);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(588, 13);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = "* La longueur maximale du nom d\'utilisateur est de 10 caractères, et il ne peut c" +
    "ontenir que des lettres, des chiffres et des soulignements ";
            // 
            // signUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inputFields);
            this.Controls.Add(this.signUpLabel);
            this.Controls.Add(this.signUpBtn);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.KeyPreview = true;
            this.Name = "signUpForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signUpForm";
            this.Load += new System.EventHandler(this.signUpForm_Load);
            this.inputFields.ResumeLayout(false);
            this.inputFields.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton signUpBtn;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label uLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passWord1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passWord2;
        private System.Windows.Forms.ComboBox optionMenu;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.Label signUpLabel;
        private System.Windows.Forms.Panel inputFields;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
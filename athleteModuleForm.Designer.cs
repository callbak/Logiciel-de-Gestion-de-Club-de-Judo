namespace Club_manager
{
    partial class athleteModuleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            this.updateBTN = new System.Windows.Forms.Button();
            this.clearBTN = new System.Windows.Forms.Button();
            this.numLabel = new System.Windows.Forms.Label();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.sexeLabel = new System.Windows.Forms.Label();
            this.ddnLabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.nomLabel = new System.Windows.Forms.Label();
            this.imagepathLabel = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.deleteBTN = new System.Windows.Forms.Button();
            this.gender = new System.Windows.Forms.ComboBox();
            this.birthDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // updateBTN
            // 
            this.updateBTN.BackColor = System.Drawing.Color.Lime;
            this.updateBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBTN.Location = new System.Drawing.Point(115, 345);
            this.updateBTN.Name = "updateBTN";
            this.updateBTN.Size = new System.Drawing.Size(125, 50);
            this.updateBTN.TabIndex = 24;
            this.updateBTN.Text = "Mettre à jour";
            this.updateBTN.UseVisualStyleBackColor = false;
            this.updateBTN.Click += new System.EventHandler(this.updateBTN_Click);
            // 
            // clearBTN
            // 
            this.clearBTN.BackColor = System.Drawing.Color.Yellow;
            this.clearBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBTN.Location = new System.Drawing.Point(347, 345);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(125, 50);
            this.clearBTN.TabIndex = 23;
            this.clearBTN.Text = "Effacer";
            this.clearBTN.UseVisualStyleBackColor = false;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // numLabel
            // 
            this.numLabel.AutoSize = true;
            this.numLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLabel.Location = new System.Drawing.Point(109, 203);
            this.numLabel.Name = "numLabel";
            this.numLabel.Size = new System.Drawing.Size(196, 20);
            this.numLabel.TabIndex = 21;
            this.numLabel.Text = "numéro de téléphone :";
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(332, 202);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(310, 22);
            this.phoneNumber.TabIndex = 20;
            // 
            // sexeLabel
            // 
            this.sexeLabel.AutoSize = true;
            this.sexeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexeLabel.Location = new System.Drawing.Point(243, 150);
            this.sexeLabel.Name = "sexeLabel";
            this.sexeLabel.Size = new System.Drawing.Size(62, 20);
            this.sexeLabel.TabIndex = 19;
            this.sexeLabel.Text = "Sexe :";
            // 
            // ddnLabel
            // 
            this.ddnLabel.AutoSize = true;
            this.ddnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddnLabel.Location = new System.Drawing.Point(123, 97);
            this.ddnLabel.Name = "ddnLabel";
            this.ddnLabel.Size = new System.Drawing.Size(182, 20);
            this.ddnLabel.TabIndex = 17;
            this.ddnLabel.Text = "Date De naissance :";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(332, 44);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(310, 22);
            this.name.TabIndex = 14;
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomLabel.Location = new System.Drawing.Point(174, 45);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(131, 20);
            this.nomLabel.TabIndex = 15;
            this.nomLabel.Text = "Nom complet :";
            // 
            // imagepathLabel
            // 
            this.imagepathLabel.AutoSize = true;
            this.imagepathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagepathLabel.Location = new System.Drawing.Point(132, 255);
            this.imagepathLabel.Name = "imagepathLabel";
            this.imagepathLabel.Size = new System.Drawing.Size(173, 20);
            this.imagepathLabel.TabIndex = 56;
            this.imagepathLabel.Text = "chemin de l\'image :";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(332, 254);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(310, 22);
            this.imagePath.TabIndex = 55;
            // 
            // deleteBTN
            // 
            this.deleteBTN.BackColor = System.Drawing.Color.Red;
            this.deleteBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBTN.Location = new System.Drawing.Point(579, 345);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(125, 50);
            this.deleteBTN.TabIndex = 57;
            this.deleteBTN.Text = "Supprimer";
            this.deleteBTN.UseVisualStyleBackColor = false;
            this.deleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // gender
            // 
            this.gender.FormattingEnabled = true;
            this.gender.Location = new System.Drawing.Point(332, 148);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(310, 24);
            this.gender.TabIndex = 58;
            // 
            // birthDate
            // 
            this.birthDate.Location = new System.Drawing.Point(332, 97);
            this.birthDate.Name = "birthDate";
            this.birthDate.Size = new System.Drawing.Size(310, 22);
            this.birthDate.TabIndex = 59;
            // 
            // athleteModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.birthDate);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.deleteBTN);
            this.Controls.Add(this.imagepathLabel);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.updateBTN);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.numLabel);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.sexeLabel);
            this.Controls.Add(this.ddnLabel);
            this.Controls.Add(this.nomLabel);
            this.Controls.Add(this.name);
            this.Name = "athleteModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form d\'athlete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button updateBTN;
        public System.Windows.Forms.Button clearBTN;
        private System.Windows.Forms.Label numLabel;
        public System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.Label sexeLabel;
        private System.Windows.Forms.Label ddnLabel;
        public System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label imagepathLabel;
        public System.Windows.Forms.TextBox imagePath;
        public System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.ComboBox gender;
        public System.Windows.Forms.TextBox birthDate;
    }
}
namespace Club_manager
{
    partial class subscriptionModuleForm
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
            this.datefLabel = new System.Windows.Forms.Label();
            this.datedLabel = new System.Windows.Forms.Label();
            this.sport = new System.Windows.Forms.ComboBox();
            this.sportLabel = new System.Windows.Forms.Label();
            this.updateBTN = new System.Windows.Forms.Button();
            this.clearBTN = new System.Windows.Forms.Button();
            this.nomLabel = new System.Windows.Forms.Label();
            this.nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subFees = new System.Windows.Forms.TextBox();
            this.dateDeDebut = new System.Windows.Forms.TextBox();
            this.dateDeFin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // datefLabel
            // 
            this.datefLabel.AutoSize = true;
            this.datefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datefLabel.Location = new System.Drawing.Point(211, 274);
            this.datefLabel.Name = "datefLabel";
            this.datefLabel.Size = new System.Drawing.Size(114, 20);
            this.datefLabel.TabIndex = 72;
            this.datefLabel.Text = "Date de fin :";
            // 
            // datedLabel
            // 
            this.datedLabel.AutoSize = true;
            this.datedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datedLabel.Location = new System.Drawing.Point(168, 227);
            this.datedLabel.Name = "datedLabel";
            this.datedLabel.Size = new System.Drawing.Size(157, 20);
            this.datedLabel.TabIndex = 70;
            this.datedLabel.Text = "Date d\'adhésion :";
            // 
            // sport
            // 
            this.sport.FormattingEnabled = true;
            this.sport.Location = new System.Drawing.Point(376, 177);
            this.sport.Name = "sport";
            this.sport.Size = new System.Drawing.Size(310, 24);
            this.sport.TabIndex = 68;
            // 
            // sportLabel
            // 
            this.sportLabel.AutoSize = true;
            this.sportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sportLabel.Location = new System.Drawing.Point(259, 179);
            this.sportLabel.Name = "sportLabel";
            this.sportLabel.Size = new System.Drawing.Size(66, 20);
            this.sportLabel.TabIndex = 67;
            this.sportLabel.Text = "Sport :";
            // 
            // updateBTN
            // 
            this.updateBTN.BackColor = System.Drawing.Color.Lime;
            this.updateBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBTN.Location = new System.Drawing.Point(263, 338);
            this.updateBTN.Name = "updateBTN";
            this.updateBTN.Size = new System.Drawing.Size(125, 50);
            this.updateBTN.TabIndex = 66;
            this.updateBTN.Text = "Mettre à jour";
            this.updateBTN.UseVisualStyleBackColor = false;
            this.updateBTN.Click += new System.EventHandler(this.updateBTN_Click);
            // 
            // clearBTN
            // 
            this.clearBTN.BackColor = System.Drawing.Color.Yellow;
            this.clearBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBTN.Location = new System.Drawing.Point(479, 338);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(125, 50);
            this.clearBTN.TabIndex = 65;
            this.clearBTN.Text = "Effacer";
            this.clearBTN.UseVisualStyleBackColor = false;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomLabel.Location = new System.Drawing.Point(194, 37);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(131, 20);
            this.nomLabel.TabIndex = 60;
            this.nomLabel.Text = "Nom complet :";
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(376, 36);
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            this.nom.Size = new System.Drawing.Size(310, 22);
            this.nom.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 20);
            this.label1.TabIndex = 74;
            this.label1.Text = "ID de l\'abonnement :";
            // 
            // subID
            // 
            this.subID.Location = new System.Drawing.Point(376, 83);
            this.subID.Name = "subID";
            this.subID.ReadOnly = true;
            this.subID.Size = new System.Drawing.Size(310, 22);
            this.subID.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "frais :";
            // 
            // subFees
            // 
            this.subFees.Location = new System.Drawing.Point(376, 130);
            this.subFees.Name = "subFees";
            this.subFees.Size = new System.Drawing.Size(310, 22);
            this.subFees.TabIndex = 75;
            // 
            // dateDeDebut
            // 
            this.dateDeDebut.Location = new System.Drawing.Point(376, 227);
            this.dateDeDebut.Name = "dateDeDebut";
            this.dateDeDebut.Size = new System.Drawing.Size(310, 22);
            this.dateDeDebut.TabIndex = 77;
            // 
            // dateDeFin
            // 
            this.dateDeFin.Location = new System.Drawing.Point(376, 272);
            this.dateDeFin.Name = "dateDeFin";
            this.dateDeFin.Size = new System.Drawing.Size(310, 22);
            this.dateDeFin.TabIndex = 78;
            // 
            // subscriptionModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateDeFin);
            this.Controls.Add(this.dateDeDebut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subFees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subID);
            this.Controls.Add(this.datefLabel);
            this.Controls.Add(this.datedLabel);
            this.Controls.Add(this.sport);
            this.Controls.Add(this.sportLabel);
            this.Controls.Add(this.updateBTN);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.nomLabel);
            this.Controls.Add(this.nom);
            this.Name = "subscriptionModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form d\'abonnement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label datefLabel;
        private System.Windows.Forms.Label datedLabel;
        private System.Windows.Forms.ComboBox sport;
        private System.Windows.Forms.Label sportLabel;
        public System.Windows.Forms.Button updateBTN;
        public System.Windows.Forms.Button clearBTN;
        private System.Windows.Forms.Label nomLabel;
        public System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox subID;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox subFees;
        public System.Windows.Forms.TextBox dateDeDebut;
        public System.Windows.Forms.TextBox dateDeFin;
    }
}
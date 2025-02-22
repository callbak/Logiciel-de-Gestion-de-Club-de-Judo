namespace Club_manager
{
    partial class subscriptionPaymentModuleForm
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
            this.ftbpTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datedLabel = new System.Windows.Forms.Label();
            this.updateBTN = new System.Windows.Forms.Button();
            this.clearBTN = new System.Windows.Forms.Button();
            this.nomLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.paidFeesTb = new System.Windows.Forms.TextBox();
            this.subIdTb = new System.Windows.Forms.TextBox();
            this.subFeesTb = new System.Windows.Forms.TextBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ftbpTb
            // 
            this.ftbpTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ftbpTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ftbpTb.Location = new System.Drawing.Point(376, 224);
            this.ftbpTb.Multiline = true;
            this.ftbpTb.Name = "ftbpTb";
            this.ftbpTb.ReadOnly = true;
            this.ftbpTb.Size = new System.Drawing.Size(310, 21);
            this.ftbpTb.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 90;
            this.label2.Text = "Frais réglés :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "ID de l\'abonnement :";
            // 
            // datedLabel
            // 
            this.datedLabel.AutoSize = true;
            this.datedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datedLabel.Location = new System.Drawing.Point(171, 224);
            this.datedLabel.Name = "datedLabel";
            this.datedLabel.Size = new System.Drawing.Size(154, 20);
            this.datedLabel.TabIndex = 85;
            this.datedLabel.Text = "Frais en attente :";
            // 
            // updateBTN
            // 
            this.updateBTN.BackColor = System.Drawing.Color.Lime;
            this.updateBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBTN.Location = new System.Drawing.Point(263, 338);
            this.updateBTN.Name = "updateBTN";
            this.updateBTN.Size = new System.Drawing.Size(125, 50);
            this.updateBTN.TabIndex = 82;
            this.updateBTN.Text = "Mettre à jour";
            this.updateBTN.UseVisualStyleBackColor = false;
            this.updateBTN.Click += new System.EventHandler(this.updateBTN_Click_1);
            // 
            // clearBTN
            // 
            this.clearBTN.BackColor = System.Drawing.Color.Yellow;
            this.clearBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBTN.Location = new System.Drawing.Point(479, 338);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(125, 50);
            this.clearBTN.TabIndex = 81;
            this.clearBTN.Text = "Effacer";
            this.clearBTN.UseVisualStyleBackColor = false;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click_1);
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomLabel.Location = new System.Drawing.Point(194, 40);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(131, 20);
            this.nomLabel.TabIndex = 80;
            this.nomLabel.Text = "Nom complet :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 20);
            this.label3.TabIndex = 93;
            this.label3.Text = "Frais d\'abonnement :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paidFeesTb
            // 
            this.paidFeesTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.paidFeesTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidFeesTb.Location = new System.Drawing.Point(376, 178);
            this.paidFeesTb.Multiline = true;
            this.paidFeesTb.Name = "paidFeesTb";
            this.paidFeesTb.Size = new System.Drawing.Size(310, 21);
            this.paidFeesTb.TabIndex = 94;
            // 
            // subIdTb
            // 
            this.subIdTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subIdTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subIdTb.Location = new System.Drawing.Point(376, 86);
            this.subIdTb.Multiline = true;
            this.subIdTb.Name = "subIdTb";
            this.subIdTb.ReadOnly = true;
            this.subIdTb.Size = new System.Drawing.Size(310, 21);
            this.subIdTb.TabIndex = 96;
            // 
            // subFeesTb
            // 
            this.subFeesTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subFeesTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subFeesTb.Location = new System.Drawing.Point(376, 132);
            this.subFeesTb.Multiline = true;
            this.subFeesTb.Name = "subFeesTb";
            this.subFeesTb.ReadOnly = true;
            this.subFeesTb.Size = new System.Drawing.Size(310, 21);
            this.subFeesTb.TabIndex = 95;
            // 
            // nameTb
            // 
            this.nameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTb.Location = new System.Drawing.Point(376, 40);
            this.nameTb.Multiline = true;
            this.nameTb.Name = "nameTb";
            this.nameTb.ReadOnly = true;
            this.nameTb.Size = new System.Drawing.Size(310, 21);
            this.nameTb.TabIndex = 97;
            // 
            // subscriptionPaymentModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.subIdTb);
            this.Controls.Add(this.subFeesTb);
            this.Controls.Add(this.paidFeesTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ftbpTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datedLabel);
            this.Controls.Add(this.updateBTN);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.nomLabel);
            this.Name = "subscriptionPaymentModuleForm";
            this.Text = "Form de paiment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox ftbpTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label datedLabel;
        public System.Windows.Forms.Button updateBTN;
        public System.Windows.Forms.Button clearBTN;
        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox paidFeesTb;
        public System.Windows.Forms.TextBox subIdTb;
        public System.Windows.Forms.TextBox subFeesTb;
        public System.Windows.Forms.TextBox nameTb;
    }
}
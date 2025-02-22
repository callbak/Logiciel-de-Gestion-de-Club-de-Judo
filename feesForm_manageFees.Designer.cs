namespace Club_manager
{
    partial class feesForm_manageFees
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SubscriptionFeesDataGrid = new System.Windows.Forms.DataGridView();
            this.search_panel = new System.Windows.Forms.Panel();
            this.sportMenu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settle = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SubscriptionFeesDataGrid)).BeginInit();
            this.search_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SubscriptionFeesDataGrid
            // 
            this.SubscriptionFeesDataGrid.AllowUserToAddRows = false;
            this.SubscriptionFeesDataGrid.AllowUserToDeleteRows = false;
            this.SubscriptionFeesDataGrid.AllowUserToResizeColumns = false;
            this.SubscriptionFeesDataGrid.AllowUserToResizeRows = false;
            this.SubscriptionFeesDataGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubscriptionFeesDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.SubscriptionFeesDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.SubscriptionFeesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SubscriptionFeesDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.SubscriptionFeesDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SubscriptionFeesDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SubscriptionFeesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubscriptionFeesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aName,
            this.subID,
            this.subFees,
            this.settle});
            this.SubscriptionFeesDataGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.SubscriptionFeesDataGrid.Location = new System.Drawing.Point(59, 325);
            this.SubscriptionFeesDataGrid.MultiSelect = false;
            this.SubscriptionFeesDataGrid.Name = "SubscriptionFeesDataGrid";
            this.SubscriptionFeesDataGrid.ReadOnly = true;
            this.SubscriptionFeesDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SubscriptionFeesDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.SubscriptionFeesDataGrid.RowHeadersWidth = 40;
            this.SubscriptionFeesDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SubscriptionFeesDataGrid.RowTemplate.Height = 24;
            this.SubscriptionFeesDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SubscriptionFeesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SubscriptionFeesDataGrid.Size = new System.Drawing.Size(787, 457);
            this.SubscriptionFeesDataGrid.TabIndex = 112;
            this.SubscriptionFeesDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpiredSubscriptionDataGrid_CellContentClick);
            // 
            // search_panel
            // 
            this.search_panel.Controls.Add(this.sportMenu);
            this.search_panel.Controls.Add(this.label1);
            this.search_panel.Location = new System.Drawing.Point(41, 140);
            this.search_panel.Name = "search_panel";
            this.search_panel.Size = new System.Drawing.Size(787, 132);
            this.search_panel.TabIndex = 111;
            // 
            // sportMenu
            // 
            this.sportMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sportMenu.FormattingEnabled = true;
            this.sportMenu.Location = new System.Drawing.Point(18, 87);
            this.sportMenu.Name = "sportMenu";
            this.sportMenu.Size = new System.Drawing.Size(395, 28);
            this.sportMenu.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 22);
            this.label1.TabIndex = 55;
            this.label1.Text = "CHOISIR LE SPORT";
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.Transparent;
            this.header1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.header1.Font = new System.Drawing.Font("Poppins SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header1.ForeColor = System.Drawing.Color.Black;
            this.header1.Location = new System.Drawing.Point(508, 50);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(707, 54);
            this.header1.TabIndex = 109;
            this.header1.Text = "REGLER LES FRAIS";
            this.header1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.FillWeight = 30F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Club_manager.Properties.Resources.modify;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "modifier";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.Image = global::Club_manager.Properties.Resources.go_back;
            this.pictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox5.Location = new System.Drawing.Point(1292, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(36, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 110;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Image = global::Club_manager.Properties.Resources.Shrink1;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(1338, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 108;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Club_manager.Properties.Resources.restore_down;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(1384, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 107;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Club_manager.Properties.Resources.close1;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(1430, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // aName
            // 
            this.aName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.aName.DefaultCellStyle = dataGridViewCellStyle2;
            this.aName.FillWeight = 1F;
            this.aName.HeaderText = "NOM";
            this.aName.MinimumWidth = 6;
            this.aName.Name = "aName";
            this.aName.ReadOnly = true;
            this.aName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.aName.ToolTipText = "nom de l\'athlete";
            // 
            // subID
            // 
            this.subID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.subID.DefaultCellStyle = dataGridViewCellStyle3;
            this.subID.FillWeight = 1F;
            this.subID.HeaderText = "ID D\'ABONNEMENT";
            this.subID.MinimumWidth = 6;
            this.subID.Name = "subID";
            this.subID.ReadOnly = true;
            this.subID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subID.ToolTipText = "id de l\'abonnement";
            // 
            // subFees
            // 
            this.subFees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.subFees.DefaultCellStyle = dataGridViewCellStyle4;
            this.subFees.FillWeight = 1F;
            this.subFees.HeaderText = "FRAIS PAYEES";
            this.subFees.MinimumWidth = 6;
            this.subFees.Name = "subFees";
            this.subFees.ReadOnly = true;
            this.subFees.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subFees.ToolTipText = "les frais payees";
            // 
            // settle
            // 
            this.settle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.settle.FillWeight = 1F;
            this.settle.HeaderText = "";
            this.settle.Image = global::Club_manager.Properties.Resources.regler;
            this.settle.MinimumWidth = 6;
            this.settle.Name = "settle";
            this.settle.ReadOnly = true;
            // 
            // feesForm_manageFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 807);
            this.Controls.Add(this.SubscriptionFeesDataGrid);
            this.Controls.Add(this.search_panel);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "feesForm_manageFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage fees";
            this.Load += new System.EventHandler(this.feesForm_manageFees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SubscriptionFeesDataGrid)).EndInit();
            this.search_panel.ResumeLayout(false);
            this.search_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SubscriptionFeesDataGrid;
        private System.Windows.Forms.Panel search_panel;
        private System.Windows.Forms.ComboBox sportMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aName;
        private System.Windows.Forms.DataGridViewTextBoxColumn subID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subFees;
        private System.Windows.Forms.DataGridViewImageColumn settle;
    }
}
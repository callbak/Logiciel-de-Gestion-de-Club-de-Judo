﻿namespace Club_manager
{
    partial class membershipfForm_renewMembership
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.subscriptionsDataGrid = new System.Windows.Forms.DataGridView();
            this.aName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renew = new System.Windows.Forms.DataGridViewImageColumn();
            this.search_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.search_1 = new System.Windows.Forms.PictureBox();
            this.nameTextBox = new System.Windows.Forms.RichTextBox();
            this.header1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.subscriptionsDataGrid)).BeginInit();
            this.search_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // subscriptionsDataGrid
            // 
            this.subscriptionsDataGrid.AllowUserToAddRows = false;
            this.subscriptionsDataGrid.AllowUserToDeleteRows = false;
            this.subscriptionsDataGrid.AllowUserToResizeColumns = false;
            this.subscriptionsDataGrid.AllowUserToResizeRows = false;
            this.subscriptionsDataGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subscriptionsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.subscriptionsDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.subscriptionsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subscriptionsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.subscriptionsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.subscriptionsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subscriptionsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aName,
            this.subID,
            this.subState,
            this.renew});
            this.subscriptionsDataGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.subscriptionsDataGrid.Location = new System.Drawing.Point(59, 325);
            this.subscriptionsDataGrid.MultiSelect = false;
            this.subscriptionsDataGrid.Name = "subscriptionsDataGrid";
            this.subscriptionsDataGrid.ReadOnly = true;
            this.subscriptionsDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.subscriptionsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.subscriptionsDataGrid.RowHeadersWidth = 40;
            this.subscriptionsDataGrid.RowTemplate.Height = 24;
            this.subscriptionsDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.subscriptionsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subscriptionsDataGrid.Size = new System.Drawing.Size(787, 457);
            this.subscriptionsDataGrid.TabIndex = 84;
            this.subscriptionsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.subscriptionsDataGrid_CellContentClick);
            // 
            // aName
            // 
            this.aName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.aName.DefaultCellStyle = dataGridViewCellStyle1;
            this.aName.FillWeight = 50F;
            this.aName.Frozen = true;
            this.aName.HeaderText = "NOM";
            this.aName.MinimumWidth = 6;
            this.aName.Name = "aName";
            this.aName.ReadOnly = true;
            this.aName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.aName.ToolTipText = "nom de l\'athlete";
            this.aName.Width = 250;
            // 
            // subID
            // 
            this.subID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.subID.DefaultCellStyle = dataGridViewCellStyle2;
            this.subID.Frozen = true;
            this.subID.HeaderText = "ID D\'ABONNEMENT";
            this.subID.MinimumWidth = 6;
            this.subID.Name = "subID";
            this.subID.ReadOnly = true;
            this.subID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subID.ToolTipText = "id de l\'abonnement";
            this.subID.Width = 250;
            // 
            // subState
            // 
            this.subState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.subState.DefaultCellStyle = dataGridViewCellStyle3;
            this.subState.FillWeight = 40.9845F;
            this.subState.HeaderText = "ETAT D\'ABONNEMENT";
            this.subState.MinimumWidth = 6;
            this.subState.Name = "subState";
            this.subState.ReadOnly = true;
            this.subState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subState.ToolTipText = "etat de l\'abonnement";
            this.subState.Width = 250;
            // 
            // renew
            // 
            this.renew.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.renew.FillWeight = 30F;
            this.renew.HeaderText = "";
            this.renew.Image = global::Club_manager.Properties.Resources.renew;
            this.renew.MinimumWidth = 6;
            this.renew.Name = "renew";
            this.renew.ReadOnly = true;
            this.renew.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.renew.ToolTipText = "renouvler";
            // 
            // search_panel
            // 
            this.search_panel.Controls.Add(this.label1);
            this.search_panel.Controls.Add(this.search_1);
            this.search_panel.Controls.Add(this.nameTextBox);
            this.search_panel.Location = new System.Drawing.Point(41, 140);
            this.search_panel.Name = "search_panel";
            this.search_panel.Size = new System.Drawing.Size(787, 132);
            this.search_panel.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "NOM DE L\'ATHLETE";
            // 
            // search_1
            // 
            this.search_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.search_1.Image = global::Club_manager.Properties.Resources.search;
            this.search_1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.search_1.Location = new System.Drawing.Point(17, 15);
            this.search_1.Name = "search_1";
            this.search_1.Size = new System.Drawing.Size(36, 39);
            this.search_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.search_1.TabIndex = 51;
            this.search_1.TabStop = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Location = new System.Drawing.Point(17, 90);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(318, 22);
            this.nameTextBox.TabIndex = 42;
            this.nameTextBox.Text = "";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
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
            this.header1.TabIndex = 81;
            this.header1.Text = "RENOUVLER ABONNEMENT";
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
            this.pictureBox5.TabIndex = 82;
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
            this.pictureBox3.TabIndex = 80;
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
            this.pictureBox2.TabIndex = 79;
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
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // membershipfForm_renewMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 807);
            this.Controls.Add(this.subscriptionsDataGrid);
            this.Controls.Add(this.search_panel);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "membershipfForm_renewMembership";
            this.Text = "membershipfForm_renewMembership";
            this.Load += new System.EventHandler(this.membershipfForm_renewMembership_Load);
            ((System.ComponentModel.ISupportInitialize)(this.subscriptionsDataGrid)).EndInit();
            this.search_panel.ResumeLayout(false);
            this.search_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView subscriptionsDataGrid;
        private System.Windows.Forms.Panel search_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox search_1;
        private System.Windows.Forms.RichTextBox nameTextBox;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aName;
        private System.Windows.Forms.DataGridViewTextBoxColumn subID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subState;
        private System.Windows.Forms.DataGridViewImageColumn renew;
    }
}
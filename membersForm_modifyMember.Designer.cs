namespace Club_manager
{
    partial class membersForm_modifyMember
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.header1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.athleteDataGrid = new System.Windows.Forms.DataGridView();
            this.athleteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birth_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.birthDateTextBox = new System.Windows.Forms.RichTextBox();
            this.search_1 = new System.Windows.Forms.PictureBox();
            this.search_2 = new System.Windows.Forms.PictureBox();
            this.nameTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.athleteDataGrid)).BeginInit();
            this.search_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_2)).BeginInit();
            this.SuspendLayout();
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
            this.pictureBox5.TabIndex = 46;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.Transparent;
            this.header1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.header1.Font = new System.Drawing.Font("Poppins SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header1.ForeColor = System.Drawing.Color.Black;
            this.header1.Location = new System.Drawing.Point(544, 50);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(462, 54);
            this.header1.TabIndex = 45;
            this.header1.Text = "MODIFIER MEMBRE";
            this.header1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
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
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // athleteDataGrid
            // 
            this.athleteDataGrid.AllowUserToAddRows = false;
            this.athleteDataGrid.AllowUserToDeleteRows = false;
            this.athleteDataGrid.AllowUserToResizeColumns = false;
            this.athleteDataGrid.AllowUserToResizeRows = false;
            this.athleteDataGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.athleteDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.athleteDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.athleteDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.athleteDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.athleteDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.athleteDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.athleteDataGrid.ColumnHeadersHeight = 47;
            this.athleteDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.athleteDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.athleteID,
            this.aName,
            this.birth_date,
            this.gender,
            this.phone_number});
            this.athleteDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.athleteDataGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.athleteDataGrid.Location = new System.Drawing.Point(77, 279);
            this.athleteDataGrid.MultiSelect = false;
            this.athleteDataGrid.Name = "athleteDataGrid";
            this.athleteDataGrid.ReadOnly = true;
            this.athleteDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.athleteDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.athleteDataGrid.RowHeadersWidth = 40;
            this.athleteDataGrid.RowTemplate.Height = 24;
            this.athleteDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.athleteDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.athleteDataGrid.Size = new System.Drawing.Size(787, 457);
            this.athleteDataGrid.TabIndex = 70;
            this.athleteDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.athleteDataGrid_CellContentClick);
            // 
            // athleteID
            // 
            this.athleteID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.athleteID.DefaultCellStyle = dataGridViewCellStyle2;
            this.athleteID.HeaderText = "ID";
            this.athleteID.MinimumWidth = 6;
            this.athleteID.Name = "athleteID";
            this.athleteID.ReadOnly = true;
            this.athleteID.Width = 120;
            // 
            // aName
            // 
            this.aName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.aName.DefaultCellStyle = dataGridViewCellStyle3;
            this.aName.HeaderText = "nom complet";
            this.aName.MinimumWidth = 6;
            this.aName.Name = "aName";
            this.aName.ReadOnly = true;
            // 
            // birth_date
            // 
            this.birth_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.birth_date.DefaultCellStyle = dataGridViewCellStyle4;
            this.birth_date.HeaderText = "date de naissance";
            this.birth_date.MinimumWidth = 6;
            this.birth_date.Name = "birth_date";
            this.birth_date.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.gender.DefaultCellStyle = dataGridViewCellStyle5;
            this.gender.HeaderText = "sexe";
            this.gender.MinimumWidth = 6;
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // phone_number
            // 
            this.phone_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            this.phone_number.DefaultCellStyle = dataGridViewCellStyle6;
            this.phone_number.HeaderText = "numéro de téléphone ";
            this.phone_number.MinimumWidth = 6;
            this.phone_number.Name = "phone_number";
            this.phone_number.ReadOnly = true;
            // 
            // search_panel
            // 
            this.search_panel.Controls.Add(this.label6);
            this.search_panel.Controls.Add(this.label1);
            this.search_panel.Controls.Add(this.birthDateTextBox);
            this.search_panel.Controls.Add(this.search_1);
            this.search_panel.Controls.Add(this.search_2);
            this.search_panel.Controls.Add(this.nameTextBox);
            this.search_panel.Location = new System.Drawing.Point(77, 140);
            this.search_panel.Name = "search_panel";
            this.search_panel.Size = new System.Drawing.Size(787, 132);
            this.search_panel.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(429, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 18);
            this.label6.TabIndex = 56;
            this.label6.Text = "ANNÉE DE NAISSANCE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "NOM COMPLET";
            // 
            // birthDateTextBox
            // 
            this.birthDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.birthDateTextBox.Location = new System.Drawing.Point(432, 90);
            this.birthDateTextBox.Name = "birthDateTextBox";
            this.birthDateTextBox.Size = new System.Drawing.Size(318, 22);
            this.birthDateTextBox.TabIndex = 53;
            this.birthDateTextBox.Text = "";
            this.birthDateTextBox.TextChanged += new System.EventHandler(this.birthDateTextBox_TextChanged);
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
            // search_2
            // 
            this.search_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.search_2.Image = global::Club_manager.Properties.Resources.search;
            this.search_2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.search_2.Location = new System.Drawing.Point(432, 15);
            this.search_2.Name = "search_2";
            this.search_2.Size = new System.Drawing.Size(36, 39);
            this.search_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.search_2.TabIndex = 52;
            this.search_2.TabStop = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Location = new System.Drawing.Point(17, 90);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(318, 22);
            this.nameTextBox.TabIndex = 42;
            this.nameTextBox.Text = "";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged_1);
            // 
            // membersForm_modifyMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 807);
            this.Controls.Add(this.athleteDataGrid);
            this.Controls.Add(this.search_panel);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "membersForm_modifyMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify member";
            this.Load += new System.EventHandler(this.MembersForm_modifyMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.athleteDataGrid)).EndInit();
            this.search_panel.ResumeLayout(false);
            this.search_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView athleteDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn athleteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn aName;
        private System.Windows.Forms.DataGridViewTextBoxColumn birth_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone_number;
        private System.Windows.Forms.Panel search_panel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox birthDateTextBox;
        private System.Windows.Forms.PictureBox search_1;
        private System.Windows.Forms.PictureBox search_2;
        private System.Windows.Forms.RichTextBox nameTextBox;
    }
}
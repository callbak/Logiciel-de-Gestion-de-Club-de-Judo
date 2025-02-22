using System;
using System.Drawing;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class membershipsForm : Form
    {
        // Variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public membershipsForm ()
        {
            InitializeComponent();


            // On form load, handle controls
            this.Load += new EventHandler(Handle_Controls);
            // On form resize, handle controls
            this.Resize += new EventHandler(Handle_Controls);


            // Add mouse event handlers
            this.MouseDown += new MouseEventHandler(MainForm_MouseDown);
            this.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            this.MouseUp += new MouseEventHandler(MainForm_MouseUp);
        }

        private void Handle_Controls (object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls ()
        {
            // Header positionning
            int newHLeft = (this.ClientSize.Width - header1.Width) / 2;
            header1.Location = new Point(newHLeft, 80);
            // Panels positionning
            int panelWidth = renewMmsPanel.Width;
            int spacing = 45;
            int formWidth = this.ClientSize.Width; // Width of the form
            int totalPanelWidth = 2 * panelWidth;
            int totalSpacing = spacing; // 4 spaces between 5 panels
                                        // Calculate the left margin to center all panels
            int leftMargin = (formWidth - (totalPanelWidth + totalSpacing)) / 2;
            // Set the location of each panel
            Panel[] panels = { modifyMmsPanel, renewMmsPanel };
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Location = new Point(leftMargin + i * (panels[i].Width + spacing), this.ClientSize.Height / 3); // Set x position
            }
        }

        private void pictureBox1_Click_1 (object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1 (object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void pictureBox3_Click (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        // Mouse down event
        private void MainForm_MouseDown (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        // Mouse move event
        private void MainForm_MouseMove (object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the difference
                Point dif = new Point(Cursor.Position.X - dragCursorPoint.X, Cursor.Position.Y - dragCursorPoint.Y);
                // Update the form's location
                this.Location = new Point(dragFormPoint.X + dif.X, dragFormPoint.Y + dif.Y);
            }
        }

        // Mouse up event
        private void MainForm_MouseUp (object sender, MouseEventArgs e)
        {
            isDragging = false;
        }


        // navigation  --------------------------------------------------------------------------------
        private void feesPicture_Click (object sender, EventArgs e)
        {
            Form ModifySub_Form = new membershipsForm_modifyMembership();
            ModifySub_Form.WindowState = this.WindowState;
            ModifySub_Form.FormClosed += (s, args) =>
            {
                this.WindowState = ModifySub_Form.WindowState;
                this.Show();
            };
            this.Hide();
            ModifySub_Form.Show();
        }

        private void consulPicture_Click (object sender, EventArgs e)
        {
            Form RenewSub_Form = new membershipfForm_renewMembership();
            RenewSub_Form.WindowState = this.WindowState;
            RenewSub_Form.FormClosed += (s, args) =>
            {
                this.WindowState = RenewSub_Form.WindowState;
                this.Show();
            };
            this.Hide();
            RenewSub_Form.Show();

        }
    }
}

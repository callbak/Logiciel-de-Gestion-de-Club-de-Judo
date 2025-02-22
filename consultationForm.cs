using System;
using System.Drawing;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class consultationForm : Form
    {

        // Variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public consultationForm ()
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
            // Header positioning
            int newHLeft = (this.ClientSize.Width - header1.Width) / 2;
            header1.Location = new Point(newHLeft, 80);

            // Panels positioning
            int spacing = 40;
            int formWidth = this.ClientSize.Width; // Width of the form
            int totalPanelWidth = currentMmsPanel.Width + unpaidPanel.Width + expiredMmsPanel.Width;
            int totalSpacing = 2 * spacing;
            // Calculate the left margin to center all panels
            int leftMargin = (formWidth - (totalPanelWidth + totalSpacing)) / 2;

            // Set the location of each panel

            unpaidPanel.Location = new Point(leftMargin, this.ClientSize.Height / 3);
            currentMmsPanel.Location = new Point(unpaidPanel.Right + 20, this.ClientSize.Height / 3);
            expiredMmsPanel.Location = new Point(currentMmsPanel.Right + 20, this.ClientSize.Height / 3);
        }

        // navigation  --------------------------------------------------------------------------------
        private void unpaidPicture_Click (object sender, EventArgs e)
        {
            Form unpaidSub_Form = new consultationForm_unpaidMemberships();
            unpaidSub_Form.WindowState = this.WindowState;
            unpaidSub_Form.FormClosed += (s, args) =>
            {
                this.WindowState = unpaidSub_Form.WindowState;
                this.Show();
            };
            this.Hide();
            unpaidSub_Form.Show();
        }
  
        
        private void currentSubPicture_Click (object sender, EventArgs e)
        {
            Form currentSub_Form = new consultationForm_currentMemberships();
            currentSub_Form.WindowState = this.WindowState;
            currentSub_Form.FormClosed += (s, args) =>
            {
                this.WindowState = currentSub_Form.WindowState;
                this.Show();
            };
            this.Hide();
            currentSub_Form.Show();
        }

        private void pictureBox4_Click (object sender, EventArgs e)
        {
            Form expiredSub_Form = new consultationForm_expiredMemberships();
            expiredSub_Form.WindowState = this.WindowState;
            expiredSub_Form.FormClosed += (s, args) =>
            {
                this.WindowState = expiredSub_Form.WindowState;
                this.Show();
            };
            this.Hide();
            expiredSub_Form.Show();
        }


        // window control  -------------------------------------------------------------------------------------
        private void pictureBox1_Click (object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1 (object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void pictureBox3_Click_1 (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        // Mouse events  -------------------------------------------------------------------------------------
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
    }

}

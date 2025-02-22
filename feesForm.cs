using System;
using System.Drawing;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class feesForm : Form
    {

        // Variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public feesForm ()
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

        // navigation  --------------------------------------------------------------------------------
        private void feesPicture_Click (object sender, EventArgs e)
        {
            Form manageFees_Form = new feesForm_manageFees();
            manageFees_Form.WindowState = this.WindowState;
            manageFees_Form.FormClosed += (s, args) =>
            {
                this.WindowState = manageFees_Form.WindowState;
                this.Show();
            };
            this.Hide();
            manageFees_Form.Show();
        }

        private void historyPicture_Click (object sender, EventArgs e)
        {
            Form historyFees_Form = new feesForm_feesHistory();
            historyFees_Form.WindowState = this.WindowState;
            historyFees_Form.FormClosed += (s, args) =>
            {
                this.WindowState = historyFees_Form.WindowState;
                this.Show();
            };
            this.Hide();
            historyFees_Form.Show();
        }

        // Form and window control  -------------------------------------------------------------------------------------
        private void CenterControls ()
        {
            // Header positioning
            int newHLeft = (this.ClientSize.Width - header1.Width) / 2;
            header1.Location = new Point(newHLeft, 80);

            // Panels positioning
            int spacing = 40;
            int formWidth = this.ClientSize.Width; // Width of the form
            int totalPanelWidth = adjustPanel.Width + adjustHPanel.Width + historyPanel.Width;
            int totalSpacing = 2 * spacing;
            // Calculate the left margin to center all panels
            int leftMargin = (formWidth - (totalPanelWidth + totalSpacing)) / 2;

            // Set the location of each panel
            Panel[] panels = { adjustPanel, adjustHPanel, historyPanel };
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Location = new Point(leftMargin + i * (panels[i].Width + spacing), this.ClientSize.Height / 3);
            }
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

        private void pictureBox1_Click_1 (object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click (object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void pictureBox3_Click (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click (object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

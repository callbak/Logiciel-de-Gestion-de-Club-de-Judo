using System;
using System.Drawing;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class MainForm : Form
    {

        // Variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public MainForm (string username, string user_role)
        {
            InitializeComponent();

            // Set and Display username and role for this session
            userField.Text = username;
            roleField.Text = user_role;

            // On form load, position elements 
            this.Load += new EventHandler(MainForm_position);
            // On form resize, position elements
            this.Resize += new EventHandler(MainForm_position);

            // Add mouse event handlers
            this.MouseDown += new MouseEventHandler(MainForm_MouseDown);
            this.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            this.MouseUp += new MouseEventHandler(MainForm_MouseUp);
        }
        private void MainForm_position (object sender, EventArgs e)
        {
            CenterControls();
        }

        // navigation
        private void membersPicture_Click (object sender, EventArgs e)
        {
            Form members_Form = new membersForm();
            members_Form.WindowState = this.WindowState;
            members_Form.FormClosed += (s, args) =>
            {
                this.WindowState = members_Form.WindowState;
                this.Show();
            };
            this.Hide();
            members_Form.Show();
        }

        private void membershipsPicture_Click (object sender, EventArgs e)
        {
            Form memberships_Form = new membershipsForm();
            memberships_Form.WindowState = this.WindowState;
            memberships_Form.FormClosed += (s, args) =>
            {
                this.WindowState = memberships_Form.WindowState;
                this.Show();
            };
            this.Hide();
            memberships_Form.Show();
        }

        private void feesPicture_Click (object sender, EventArgs e)
        {
            Form fees_Form = new feesForm();
            fees_Form.WindowState = this.WindowState;
            fees_Form.FormClosed += (s, args) =>
            {
                this.WindowState = fees_Form.WindowState;
                this.Show();
            };
            this.Hide();
            fees_Form.Show();
        }

        private void consulPicture_Click (object sender, EventArgs e)
        {
            Form consul_Form = new consultationForm();
            consul_Form.WindowState = this.WindowState;
            consul_Form.FormClosed += (s, args) =>
            {
                this.WindowState = consul_Form.WindowState;
                this.Show();
            };
            this.Hide();
            consul_Form.Show();
        }



        private void CenterControls ()
        {
            // Header positionning
            int newHLeft = (this.ClientSize.Width - header1.Width) / 2;
            header1.Location = new Point(newHLeft, 80);
            // Panels positionning
            int panelWidth = membersPanel.Width;
            int spacing = 45;
            int formWidth = this.ClientSize.Width; // Width of the form
            int totalPanelWidth = 5 * panelWidth;
            int totalSpacing = 4 * spacing; // 4 spaces between 5 panels
                                            // Calculate the left margin to center all panels
            int leftMargin = (formWidth - (totalPanelWidth + totalSpacing)) / 2;
            // Set the location of each panel
            Panel[] panels = { membersPanel, membershipsPanel, feesPanel, consulPanel, statsPanel };
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Location = new Point(leftMargin + i * (panelWidth + spacing), this.ClientSize.Height / 3); // Set x position
            }
            // Info Panels positionning
            userInfo.Location = new Point(membershipsPanel.Left, this.ClientSize.Height - 100);
            roleInfo.Location = new Point(consulPanel.Left, this.ClientSize.Height - 100);

        }
        // window control
        private void pictureBox1_Click (object sender, EventArgs e)
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

        // Mouse events
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

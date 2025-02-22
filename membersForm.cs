using System;
using System.Drawing;
using System.Windows.Forms;

namespace Club_manager
{
    public partial class membersForm : Form
    {
        // Variables to store mouse position
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public membersForm ()
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
            int panelWidth = membersPanel.Width;
            int spacing = 40;
            int formWidth = this.ClientSize.Width; // Width of the form
            int totalPanelWidth = (3 * panelWidth) + modifydeleteMemberPanel.Width; // 3 smaller panels + 1 larger panel
            int totalSpacing = 3 * spacing; // 4 spaces for 4 panels (including the modify panel)

            // Calculate the left margin to center all panels
            int leftMargin = (formWidth - (totalPanelWidth + totalSpacing)) / 2;

            // Set the location of each panel
            int currentX = leftMargin;                           // Start from the left margin
            membersPanel.Location = new Point(currentX, this.ClientSize.Height / 3);
            currentX += panelWidth + spacing;                    // Move to the next position

            addMemberPanel.Location = new Point(currentX, this.ClientSize.Height / 3);
            currentX += panelWidth + spacing;                    // Move to the next position

            modifydeleteMemberPanel.Location = new Point(currentX, this.ClientSize.Height / 3);
            currentX += modifydeleteMemberPanel.Width + spacing; // Move to the next position

            restoreMemberPanel.Location = new Point(currentX, this.ClientSize.Height / 3);
        }

        // window control  --------------------------------------------------------------------------------
        private void pictureBox1_Click_1 (object sender, EventArgs e)
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

        private void pictureBox4_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        //Mouse events  --------------------------------------------------------------------------------
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
        private void addMemberPicture_Click (object sender, EventArgs e)
        {
            Form addMember_Form = new membersForm_addMember();
            addMember_Form.WindowState = this.WindowState;
            addMember_Form.FormClosed += (s, args) =>
            {
                this.WindowState = addMember_Form.WindowState;
                this.Show();
            };
            this.Hide();
            addMember_Form.Show();
        }

        private void membersPicture_Click (object sender, EventArgs e)
        {
            Form memberList_Form = new membersForm_viewMember();
            memberList_Form.WindowState = this.WindowState;
            memberList_Form.FormClosed += (s, args) =>
            {
                this.WindowState = memberList_Form.WindowState;
                this.Show();
            };
            this.Hide();
            memberList_Form.Show();
        }

        private void modifydeleteMemberPicture_Click (object sender, EventArgs e)
        {
            Form modifyMember_Form = new membersForm_modifyMember();
            modifyMember_Form.WindowState = this.WindowState;
            modifyMember_Form.FormClosed += (s, args) =>
            {
                this.WindowState = modifyMember_Form.WindowState;
                this.Show();
            };
            this.Hide();
            modifyMember_Form.Show();
        }

        private void restoreMemberPicture_Click (object sender, EventArgs e)
        {
            Form restoreMember_Form = new membersForm_restoreMember();
            restoreMember_Form.WindowState = this.WindowState;
            restoreMember_Form.FormClosed += (s, args) =>
            {
                this.WindowState = restoreMember_Form.WindowState;
                this.Show();
            };
            this.Hide();
            restoreMember_Form.Show();
        }
    }
}

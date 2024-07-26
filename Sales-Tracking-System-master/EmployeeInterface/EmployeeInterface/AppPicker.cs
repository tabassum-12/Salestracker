using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInterface
{

    public partial class AppPicker : Form
    {
        // Data Members

        private bool admin = false;

        // Methods

        public AppPicker()
        {
            InitializeComponent();
        }

        private void editQuoteButton_Click(object sender, EventArgs e)
        {
            EmployeeInterface em = new EmployeeInterface();
            this.Hide();
            em.ShowDialog();
            this.Show();
        }

        private void createPOButton_Click(object sender, EventArgs e)
        {
            EmployeeInterface2 em2 = new EmployeeInterface2();
            this.Hide();
            em2.ShowDialog();
            this.Show();
        }

        private void manageSAButton_Click(object sender, EventArgs e)
        {
            AdminInterface ad = new AdminInterface();
            this.Hide();
            ad.ShowDialog();
            this.Show();
        }

        private void AppPicker_Load(object sender, EventArgs e)
        {
            Authentication login = new Authentication();
            login.ShowDialog();

            if (!login.isValid())
            {
                Dispose();
            }

            admin = login.isAdmin();

            if (!admin)
            {
                manageSAButton.Visible = false;
                this.Width = 354;
                this.Height = 200;

                selectLabel.Location = new Point(124, 30);
            }
        }
    }
}

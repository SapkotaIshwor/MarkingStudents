using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text != "admin")
            {
                MessageBox.Show("Username is incorrect!","Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
            }
            else if (txtPassword.Text!="admin")
            {
                MessageBox.Show("Password is incorrect", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Logged in Successfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Home hm = new Home();
                hm.Show();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

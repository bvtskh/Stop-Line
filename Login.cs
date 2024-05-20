using SMT.ServiceInstance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMT
{
    public partial class frmLogin : Form
    {
        bool FieldError(Control control)
        {
            if (control.Text == "" || control.Text == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(control, "Required field!");
                control.Focus();
                return false;
            }
            return true;
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (FieldError(txtUsername) == false)
            {
                return;
            }
            else if (FieldError(txtPassword) == false)
            {
                return;
            }
            else
            {
                string username = txtUsername.Text.ToLower();
                string password = txtPassword.Text.ToLower();
                var user = SingletonHelper.GetUserLogin(username, password);
                if (user != null)
                {
                    Program._user = user;
                    var isAdmin = SingletonHelper.IsAdmin(user.ID);
                    this.Dispose();
                    if (isAdmin)
                    {
                        new frmLineConfig().ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("User not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}

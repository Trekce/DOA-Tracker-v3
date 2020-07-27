using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOA_Tracker_v3
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void btnUserInfoSubmit_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Length != 0)
            {
                Statics.userID = txtID.Text;
            }
            if(txtPW.Text.Length != 0)
            {
                Statics.userPW = txtPW.Text;
            }
            Close();
        }

        private void verifyUserExists()
        {

        }

        private void btnUserInfoClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUserInfoCreateUser_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            NewUser newUserForm = new NewUser();
            newUserForm.ShowDialog(this);
            this.Visible = true;
        }
    }
}

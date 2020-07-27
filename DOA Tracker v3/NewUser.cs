using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using MySqlConnector;

namespace DOA_Tracker_v3
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void btnNewUserSubmit_Click(object sender, EventArgs e)
        {
            if (txtPW.Text == txtPWConfirm.Text)
            {
                Statics.userID = "userVerify";
                Statics.userPW = "c8Ksx8pQNf2ABd68";
                using (MySqlConnection con = new MySqlConnection(Statics.SQLConnString))
                using (MySqlCommand com = new MySqlCommand("CREATE USER '"+txtID.Text+"'@'%' IDENTIFIED BY '"+txtPW.Text+"';", con))
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
                Statics.userID = "";
                Statics.userPW = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }
    }
}

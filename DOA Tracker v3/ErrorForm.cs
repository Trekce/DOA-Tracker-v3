using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOA_Tracker_v3
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
            
            this.CenterToParent();
            this.Icon = Properties.Resources.error;
            txtErrorList.Text = Statics.errorMessage.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Statics.errorMessage.Clear();
            txtErrorList.Clear();
            this.Close();
        }

        
    }
}

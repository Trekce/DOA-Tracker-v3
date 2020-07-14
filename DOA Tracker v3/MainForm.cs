using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DOA_Tracker_v3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tabHome();
            btnMinimize.Text = "\uD83D\uDDD5";
            btnExit.Text = "\u274C";
            //this.tabControl1.Appearance = TabAppearance.FlatButtons;
            //this.tabControl1.ItemSize = new Size(0, 1);
            //this.tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        //Global Input Fixes/////////////////////
        private void enterInputFix_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (txtRepInspDate.Focused && txtRepInspDate.Text == "")
                {
                    txtRepInspDate.Text = Statics.thisDay;
                }
                if (txtRepEntryDate.Focused && txtRepEntryDate.Text == "")
                {
                    txtRepEntryDate.Text = Statics.thisDay;
                }
                if (txtInvAddDate.Focused && txtInvAddDate.Text == "")
                {
                    txtInvAddDate.Text = Statics.thisDay;
                }
                if (txtRepType.Focused && txtRepType.Text == "")
                {
                    txtRepType.Text = "RADIO";
                }
                if (txtInvAddComments.Focused)
                {
                    invPerformAppend();
                    txtInvAddComments.Clear();
                    return;
                }
                if (txtRepInqSerialNumInput.Focused)
                {
                    repInqSearchFunction();
                    return;
                }

                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        //Home Screen Buttons////////////////////
        private void btnOpenHome_Click(object sender, EventArgs e) => tabHome();
        private void btnOpenRepair_Click(object sender, EventArgs e) => tabRep();
        private void btnOpenRepInq_Click(object sender, EventArgs e) => tabRepInq();
        private void btnOpenInventory_Click(object sender, EventArgs e) => tabInv();
        private void btnOpenInvInquiry_Click(object sender, EventArgs e) => tabInvInq();
        private void btnOpenInquiry_Click(object sender, EventArgs e) => tabInq();
        private void btnOpenDatabase_Click(object sender, EventArgs e) => Process.Start(Statics.dirDatabaseFile);
        private void btnClose_Click(object sender, EventArgs e) => Close();
        private void btnExit_Click(object sender, EventArgs e) => Close();
        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void btnOpenSecureCRT_Click(object sender, EventArgs e)
        {
            Process secureCRT = new Process();
            secureCRT.StartInfo.FileName = @"C:\Program Files\VanDyke Software\SecureCRT\SecureCRT.exe";
            secureCRT.StartInfo.Arguments = @"/S WMS ";
            secureCRT.Start();
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            
        }

        //Home Screen Links//////////////////////
        private void linkUnited_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("Chrome.exe", "https://united.wwt.com/");
        private void linkReportal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("Chrome.exe", "https://reportal.apps.wwt.com/");
        private void linkDocMan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("Chrome.exe", "https://docman2.apps.wwt.com/");


        //Tab Selection Methods//////////////////
        private void tabHome()
        {
            btnOpenHome.BackColor = Color.CadetBlue;
            btnOpenRepair.BackColor = Color.DarkSlateGray;
            btnOpenRepInq.BackColor = Color.DarkSlateGray;
            btnOpenInventory.BackColor = Color.DarkSlateGray;
            btnOpenInvInquiry.BackColor = Color.DarkSlateGray;
            btnOpenInquiry.BackColor = Color.DarkSlateGray;
            tabControl1.SelectTab(0);
        }
        private void tabRep()
        {
            btnOpenHome.BackColor = Color.DarkSlateGray;
            btnOpenRepair.BackColor = Color.CadetBlue;
            btnOpenRepInq.BackColor = Color.DarkSlateGray;
            btnOpenInventory.BackColor = Color.DarkSlateGray;
            btnOpenInvInquiry.BackColor = Color.DarkSlateGray;
            btnOpenInquiry.BackColor = Color.DarkSlateGray;
            tabControl1.SelectTab(1);
        }
        private void tabRepInq()
        {
            btnOpenHome.BackColor = Color.DarkSlateGray;
            btnOpenRepair.BackColor = Color.DarkSlateGray;
            btnOpenRepInq.BackColor = Color.CadetBlue;
            btnOpenInventory.BackColor = Color.DarkSlateGray;
            btnOpenInvInquiry.BackColor = Color.DarkSlateGray;
            btnOpenInquiry.BackColor = Color.DarkSlateGray;
            tabControl1.SelectTab(2);
        }
        private void tabInv()
        {
            btnOpenHome.BackColor = Color.DarkSlateGray;
            btnOpenRepair.BackColor = Color.DarkSlateGray;
            btnOpenRepInq.BackColor = Color.DarkSlateGray;
            btnOpenInventory.BackColor = Color.CadetBlue;
            btnOpenInvInquiry.BackColor = Color.DarkSlateGray;
            btnOpenInquiry.BackColor = Color.DarkSlateGray;
            tabControl1.SelectTab(3);
        }
        private void tabInvInq()
        {
            btnOpenHome.BackColor = Color.DarkSlateGray;
            btnOpenRepair.BackColor = Color.DarkSlateGray;
            btnOpenRepInq.BackColor = Color.DarkSlateGray;
            btnOpenInventory.BackColor = Color.DarkSlateGray;
            btnOpenInvInquiry.BackColor = Color.CadetBlue;
            btnOpenInquiry.BackColor = Color.DarkSlateGray;
            tabControl1.SelectTab(4);
        }
        private void tabInq()
        {
            btnOpenHome.BackColor = Color.DarkSlateGray;
            btnOpenRepair.BackColor = Color.DarkSlateGray;
            btnOpenRepInq.BackColor = Color.DarkSlateGray;
            btnOpenInventory.BackColor = Color.DarkSlateGray;
            btnOpenInvInquiry.BackColor = Color.DarkSlateGray;
            btnOpenInquiry.BackColor = Color.CadetBlue;
            tabControl1.SelectTab(5);
        }
        
        //Repair Screen Buttons//////////////////
        private void btnRepSubmit_Click(object sender, EventArgs e)
        {
            if (errorCheck())
            {
                setOutput();
                appendRepData();
                clearRepair();
            }
        }
        private void btnRepClear_Click(object sender, EventArgs e) => clearRepair();
        private void btnRepDatabase_Click(object sender, EventArgs e) => Process.Start(Statics.dirDatabaseFile);
        private void btnRepHome_Click(object sender, EventArgs e)
        {
            clearRepair();
            tabControl1.SelectTab(0);
        }

        //Repair Screen Methods//////////////////
        private void clearRepair()
        {
            txtRepInspDate.Clear();
            txtRepEntryDate.Clear();
            txtRepType.Clear();
            txtRepItemNum.Clear();
            txtRepSerialNum.Clear();
            txtRepAssetNum.Clear();
            txtRepFailureReason.Clear();
            txtRepComments.Clear();
            cmbRepResult.Text = "";
            txtRepInspDate.Select();
        }
        private bool errorCheck()
        {
            string date = txtRepEntryDate.Text;
            List<string> errorList = new List<string>();
            bool check = true;
            int chk = 0;
            if (DateTime.TryParse(date, out Statics.outDoaDate) == false)
            {
                errorList.Add("DOA entry date must be a valid date.");
                check = false;
                chk++;
            }
            if (txtRepType.Text.Length == 0)
            {
                errorList.Add("Item type cannot be left blank.");
                check = false;
                chk++;
            }
            if (txtRepItemNum.Text.Length == 0)
            {
                errorList.Add("Item number cannot be left blank.");
                check = false;
                chk++;
            }
            if (txtRepSerialNum.Text.Length == 0)
            {
                errorList.Add("Serial number cannot be left blank.");
                check = false;
                chk++;
            }
            if (txtRepAssetNum.Text.Length == 0)
            {
                errorList.Add("Asset number cannot be left blank.");
                check = false;
                chk++;
            }
            if (txtRepFailureReason.Text.Length == 0)
            {
                errorList.Add("A failure reason must be specified.");
                check = false;
                chk++;
            }
            if (txtRepComments.Text.Length == 0)
            {
                errorList.Add("Repair comments cannot be left blank.");
                check = false;
                chk++;
            }
            if (cmbRepResult.Text.Length == 0)
            {
                errorList.Add("A result must be specified");
                check = false;
                chk++;
            }
            if (getPrice(txtRepItemNum.Text) == -1)
            {
                errorList.Add("Item number was not found in item list.");
                check = false;
                chk++;
            }
            else if (getPrice(txtRepItemNum.Text) == 0)
            {
                errorList.Add("Item's market price is set to $0.00; further inquiry may be required. (This did not stop the record from being saved)");
                chk++;
            }
            if (chk != 0)
            {
                foreach (string str in errorList)
                {
                    Statics.errorMessage.Append(str + Environment.NewLine);
                }
                ErrorForm errorForm1 = new ErrorForm();
                SystemSounds.Asterisk.Play();
                errorForm1.ShowDialog(this);
                //MessageBox.Show(Statics.errorMessage.ToString(), "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return check;
        }
        private void setOutput()
        {
            string dateFormat = "MM/dd/yyyy";
            Statics.outInspDate = DateTime.Now;
            Statics.output[0] = Statics.outInspDate.ToString(dateFormat);
            Statics.output[1] = Statics.outDoaDate.ToString(dateFormat);
            Statics.output[2] = txtRepType.Text;
            Statics.output[3] = txtRepItemNum.Text;
            Statics.output[4] = txtRepSerialNum.Text;
            Statics.output[5] = txtRepAssetNum.Text;
            Statics.output[6] = txtRepFailureReason.Text;
            Statics.output[7] = txtRepComments.Text;
            Statics.output[8] = cmbRepResult.Text;
            Statics.output[9] = Convert.ToString(getPrice(txtRepItemNum.Text));
        }
        private void appendRepData()
        {
            string[] tableName = new string[] { "", "Cumulative Report" };
            using (OleDbConnection con = new OleDbConnection(Statics.connString))
            {
                using (OleDbCommand cmd = con.CreateCommand())
                {
                    if (cmbRepResult.Text == "Retired")
                    {
                        tableName[0] = "Retire Report";
                    }
                    else if (cmbRepResult.Text == "Harvested")
                    {
                        tableName[0] = "Harvest Report";
                    }
                    else if (cmbRepResult.Text == "Backed Out")
                    {
                        tableName[0] = "Backed Out Report";
                    }
                    else
                    {
                        tableName[0] = "Repair Report";
                    }
                    foreach (string str in tableName)
                    {
                        con.Open();
                        cmd.CommandText = "Insert into " +
                            "[" + str + "] (DateInspected, TicketDate, DeviceType, ItemNumber, SerialNumber, AssetNumber, FailureReason, RepairComments, Result, MarketPrice) " +
                            "Values(@dateInsp, @dateDOA, @devType, @itemNum, @serialNum, @assetNum, @failureReason, @repairComments, @result, @marketPrice)";
                        cmd.Parameters.AddWithValue("@dateInsp", Statics.output[0]);
                        cmd.Parameters.AddWithValue("@dateDOA", Statics.output[1]);
                        cmd.Parameters.AddWithValue("@devType", Statics.output[2]);
                        cmd.Parameters.AddWithValue("@itemNum", Statics.output[3]);
                        cmd.Parameters.AddWithValue("@serialNum", Statics.output[4]);
                        cmd.Parameters.AddWithValue("@assetNum", Statics.output[5]);
                        cmd.Parameters.AddWithValue("@failureReason", Statics.output[6]);
                        cmd.Parameters.AddWithValue("@repairComments", Statics.output[7]);
                        cmd.Parameters.AddWithValue("@result", Statics.output[8]);
                        cmd.Parameters.AddWithValue("@marketPrice", Statics.output[9]);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
        }
        private decimal getPrice(string input)
        {
            if (input != "") {
                int i = 0;
                foreach (DataRow row in Statics.masterItemList.Rows)
                {
                    string tmpItemName = Convert.ToString(Statics.masterItemList.Rows[i][0]);
                    if (tmpItemName == input)
                    {
                        decimal tmpPrice = Convert.ToDecimal(Statics.masterItemList.Rows[i][3]);
                        return tmpPrice;
                    }
                    i++;
                }
                return -1;
            }else
            {
                return -1;
            }
        }

        //Search Screen Buttons//////////////////
        private void btnSrcSearch_Click(object sender, EventArgs e)     => requestInquiry(txtSrcItemNum.Text);
        private void btnSrcClear_Click(object sender, EventArgs e)      => clearSearch();
        private void btnSrcHome_Click(object sender, EventArgs e)       => tabControl1.SelectTab(0);

        //Search Screen Methods//////////////////
        private void requestInquiry(string input)
        {
            if (txtSrcItemNum.Text == "")
            {
                InquiryErrorForm error = new InquiryErrorForm();
                SystemSounds.Asterisk.Play();
                error.ShowDialog(this);
                //MessageBox.Show("Cannot search for a blank item number.");
                return;
            }

            int i = 0;
            foreach (DataRow row in Statics.masterItemList.Rows)
            {
                string tmpItemName = Convert.ToString(Statics.masterItemList.Rows[i][0]);
                if (tmpItemName == input)
                {
                    txtSrcItemNumRet.Text = Convert.ToString(Statics.masterItemList.Rows[i][0]);
                    txtSrcATTNumRet.Text = Convert.ToString(Statics.masterItemList.Rows[i][1]);
                    txtSrcMFGRet.Text = Convert.ToString(Statics.masterItemList.Rows[i][2]);
                    txtSrcPriceRet.Text = "$" + Convert.ToString(Statics.masterItemList.Rows[i][3]);
                    txtSrcDescRet.Text = Convert.ToString(Statics.masterItemList.Rows[i][4]);
                    txtSrcItemNum.Clear();
                    txtSrcItemNum.Select();
                    return;
                }
                i++;
            }
            MessageBox.Show("Item number '" + input + "' not found.");
            txtSrcItemNum.Clear();
            txtSrcItemNum.Select();
        }
        private void clearSearch()
        {
            txtSrcItemNum.Clear();
            txtSrcItemNumRet.Clear();
            txtSrcMFGRet.Clear();
            txtSrcATTNumRet.Clear();
            txtSrcPriceRet.Clear();
            txtSrcDescRet.Clear();
            txtSrcItemNum.Select();
        }

        //Inventory Screen Buttons///////////////
        private void btnInvAddSubmit_Click(object sender, EventArgs e)
        {
            invPerformAppend();
        }
        private void btnInvClearAddRecord_Click(object sender, EventArgs e)
        {
            invClearAdd();
        }
        private void btnInvRemSubmit_Click(object sender, EventArgs e)
        {
            using (OleDbConnection thisConnection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Statics.dirDatabaseFile))
            {
                string deletequery = @"DELETE FROM [Inventory] WHERE [SerialNumber] = @serialNum";
                OleDbCommand myAccessCommandDelete = new OleDbCommand(deletequery, thisConnection);
                thisConnection.Open();
                myAccessCommandDelete.Parameters.Add("@serialNum", OleDbType.VarWChar).Value = txtInvRemSerialNum.Text;
                myAccessCommandDelete.ExecuteNonQuery();
            }
            invClearRem();
        }
        private void btnInvOpenDB_Click(object sender, EventArgs e)
        {
            Process.Start(Statics.dirDatabaseFile);
        }
        private void btnInvHome_Click(object sender, EventArgs e)
        {
            invClearAdd();
            txtInvRemSerialNum.Clear();
            tabControl1.SelectTab(0);
        }

        //Inventory Screen Methods///////////////
        private void invClearAdd()
        {
            txtInvAddDate.Clear();
            txtInvAddItemNum.Clear();
            txtInvAddSerialNum.Clear();
            txtInvAddAssetNum.Clear();
            txtInvAddComments.Clear();
            txtInvAddDate.Select();
        }
        private void invClearRem()
        {
            txtInvRemSerialNum.Clear();
            txtInvRemSerialNum.Select();
        }
        private bool invErrorCheck()
        {
            string date = txtInvAddDate.Text;
            List<string> errorList = new List<string>();
            bool check = true;
            int chk = 0;
            if (DateTime.TryParse(date, out Statics.outInvDate) == false)
            {
                errorList.Add("DOA entry date must be a valid date.");
                check = false;
                chk++;
            }
            if (txtInvAddItemNum.Text.Length == 0)
            {
                errorList.Add("Item number cannot be left blank.");
                check = false;
                chk++;
            }
            if (txtInvAddSerialNum.Text.Length == 0)
            {
                errorList.Add("Serial number cannot be left blank.");
                check = false;
                chk++;
            }
            if (txtInvAddAssetNum.Text.Length == 0)
            {
                errorList.Add("Asset number cannot be left blank.");
                check = false;
                chk++;
            }
            if (txtInvAddComments.Text.Length == 0)
            {
                errorList.Add("Failure comments cannot be left blank.");
                check = false;
                chk++;
            }
            if (getPrice(txtInvAddItemNum.Text) == -1)
            {
                errorList.Add("Item number was not found in item list.");
                check = false;
                chk++;
            }
            else if (getPrice(txtInvAddItemNum.Text) == 0)
            {
                errorList.Add("Item's market price is set to $0.00; further inquiry may be required. (This did not stop the record from being saved)");
                chk++;
            }
            if (chk != 0)
            {
                foreach (string str in errorList)
                {
                    Statics.errorMessage.Append(str + Environment.NewLine);
                }
                ErrorForm errorForm1 = new ErrorForm();
                SystemSounds.Asterisk.Play();
                errorForm1.ShowDialog(this);
                //MessageBox.Show(Statics.errorMessage.ToString(), "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return check;
        }
        private void invSetOutput()
        {
            string price = Convert.ToString(getPrice(txtInvAddItemNum.Text));
            string dateFormat = "MM/dd/yyyy";
            Statics.invOutput[0] = Statics.outInvDate.ToString(dateFormat);
            Statics.invOutput[1] = txtInvAddItemNum.Text;
            Statics.invOutput[2] = txtInvAddSerialNum.Text;
            Statics.invOutput[3] = txtInvAddAssetNum.Text;
            Statics.invOutput[4] = invGetCEQ(txtInvAddItemNum.Text);
            Statics.invOutput[5] = txtInvAddComments.Text;
            Statics.invOutput[6] = price;
            Statics.invOutput[7] = price;

        }
        private void invAppendData()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Statics.dirDatabaseFile))
                using (OleDbCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Insert into " +
                        "[Inventory](EntryDate,ItemNumber,SerialNumber,AssetNumber,ATTNum,[Comments],MarketPrice,MarketPrice2) " +
                        "Values(@date, @itemNum, @serialNum, @assetNum,@ceq, @comments, @price, @price2)";
                    cmd.Parameters.AddWithValue("@date", Statics.invOutput[0]);
                    cmd.Parameters.AddWithValue("@itemNum", Statics.invOutput[1]);
                    cmd.Parameters.AddWithValue("@serialNum", Statics.invOutput[2]);
                    cmd.Parameters.AddWithValue("@assetNum", Statics.invOutput[3]);
                    cmd.Parameters.AddWithValue("@ceq", Statics.invOutput[4]);
                    cmd.Parameters.AddWithValue("@comments", Statics.invOutput[5]);
                    cmd.Parameters.AddWithValue("@price", Statics.invOutput[6]);
                    cmd.Parameters.AddWithValue("@price2", Statics.invOutput[7]);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (OleDbException)
            {
                Statics.errorMessage.Clear();
                Statics.errorMessage.Append("Device already located in inventory");
                ErrorForm errorForm1 = new ErrorForm();
                SystemSounds.Asterisk.Play();
                errorForm1.ShowDialog(this);
            }
        }
        private void invPerformAppend()
        {
            if (invErrorCheck())
            {
                invSetOutput();
                invAppendData();
                invClearAdd();
            }
        }
        private string invGetCEQ(string input)
        {
            string output;
            int i = 0;
            foreach (DataRow row in Statics.masterItemList.Rows)
            {
                string tmpItemName = Convert.ToString(Statics.masterItemList.Rows[i][0]);
                if (tmpItemName == input)
                {
                    output = Convert.ToString(Statics.masterItemList.Rows[i][1]);
                    return output;
                }
                i++;
            }
            return "N/A";
        }

        //Repair Inquiry Buttons/////////////////
        private void btnRepInquiryBack_Click(object sender, EventArgs e)
        {
            clearRepairInquiry();
            lblRepInqResultCount.Visible = false;
            lblRepInqResultNum.Visible = false;
            btnRepInqNext.Visible = false;
            btnRepInqPrev.Visible = false;
            tabControl1.SelectTab(0);
        }
        private void btnRepInqSearch_Click(object sender, EventArgs e)
        {
            repInqSearchFunction();
        }
        private void btnRepInqClear_Click(object sender, EventArgs e)
        {
            clearRepairInquiry();
        }
        private void btnRepInqNext_Click(object sender, EventArgs e)
        {
            if(Statics.repInqCurrentInq != Statics.repInqListCount)
            {
                Statics.repInqCurrentInq++;
                lblRepInqResultNum.Text = "Inquiry #: " + Statics.repInqCurrentInq;
                txtRepInqItemNum.Text = Statics.repInqPulledItemNums[Statics.repInqCurrentInq - 1];
                txtRepInqSerialNum.Text = Statics.repInqPulledSerials[Statics.repInqCurrentInq - 1];
                txtRepInqAssetNum.Text = Statics.repInqPulledAssets[Statics.repInqCurrentInq - 1];
                txtRepInqDateInsp.Text = Statics.repInqPulledDateInsp[Statics.repInqCurrentInq - 1];
                txtRepInqReason.Text = Statics.repInqPulledReasons[Statics.repInqCurrentInq - 1];
                txtRepInqComments.Text = Statics.repInqPulledComments[Statics.repInqCurrentInq - 1];
            }
            else
            {
                Statics.repInqCurrentInq = 1;
                lblRepInqResultNum.Text = "Inquiry #: " + Statics.repInqCurrentInq;
                txtRepInqItemNum.Text = Statics.repInqPulledItemNums[Statics.repInqCurrentInq - 1];
                txtRepInqSerialNum.Text = Statics.repInqPulledSerials[Statics.repInqCurrentInq - 1];
                txtRepInqAssetNum.Text = Statics.repInqPulledAssets[Statics.repInqCurrentInq - 1];
                txtRepInqDateInsp.Text = Statics.repInqPulledDateInsp[Statics.repInqCurrentInq - 1];
                txtRepInqReason.Text = Statics.repInqPulledReasons[Statics.repInqCurrentInq - 1];
                txtRepInqComments.Text = Statics.repInqPulledComments[Statics.repInqCurrentInq - 1];
            }
        }
        private void btnRepInqPrev_Click(object sender, EventArgs e)
        {
            if(Statics.repInqCurrentInq != 1)
            {
                Statics.repInqCurrentInq--;
                lblRepInqResultNum.Text = "Inquiry #: " + Statics.repInqCurrentInq;
                txtRepInqItemNum.Text = Statics.repInqPulledItemNums[Statics.repInqCurrentInq - 1];
                txtRepInqSerialNum.Text = Statics.repInqPulledSerials[Statics.repInqCurrentInq - 1];
                txtRepInqAssetNum.Text = Statics.repInqPulledAssets[Statics.repInqCurrentInq - 1];
                txtRepInqDateInsp.Text = Statics.repInqPulledDateInsp[Statics.repInqCurrentInq - 1];
                txtRepInqReason.Text = Statics.repInqPulledReasons[Statics.repInqCurrentInq - 1];
                txtRepInqComments.Text = Statics.repInqPulledComments[Statics.repInqCurrentInq - 1];
            }
            else
            {
                Statics.repInqCurrentInq = Statics.repInqListCount;
                lblRepInqResultNum.Text = "Inquiry #: " + Statics.repInqCurrentInq;
                txtRepInqItemNum.Text = Statics.repInqPulledItemNums[Statics.repInqCurrentInq - 1];
                txtRepInqSerialNum.Text = Statics.repInqPulledSerials[Statics.repInqCurrentInq - 1];
                txtRepInqAssetNum.Text = Statics.repInqPulledAssets[Statics.repInqCurrentInq - 1];
                txtRepInqDateInsp.Text = Statics.repInqPulledDateInsp[Statics.repInqCurrentInq - 1];
                txtRepInqReason.Text = Statics.repInqPulledReasons[Statics.repInqCurrentInq - 1];
                txtRepInqComments.Text = Statics.repInqPulledComments[Statics.repInqCurrentInq - 1];
            }
        }

        //Repair Inquiry Methods/////////////////
        private void clearRepairInquiry()
        {
            txtRepInqSerialNumInput.Clear();
            txtRepInqItemNum.Clear();
            txtRepInqSerialNum.Clear();
            txtRepInqAssetNum.Clear();
            txtRepInqDateInsp.Clear();
            txtRepInqReason.Clear();
            txtRepInqComments.Clear();
            txtRepInqSerialNumInput.Select();
        }
        private void repInqSearchFunction()
        {
            string tmpItemNum;
            string tmpSerial;
            string tmpAsset;
            DateTime tmpDate;
            string tmpReason;
            string tmpComments;
            Statics.repInqListCount = 0;
            Statics.repInqCurrentInq = 1;
            Statics.repInqPulledItemNums.Clear();
            Statics.repInqPulledSerials.Clear();
            Statics.repInqPulledAssets.Clear();
            Statics.repInqPulledReasons.Clear();
            Statics.repInqPulledComments.Clear();
            using (OleDbConnection conn = new OleDbConnection(Statics.connString))
            {
                string input = txtRepInqSerialNumInput.Text;
                OleDbCommand cmd = new OleDbCommand(
                    "SELECT ItemNumber, SerialNumber, AssetNumber, DateInspected, FailureReason, RepairComments FROM [Repair Report] WHERE SerialNumber='" + input + "'",
                    conn);

                conn.Open();

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tmpItemNum = reader.GetString(0);
                        tmpSerial = reader.GetString(1);
                        tmpAsset = reader.GetString(2);
                        tmpDate = reader.GetDateTime(3);
                        tmpReason = reader.GetString(4);
                        tmpComments = reader.GetString(5);
                        Statics.repInqPulledItemNums.Add(tmpItemNum);
                        Statics.repInqPulledSerials.Add(tmpSerial);
                        Statics.repInqPulledAssets.Add(tmpAsset);
                        Statics.repInqPulledDateInsp.Add(tmpDate.ToString("d"));
                        Statics.repInqPulledReasons.Add(tmpReason);
                        Statics.repInqPulledComments.Add(tmpComments);
                        Statics.repInqListCount++;
                    }
                    lblRepInqResultCount.Text = "Total Results: " + Statics.repInqListCount;
                    lblRepInqResultNum.Text = "Inquiry #: " + Statics.repInqCurrentInq;
                    txtRepInqItemNum.Text = Statics.repInqPulledItemNums[Statics.repInqCurrentInq-1];
                    txtRepInqSerialNum.Text = Statics.repInqPulledSerials[Statics.repInqCurrentInq-1];
                    txtRepInqAssetNum.Text = Statics.repInqPulledAssets[Statics.repInqCurrentInq-1];
                    txtRepInqDateInsp.Text = Statics.repInqPulledDateInsp[Statics.repInqCurrentInq - 1];
                    txtRepInqReason.Text = Statics.repInqPulledReasons[Statics.repInqCurrentInq-1];
                    txtRepInqComments.Text = Statics.repInqPulledComments[Statics.repInqCurrentInq-1];

                    if(Statics.repInqListCount > 1)
                    {
                        btnRepInqPrev.Visible = true;
                        btnRepInqNext.Visible = true;
                    }
                    lblRepInqResultCount.Visible = true;
                    lblRepInqResultNum.Visible = true;
                    if (btnRepInqPrev.Visible == true && Statics.repInqListCount == 1)
                    {
                        btnRepInqPrev.Visible = false;
                        btnRepInqNext.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Device not found.");
                }
                txtRepInqSerialNumInput.Clear();
                txtRepInqSerialNumInput.Select();
            }
        }

        //Inventory Inquiry Buttons//////////////
        private void btnInvInqSearch_Click(object sender, EventArgs e)
        {
            invInqSearchFunction();
        }
        private void btnInvInqClear_Click(object sender, EventArgs e)
        {
            invInqClear();
        }
        private void btnInvInqPrev_Click(object sender, EventArgs e)
        {
            if (Statics.invInqCurrentInq != 1)
            {
                Statics.invInqCurrentInq--;
                lblInvInqResultNum.Text = "Inquiry #: " + Statics.invInqCurrentInq;
                txtInvInqItemNum.Text = Statics.invInqPulledItemNums[Statics.invInqCurrentInq - 1];
                txtInvInqSerialNum.Text = Statics.invInqPulledSerials[Statics.invInqCurrentInq - 1];
                txtInvInqAssetNum.Text = Statics.invInqPulledAssets[Statics.invInqCurrentInq - 1];
                txtInvInqReason.Text = Statics.invInqPulledReasons[Statics.invInqCurrentInq - 1];
                txtInvInqComments.Text = Statics.invInqPulledComments[Statics.invInqCurrentInq - 1];
            }
            else
            {
                Statics.invInqCurrentInq = Statics.invInqListCount;
                lblInvInqResultNum.Text = "Inquiry #: " + Statics.invInqCurrentInq;
                txtInvInqItemNum.Text = Statics.invInqPulledItemNums[Statics.invInqCurrentInq - 1];
                txtInvInqSerialNum.Text = Statics.invInqPulledSerials[Statics.invInqCurrentInq - 1];
                txtInvInqAssetNum.Text = Statics.invInqPulledAssets[Statics.invInqCurrentInq - 1];
                txtInvInqReason.Text = Statics.invInqPulledReasons[Statics.invInqCurrentInq - 1];
                txtInvInqComments.Text = Statics.invInqPulledComments[Statics.invInqCurrentInq - 1];
            }
        }
        private void btnInvInqNext_Click(object sender, EventArgs e)
        {
            if (Statics.invInqCurrentInq != Statics.invInqListCount)
            {
                Statics.invInqCurrentInq++;
                lblInvInqResultNum.Text = "Inquiry #: " + Statics.invInqCurrentInq;
                txtInvInqItemNum.Text = Statics.invInqPulledItemNums[Statics.invInqCurrentInq - 1];
                txtInvInqSerialNum.Text = Statics.invInqPulledSerials[Statics.invInqCurrentInq - 1];
                txtInvInqAssetNum.Text = Statics.invInqPulledAssets[Statics.invInqCurrentInq - 1];
                txtInvInqReason.Text = Statics.invInqPulledReasons[Statics.invInqCurrentInq - 1];
                txtInvInqComments.Text = Statics.invInqPulledComments[Statics.invInqCurrentInq - 1];
            }
            else
            {
                Statics.invInqCurrentInq = 1;
                lblInvInqResultNum.Text = "Inquiry #: " + Statics.invInqCurrentInq;
                txtInvInqItemNum.Text = Statics.invInqPulledItemNums[Statics.invInqCurrentInq - 1];
                txtInvInqSerialNum.Text = Statics.invInqPulledSerials[Statics.invInqCurrentInq - 1];
                txtInvInqAssetNum.Text = Statics.invInqPulledAssets[Statics.invInqCurrentInq - 1];
                txtInvInqReason.Text = Statics.invInqPulledReasons[Statics.invInqCurrentInq - 1];
                txtInvInqComments.Text = Statics.invInqPulledComments[Statics.invInqCurrentInq - 1];
            }
        }
        private void btnInvInqBack_Click(object sender, EventArgs e)
        {
            invInqClear();
            lblInvInqResultCount.Visible = false;
            lblInvInqResultNum.Visible = false;
            btnInvInqNext.Visible = false;
            btnInvInqPrev.Visible = false;
            tabControl1.SelectTab(0);
        }

        //Inventory Inquiry Methods//////////////
        public void invInqSearchFunction()
        {
            string tmpItemNum;
            string tmpSerial;
            string tmpAsset;
            string tmpCEQ;
            string tmpComments;
            Statics.invInqListCount = 0;
            Statics.invInqCurrentInq = 1;
            Statics.invInqPulledItemNums.Clear();
            Statics.invInqPulledSerials.Clear();
            Statics.invInqPulledAssets.Clear();
            Statics.invInqPulledReasons.Clear();
            Statics.invInqPulledComments.Clear();
            using (OleDbConnection conn = new OleDbConnection(Statics.connString))
            {
                string input = txtInvInqSerialNumInput.Text;
                OleDbCommand cmd = new OleDbCommand(
                    "SELECT ItemNumber, SerialNumber, AssetNumber, ATTNum, Comments FROM Inventory WHERE ItemNumber='" + input + "'",
                    conn);

                conn.Open();

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tmpItemNum = reader.GetString(0);
                        tmpSerial = reader.GetString(1);
                        tmpAsset = reader.GetString(2);
                        tmpCEQ = reader.GetString(3);
                        tmpComments = reader.GetString(4);
                        Statics.invInqPulledItemNums.Add(tmpItemNum);
                        Statics.invInqPulledSerials.Add(tmpSerial);
                        Statics.invInqPulledAssets.Add(tmpAsset);
                        Statics.invInqPulledReasons.Add(tmpCEQ);
                        Statics.invInqPulledComments.Add(tmpComments);
                        Statics.invInqListCount++;
                    }
                    lblInvInqResultCount.Text = "Total Results: " + Statics.invInqListCount;
                    lblInvInqResultNum.Text = "Inquiry #: " + Statics.invInqCurrentInq;
                    txtInvInqItemNum.Text = Statics.invInqPulledItemNums[Statics.repInqCurrentInq - 1];
                    txtInvInqSerialNum.Text = Statics.invInqPulledSerials[Statics.repInqCurrentInq - 1];
                    txtInvInqAssetNum.Text = Statics.invInqPulledAssets[Statics.repInqCurrentInq - 1];
                    txtInvInqReason.Text = Statics.invInqPulledReasons[Statics.repInqCurrentInq - 1];
                    txtInvInqComments.Text = Statics.invInqPulledComments[Statics.repInqCurrentInq - 1];

                    if (Statics.invInqListCount > 1)
                    {
                        btnInvInqPrev.Visible = true;
                        btnInvInqNext.Visible = true;
                    }
                    lblInvInqResultCount.Visible = true;
                    lblInvInqResultNum.Visible = true;
                    if (btnInvInqPrev.Visible == true && Statics.repInqListCount == 1)
                    {
                        btnInvInqPrev.Visible = false;
                        btnInvInqNext.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Device not found.");
                }
            }
        }
        public void invInqClear()
        {
            txtInvInqAssetNum.Clear();
            txtInvInqComments.Clear();
            txtInvInqItemNum.Clear();
            txtInvInqReason.Clear();
            txtInvInqSerialNum.Clear();
            txtInvInqSerialNumInput.Clear();
            txtInvInqSerialNumInput.Select();
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

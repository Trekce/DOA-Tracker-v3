using System;
using System.IO;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;

namespace DOA_Tracker_v3
{
    class Statics
    {
        static public string userID = "eckertmi";
        static public string userPW = "Mre2685*";
        static public string SQLConnString = "Server=75.134.205.21;Database=DOA;Uid=" + Statics.userID + ";Pwd=" + Statics.userPW;
        static public DateTime thisDayTmp = DateTime.Today;
        static public string thisDay = thisDayTmp.ToString("d");
        static public DateTime outInspDate;
        static public DateTime outDoaDate;
        static public DateTime outInvDate;
        static public DataTable masterItemList;
        static public int repInqListCount = 0;
        static public int repInqCurrentInq = 1;
        static public int invInqListCount = 0;
        static public int invInqCurrentInq = 1;
        static public List<string> repInqPulledItemNums = new List<string>();
        static public List<string> repInqPulledSerials = new List<string>();
        static public List<string> repInqPulledAssets = new List<string>();
        static public List<string> repInqPulledDateInsp = new List<string>();
        static public List<string> repInqPulledReasons = new List<string>();
        static public List<string> repInqPulledComments = new List<string>();
        static public List<string> invInqPulledItemNums = new List<string>();
        static public List<string> invInqPulledSerials = new List<string>();
        static public List<string> invInqPulledAssets = new List<string>();
        static public List<string> invInqPulledReasons = new List<string>();
        static public List<string> invInqPulledComments = new List<string>();
        static public string[] invOutput = new string[8];
        static public string[] output = new string[10];
        static public string[] prevOutput1 = new string[5] { "N/A", "N/A", "N/A", "N/A", "N/A" };
        static public string[] prevOutput2 = new string[5] { "N/A", "N/A", "N/A", "N/A", "N/A" };
        static public string[] prevOutput3 = new string[5] { "N/A", "N/A", "N/A", "N/A", "N/A" };
        static public string dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static public string dirExecutable = Path.GetDirectoryName(Application.ExecutablePath);
        static public string dirDatabaseFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DOA Tracker\Data\DOA.accdb";
        static public string dirSecureCRTFile = @"C:\Program Files\VanDyke Software\SecureCRT\SecureCRT.exe";
        static public string connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Statics.dirDatabaseFile;
        static public System.Text.StringBuilder errorMessage = new System.Text.StringBuilder();

        static public void getPermissions()
        {
            FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, Statics.dirExecutable + @"\Data\DOA.accdb");
            f2.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, Statics.dirExecutable + @"\Data\DOA.accdb");
            try
            {
                f2.Demand();
            }
            catch (SecurityException s)
            {
                MessageBox.Show(s.Message);
            }
        }
        static public void createDB()
        {
            if (!File.Exists(dirAppData + @"\DOA Tracker\Data\DOA.accdb"))
            {
                if (!Directory.Exists(dirAppData + @"\DOA Tracker\Data"))
                {
                    Directory.CreateDirectory(dirAppData + @"\DOA Tracker\Data");
                }
                string sourceFile = (dirExecutable + @"\Data\DOA.accdb");
                string destinationFile = (dirAppData + @"\DOA Tracker\Data\DOA.accdb");
                System.IO.File.Copy(sourceFile, destinationFile);
            }
        }
        static public DataTable importItemList()
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                string path = dirExecutable + @"\Data\MasterItemList.xlsx";
                DataTable dt = new DataTable();
                conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [MasterItemList$]";
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        conn.Close();
                        conn.Dispose();
                        return dt;
                    }
                }
            }
        }
    }
}

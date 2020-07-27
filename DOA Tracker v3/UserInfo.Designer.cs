namespace DOA_Tracker_v3
{
    partial class UserInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUserInfoClose = new System.Windows.Forms.Button();
            this.btnUserInfoSubmit = new System.Windows.Forms.Button();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.txtPW = new MetroFramework.Controls.MetroTextBox();
            this.btnUserInfoCreateUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUserInfoClose
            // 
            this.btnUserInfoClose.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnUserInfoClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUserInfoClose.FlatAppearance.BorderSize = 2;
            this.btnUserInfoClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserInfoClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfoClose.ForeColor = System.Drawing.Color.White;
            this.btnUserInfoClose.Location = new System.Drawing.Point(181, 164);
            this.btnUserInfoClose.Name = "btnUserInfoClose";
            this.btnUserInfoClose.Size = new System.Drawing.Size(74, 45);
            this.btnUserInfoClose.TabIndex = 5;
            this.btnUserInfoClose.Text = "Close";
            this.btnUserInfoClose.UseVisualStyleBackColor = false;
            this.btnUserInfoClose.Click += new System.EventHandler(this.btnUserInfoClose_Click);
            // 
            // btnUserInfoSubmit
            // 
            this.btnUserInfoSubmit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnUserInfoSubmit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUserInfoSubmit.FlatAppearance.BorderSize = 2;
            this.btnUserInfoSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserInfoSubmit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfoSubmit.ForeColor = System.Drawing.Color.White;
            this.btnUserInfoSubmit.Location = new System.Drawing.Point(21, 164);
            this.btnUserInfoSubmit.Name = "btnUserInfoSubmit";
            this.btnUserInfoSubmit.Size = new System.Drawing.Size(74, 45);
            this.btnUserInfoSubmit.TabIndex = 3;
            this.btnUserInfoSubmit.Text = "Submit";
            this.btnUserInfoSubmit.UseVisualStyleBackColor = false;
            this.btnUserInfoSubmit.Click += new System.EventHandler(this.btnUserInfoSubmit_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.BackColor = System.Drawing.Color.DarkCyan;
            this.metroTile1.Enabled = false;
            this.metroTile1.ForeColor = System.Drawing.Color.White;
            this.metroTile1.Location = new System.Drawing.Point(0, 0);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(277, 50);
            this.metroTile1.TabIndex = 9;
            this.metroTile1.Text = "User Login";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseCustomBackColor = true;
            this.metroTile1.UseCustomForeColor = true;
            this.metroTile1.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // txtID
            // 
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(64, 80);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.ShowClearButton = true;
            this.txtID.Size = new System.Drawing.Size(148, 23);
            this.txtID.TabIndex = 1;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPW
            // 
            // 
            // 
            // 
            this.txtPW.CustomButton.Image = null;
            this.txtPW.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtPW.CustomButton.Name = "";
            this.txtPW.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPW.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPW.CustomButton.TabIndex = 1;
            this.txtPW.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPW.CustomButton.UseSelectable = true;
            this.txtPW.CustomButton.Visible = false;
            this.txtPW.Lines = new string[0];
            this.txtPW.Location = new System.Drawing.Point(64, 129);
            this.txtPW.MaxLength = 32767;
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPW.SelectedText = "";
            this.txtPW.SelectionLength = 0;
            this.txtPW.SelectionStart = 0;
            this.txtPW.ShortcutsEnabled = true;
            this.txtPW.ShowClearButton = true;
            this.txtPW.Size = new System.Drawing.Size(148, 23);
            this.txtPW.TabIndex = 2;
            this.txtPW.UseSelectable = true;
            this.txtPW.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPW.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnUserInfoCreateUser
            // 
            this.btnUserInfoCreateUser.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnUserInfoCreateUser.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUserInfoCreateUser.FlatAppearance.BorderSize = 2;
            this.btnUserInfoCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserInfoCreateUser.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfoCreateUser.ForeColor = System.Drawing.Color.White;
            this.btnUserInfoCreateUser.Location = new System.Drawing.Point(101, 164);
            this.btnUserInfoCreateUser.Name = "btnUserInfoCreateUser";
            this.btnUserInfoCreateUser.Size = new System.Drawing.Size(74, 45);
            this.btnUserInfoCreateUser.TabIndex = 4;
            this.btnUserInfoCreateUser.Text = "Create User";
            this.btnUserInfoCreateUser.UseVisualStyleBackColor = false;
            this.btnUserInfoCreateUser.Click += new System.EventHandler(this.btnUserInfoCreateUser_Click);
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(277, 219);
            this.Controls.Add(this.btnUserInfoCreateUser);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.btnUserInfoSubmit);
            this.Controls.Add(this.btnUserInfoClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUserInfoClose;
        private System.Windows.Forms.Button btnUserInfoSubmit;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroTextBox txtPW;
        private System.Windows.Forms.Button btnUserInfoCreateUser;
    }
}
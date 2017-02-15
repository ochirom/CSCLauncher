namespace CSCLauncher
{
    partial class MainForm
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
            this.PathToClient_CB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxlSearchButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Server_CB = new System.Windows.Forms.ComboBox();
            this.Appname_CB = new System.Windows.Forms.ComboBox();
            this.Cubename_CB = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.Mode_LBL = new System.Windows.Forms.Label();
            this.Mode_CB = new System.Windows.Forms.ComboBox();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.Password_CB = new System.Windows.Forms.ComboBox();
            this.Login_CB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ResultPage = new System.Windows.Forms.TabPage();
            this.CopyCalc_button = new System.Windows.Forms.Button();
            this.Del_button = new System.Windows.Forms.Button();
            this.Log_RTB = new System.Windows.Forms.RichTextBox();
            this.CopyLog_button = new System.Windows.Forms.Button();
            this.Calcs_LV = new System.Windows.Forms.ListView();
            this.Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Calc_RTB = new System.Windows.Forms.RichTextBox();
            this.EssbaseClient_folderBD = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.ResultPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathToClient_CB
            // 
            this.PathToClient_CB.Location = new System.Drawing.Point(165, 33);
            this.PathToClient_CB.Name = "PathToClient_CB";
            this.PathToClient_CB.Size = new System.Drawing.Size(232, 20);
            this.PathToClient_CB.TabIndex = 0;
            this.PathToClient_CB.Text = "C:\\Oracle\\Middleware\\EPMSystem11R1\\products\\Essbase\\EssbaseClient\\bin\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path to EssbaseClient\\bin";
            // 
            // MaxlSearchButton
            // 
            this.MaxlSearchButton.Location = new System.Drawing.Point(403, 31);
            this.MaxlSearchButton.Name = "MaxlSearchButton";
            this.MaxlSearchButton.Size = new System.Drawing.Size(75, 23);
            this.MaxlSearchButton.TabIndex = 2;
            this.MaxlSearchButton.Text = "Choose";
            this.MaxlSearchButton.UseVisualStyleBackColor = true;
            this.MaxlSearchButton.Click += new System.EventHandler(this.MaxlSearchButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "App name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cube name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Login";
            // 
            // Server_CB
            // 
            this.Server_CB.FormattingEnabled = true;
            this.Server_CB.Location = new System.Drawing.Point(165, 84);
            this.Server_CB.Name = "Server_CB";
            this.Server_CB.Size = new System.Drawing.Size(232, 21);
            this.Server_CB.Sorted = true;
            this.Server_CB.TabIndex = 17;
            this.Server_CB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Server_CB_KeyDown);
            // 
            // Appname_CB
            // 
            this.Appname_CB.FormattingEnabled = true;
            this.Appname_CB.Location = new System.Drawing.Point(165, 109);
            this.Appname_CB.Name = "Appname_CB";
            this.Appname_CB.Size = new System.Drawing.Size(232, 21);
            this.Appname_CB.Sorted = true;
            this.Appname_CB.TabIndex = 18;
            this.Appname_CB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Appname_CB_KeyDown);
            // 
            // Cubename_CB
            // 
            this.Cubename_CB.FormattingEnabled = true;
            this.Cubename_CB.Location = new System.Drawing.Point(165, 132);
            this.Cubename_CB.Name = "Cubename_CB";
            this.Cubename_CB.Size = new System.Drawing.Size(232, 21);
            this.Cubename_CB.Sorted = true;
            this.Cubename_CB.TabIndex = 19;
            this.Cubename_CB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cubename_CB_KeyDown);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(400, 87);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(14, 13);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(400, 112);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(14, 13);
            this.linkLabel2.TabIndex = 23;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "X";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(400, 135);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(14, 13);
            this.linkLabel3.TabIndex = 24;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "X";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(400, 160);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(14, 13);
            this.linkLabel4.TabIndex = 25;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "X";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.SettingsPage);
            this.tabControl1.Controls.Add(this.ResultPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 545);
            this.tabControl1.TabIndex = 27;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.Mode_LBL);
            this.SettingsPage.Controls.Add(this.Mode_CB);
            this.SettingsPage.Controls.Add(this.linkLabel5);
            this.SettingsPage.Controls.Add(this.PathToClient_CB);
            this.SettingsPage.Controls.Add(this.linkLabel4);
            this.SettingsPage.Controls.Add(this.label1);
            this.SettingsPage.Controls.Add(this.linkLabel3);
            this.SettingsPage.Controls.Add(this.MaxlSearchButton);
            this.SettingsPage.Controls.Add(this.linkLabel2);
            this.SettingsPage.Controls.Add(this.label2);
            this.SettingsPage.Controls.Add(this.linkLabel1);
            this.SettingsPage.Controls.Add(this.label3);
            this.SettingsPage.Controls.Add(this.Password_CB);
            this.SettingsPage.Controls.Add(this.label4);
            this.SettingsPage.Controls.Add(this.Login_CB);
            this.SettingsPage.Controls.Add(this.label5);
            this.SettingsPage.Controls.Add(this.Cubename_CB);
            this.SettingsPage.Controls.Add(this.label6);
            this.SettingsPage.Controls.Add(this.Appname_CB);
            this.SettingsPage.Controls.Add(this.Server_CB);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(619, 519);
            this.SettingsPage.TabIndex = 0;
            this.SettingsPage.Text = "Settings";
            this.SettingsPage.UseVisualStyleBackColor = true;
            // 
            // Mode_LBL
            // 
            this.Mode_LBL.AutoSize = true;
            this.Mode_LBL.Location = new System.Drawing.Point(34, 61);
            this.Mode_LBL.Name = "Mode_LBL";
            this.Mode_LBL.Size = new System.Drawing.Size(34, 13);
            this.Mode_LBL.TabIndex = 28;
            this.Mode_LBL.Text = "Mode";
            // 
            // Mode_CB
            // 
            this.Mode_CB.Items.AddRange(new object[] {
            "EssCMD",
            "MaxL"});
            this.Mode_CB.Location = new System.Drawing.Point(165, 58);
            this.Mode_CB.Name = "Mode_CB";
            this.Mode_CB.Size = new System.Drawing.Size(232, 21);
            this.Mode_CB.Sorted = true;
            this.Mode_CB.TabIndex = 27;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(400, 184);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(14, 13);
            this.linkLabel5.TabIndex = 26;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "X";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // Password_CB
            // 
            this.Password_CB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Password_CB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Password_CB.FormattingEnabled = true;
            this.Password_CB.Location = new System.Drawing.Point(165, 181);
            this.Password_CB.Name = "Password_CB";
            this.Password_CB.Size = new System.Drawing.Size(232, 21);
            this.Password_CB.Sorted = true;
            this.Password_CB.TabIndex = 21;
            this.Password_CB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_CB_KeyDown);
            // 
            // Login_CB
            // 
            this.Login_CB.FormattingEnabled = true;
            this.Login_CB.Location = new System.Drawing.Point(165, 157);
            this.Login_CB.Name = "Login_CB";
            this.Login_CB.Size = new System.Drawing.Size(232, 21);
            this.Login_CB.Sorted = true;
            this.Login_CB.TabIndex = 20;
            this.Login_CB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_CB_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password";
            // 
            // ResultPage
            // 
            this.ResultPage.Controls.Add(this.CopyCalc_button);
            this.ResultPage.Controls.Add(this.Del_button);
            this.ResultPage.Controls.Add(this.Log_RTB);
            this.ResultPage.Controls.Add(this.CopyLog_button);
            this.ResultPage.Controls.Add(this.Calcs_LV);
            this.ResultPage.Controls.Add(this.Calc_RTB);
            this.ResultPage.Location = new System.Drawing.Point(4, 22);
            this.ResultPage.Name = "ResultPage";
            this.ResultPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResultPage.Size = new System.Drawing.Size(619, 519);
            this.ResultPage.TabIndex = 1;
            this.ResultPage.Text = "Result";
            this.ResultPage.UseVisualStyleBackColor = true;
            // 
            // CopyCalc_button
            // 
            this.CopyCalc_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyCalc_button.Location = new System.Drawing.Point(538, 219);
            this.CopyCalc_button.Name = "CopyCalc_button";
            this.CopyCalc_button.Size = new System.Drawing.Size(75, 23);
            this.CopyCalc_button.TabIndex = 20;
            this.CopyCalc_button.Text = "Copy calc";
            this.CopyCalc_button.UseVisualStyleBackColor = true;
            this.CopyCalc_button.Click += new System.EventHandler(this.CopyCalc_button_Click);
            // 
            // Del_button
            // 
            this.Del_button.Location = new System.Drawing.Point(203, 6);
            this.Del_button.Name = "Del_button";
            this.Del_button.Size = new System.Drawing.Size(42, 23);
            this.Del_button.TabIndex = 19;
            this.Del_button.Text = "Del";
            this.Del_button.UseVisualStyleBackColor = true;
            this.Del_button.Click += new System.EventHandler(this.Del_button_Click);
            // 
            // Log_RTB
            // 
            this.Log_RTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_RTB.Location = new System.Drawing.Point(6, 248);
            this.Log_RTB.Name = "Log_RTB";
            this.Log_RTB.ReadOnly = true;
            this.Log_RTB.Size = new System.Drawing.Size(607, 235);
            this.Log_RTB.TabIndex = 18;
            this.Log_RTB.Text = "";
            this.Log_RTB.WordWrap = false;
            // 
            // CopyLog_button
            // 
            this.CopyLog_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyLog_button.Location = new System.Drawing.Point(538, 489);
            this.CopyLog_button.Name = "CopyLog_button";
            this.CopyLog_button.Size = new System.Drawing.Size(75, 23);
            this.CopyLog_button.TabIndex = 17;
            this.CopyLog_button.Text = "Copy log";
            this.CopyLog_button.UseVisualStyleBackColor = true;
            this.CopyLog_button.Click += new System.EventHandler(this.CopyLog_button_Click);
            // 
            // Calcs_LV
            // 
            this.Calcs_LV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Num,
            this.Status,
            this.Time});
            this.Calcs_LV.GridLines = true;
            this.Calcs_LV.Location = new System.Drawing.Point(6, 6);
            this.Calcs_LV.Name = "Calcs_LV";
            this.Calcs_LV.Size = new System.Drawing.Size(191, 207);
            this.Calcs_LV.TabIndex = 2;
            this.Calcs_LV.UseCompatibleStateImageBehavior = false;
            this.Calcs_LV.View = System.Windows.Forms.View.Details;
            this.Calcs_LV.SelectedIndexChanged += new System.EventHandler(this.Calcs_LV_SelectedIndexChanged);
            // 
            // Num
            // 
            this.Num.Text = "Num";
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // Time
            // 
            this.Time.Text = "Time";
            // 
            // Calc_RTB
            // 
            this.Calc_RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Calc_RTB.Location = new System.Drawing.Point(274, 6);
            this.Calc_RTB.Name = "Calc_RTB";
            this.Calc_RTB.ReadOnly = true;
            this.Calc_RTB.Size = new System.Drawing.Size(339, 207);
            this.Calc_RTB.TabIndex = 0;
            this.Calc_RTB.Text = "";
            this.Calc_RTB.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 578);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "CSCLauncher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            this.ResultPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox PathToClient_CB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MaxlSearchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Server_CB;
        private System.Windows.Forms.ComboBox Appname_CB;
        private System.Windows.Forms.ComboBox Cubename_CB;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.TabPage ResultPage;
        private System.Windows.Forms.ListView Calcs_LV;
        private System.Windows.Forms.ColumnHeader Num;
        private System.Windows.Forms.RichTextBox Calc_RTB;
        private System.Windows.Forms.RichTextBox Log_RTB;
        private System.Windows.Forms.Button CopyLog_button;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Button Del_button;
        private System.Windows.Forms.Button CopyCalc_button;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.ComboBox Password_CB;
        private System.Windows.Forms.ComboBox Login_CB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Mode_CB;
        private System.Windows.Forms.Label Mode_LBL;
        private System.Windows.Forms.FolderBrowserDialog EssbaseClient_folderBD;
    }
}


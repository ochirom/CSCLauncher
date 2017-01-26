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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.PathToMaxlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxlSearchButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.ResultPage = new System.Windows.Forms.TabPage();
            this.Log_RTB = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Calcs_LV = new System.Windows.Forms.ListView();
            this.Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Code_RTB = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.ResultPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "CSCLauncher";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // PathToMaxlTextBox
            // 
            this.PathToMaxlTextBox.Location = new System.Drawing.Point(149, 33);
            this.PathToMaxlTextBox.Name = "PathToMaxlTextBox";
            this.PathToMaxlTextBox.Size = new System.Drawing.Size(232, 20);
            this.PathToMaxlTextBox.TabIndex = 0;
            this.PathToMaxlTextBox.Text = "C:\\Oracle\\Middleware\\EPMSystem11R1\\products\\Essbase\\EssbaseClient\\bin\\startMaxl.c" +
    "md";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path to startMaxl.cmd";
            // 
            // MaxlSearchButton
            // 
            this.MaxlSearchButton.Location = new System.Drawing.Point(387, 31);
            this.MaxlSearchButton.Name = "MaxlSearchButton";
            this.MaxlSearchButton.Size = new System.Drawing.Size(75, 23);
            this.MaxlSearchButton.TabIndex = 2;
            this.MaxlSearchButton.Text = "Choose";
            this.MaxlSearchButton.UseVisualStyleBackColor = true;
            this.MaxlSearchButton.Click += new System.EventHandler(this.MaxlSearchButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "App name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cube name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "STATUS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "READY";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(149, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(232, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 17;
            this.comboBox1.Text = "mow03-hyp01dl";
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(149, 81);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(232, 21);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 18;
            this.comboBox2.Text = "Console";
            this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox2_KeyDown);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(149, 104);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(232, 21);
            this.comboBox3.Sorted = true;
            this.comboBox3.TabIndex = 19;
            this.comboBox3.Text = "Console";
            this.comboBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox3_KeyDown);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(149, 129);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(232, 21);
            this.comboBox4.Sorted = true;
            this.comboBox4.TabIndex = 20;
            this.comboBox4.Text = "admin";
            this.comboBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox4_KeyDown);
            // 
            // comboBox5
            // 
            this.comboBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(149, 153);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(232, 21);
            this.comboBox5.Sorted = true;
            this.comboBox5.TabIndex = 21;
            this.comboBox5.Text = "Welcome1";
            this.comboBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox5_KeyDown);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(384, 59);
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
            this.linkLabel2.Location = new System.Drawing.Point(384, 84);
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
            this.linkLabel3.Location = new System.Drawing.Point(384, 107);
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
            this.linkLabel4.Location = new System.Drawing.Point(384, 132);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(14, 13);
            this.linkLabel4.TabIndex = 25;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "X";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(384, 156);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(14, 13);
            this.linkLabel5.TabIndex = 26;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "X";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // tabControl1
            // 
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
            this.SettingsPage.Controls.Add(this.linkLabel5);
            this.SettingsPage.Controls.Add(this.PathToMaxlTextBox);
            this.SettingsPage.Controls.Add(this.linkLabel4);
            this.SettingsPage.Controls.Add(this.label1);
            this.SettingsPage.Controls.Add(this.linkLabel3);
            this.SettingsPage.Controls.Add(this.MaxlSearchButton);
            this.SettingsPage.Controls.Add(this.linkLabel2);
            this.SettingsPage.Controls.Add(this.label2);
            this.SettingsPage.Controls.Add(this.linkLabel1);
            this.SettingsPage.Controls.Add(this.label3);
            this.SettingsPage.Controls.Add(this.comboBox5);
            this.SettingsPage.Controls.Add(this.label4);
            this.SettingsPage.Controls.Add(this.comboBox4);
            this.SettingsPage.Controls.Add(this.label5);
            this.SettingsPage.Controls.Add(this.comboBox3);
            this.SettingsPage.Controls.Add(this.label6);
            this.SettingsPage.Controls.Add(this.comboBox2);
            this.SettingsPage.Controls.Add(this.label7);
            this.SettingsPage.Controls.Add(this.comboBox1);
            this.SettingsPage.Controls.Add(this.label8);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(619, 519);
            this.SettingsPage.TabIndex = 0;
            this.SettingsPage.Text = "Settings";
            this.SettingsPage.UseVisualStyleBackColor = true;
            // 
            // ResultPage
            // 
            this.ResultPage.Controls.Add(this.Log_RTB);
            this.ResultPage.Controls.Add(this.button1);
            this.ResultPage.Controls.Add(this.Calcs_LV);
            this.ResultPage.Controls.Add(this.Code_RTB);
            this.ResultPage.Location = new System.Drawing.Point(4, 22);
            this.ResultPage.Name = "ResultPage";
            this.ResultPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResultPage.Size = new System.Drawing.Size(619, 519);
            this.ResultPage.TabIndex = 1;
            this.ResultPage.Text = "Result";
            this.ResultPage.UseVisualStyleBackColor = true;
            // 
            // Log_RTB
            // 
            this.Log_RTB.Location = new System.Drawing.Point(6, 248);
            this.Log_RTB.Name = "Log_RTB";
            this.Log_RTB.ReadOnly = true;
            this.Log_RTB.Size = new System.Drawing.Size(607, 235);
            this.Log_RTB.TabIndex = 18;
            this.Log_RTB.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
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
            // Code_RTB
            // 
            this.Code_RTB.Location = new System.Drawing.Point(254, 6);
            this.Code_RTB.Name = "Code_RTB";
            this.Code_RTB.ReadOnly = true;
            this.Code_RTB.Size = new System.Drawing.Size(359, 207);
            this.Code_RTB.TabIndex = 0;
            this.Code_RTB.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 578);
            this.Controls.Add(this.tabControl1);
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

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox PathToMaxlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MaxlSearchButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.TabPage ResultPage;
        private System.Windows.Forms.ListView Calcs_LV;
        private System.Windows.Forms.ColumnHeader Num;
        private System.Windows.Forms.RichTextBox Code_RTB;
        private System.Windows.Forms.RichTextBox Log_RTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Time;
    }
}


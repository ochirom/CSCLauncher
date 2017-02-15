﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace CSCLauncher
{
    public partial class MainForm : Form
    {
        /*Code for text capture */
        [DllImport("user32.dll")]
        static extern int GetFocus();

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(int hWnd, int ProcessId);

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern int SendMessage(int hWnd, int Msg, int wParam, StringBuilder lParam);

        // second overload of SendMessage

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, out int wParam, out int lParam);

        const int WM_SETTEXT = 12;
        const int WM_GETTEXT = 13;

        private Hotkeys.GlobalHotkey ghk;
        private List<Calculation> Calcs = new List<Calculation>();
        private int cnt;

        public MainForm()
        {
            InitializeComponent();
            ghk = new Hotkeys.GlobalHotkey(Hotkeys.Constants.ALT, Keys.L, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ghk.Register();
            cnt = 0;
            LoadSettings();
            CreateFolders();
            
        }

        private void CreateFolders()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Logs"))
            {
                try
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Log");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Folders creation failed: {0}", e.ToString());
                }
            }
        }

        private void HandleHotkey()
        {
            /*Actions to get the code from Notepad*/
            StringBuilder builder = new StringBuilder(1000000);

            int foregroundWindowHandle = GetForegroundWindow();
            uint remoteThreadId = GetWindowThreadProcessId(foregroundWindowHandle, 0);
            uint currentThreadId = GetCurrentThreadId();

            //AttachTrheadInput is needed so we can get the handle of a focused window in another app
            AttachThreadInput(remoteThreadId, currentThreadId, true);
            //Get the handle of a focused window
            int focused = GetFocus();
            //Now detach since we got the focused handle
            AttachThreadInput(remoteThreadId, currentThreadId, false);
            //Get the text from the active window into the stringbuilder
            SendMessage(focused, WM_GETTEXT, builder.Capacity, builder);

            this.Activate();
            this.Show();
            //this.WindowState = FormWindowState.Normal;
            DialogResult RunCalcDialog = MessageBox.Show("Run calc script?", "Are you sure?", MessageBoxButtons.YesNo);
            if (RunCalcDialog == DialogResult.Yes)
            {
                cnt++;

                if (Mode_CB.SelectedIndex == 0) //If turned on EssCMD mode
                    Calcs.Add(new EssCMDCalculation(builder.ToString(), PathToClient_CB.Text, Server_CB.Text, Appname_CB.Text, Cubename_CB.Text, Login_CB.Text, Password_CB.Text));
                else //MaxL mode
                    Calcs.Add(new MaxlCalculation(builder.ToString(), PathToClient_CB.Text, Server_CB.Text, Appname_CB.Text, Cubename_CB.Text, Login_CB.Text, Password_CB.Text));


                Calcs_LV.Items.Add(new ListViewItem(cnt.ToString()));
                Calcs_LV.Items[Calcs_LV.Items.Count - 1].SubItems.Add("Running");
                Calcs_LV.Items[Calcs_LV.Items.Count - 1].SubItems.Add("-");

                BackgroundWorker bw = new BackgroundWorker();

                // turn on progress reporting
                bw.WorkerReportsProgress = true;

                // background thread work
                bw.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;
                    // run calculation
                    Calcs[Calcs.Count - 1].Execute();
                    
                });

                // Job complete handler
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate (object o, RunWorkerCompletedEventArgs args)
                {
                    if (Calcs_LV.SelectedItems.Count > 0)
                    {
                        Log_RTB.Text = Calcs[Convert.ToInt32(Calcs_LV.SelectedItems[0].Text) - 1].log;
                    }

                    foreach (ListViewItem lvi in Calcs_LV.Items)
                    {
                        lvi.SubItems[1].Text = Calcs[Convert.ToInt32(lvi.SubItems[0].Text) - 1].status;
                        lvi.SubItems[2].Text = Calcs[Convert.ToInt32(lvi.SubItems[0].Text) - 1].time;
                    }
                });

                bw.RunWorkerAsync();
                tabControl1.SelectTab(1);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void MaxlSearchButton_Click(object sender, EventArgs e)
        {
            if (EssbaseClient_folderBD.ShowDialog() == DialogResult.OK)
            {
                PathToClient_CB.Text = EssbaseClient_folderBD.SelectedPath;
            }
        }


        private void CopyLog_button_Click(object sender, EventArgs e)
        {
            if (Log_RTB.Text != null)
                Clipboard.SetText(Log_RTB.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArrayList serverlist = new ArrayList(this.Server_CB.Items);
            ArrayList applist = new ArrayList(this.Appname_CB.Items);
            ArrayList cubelist = new ArrayList(this.Cubename_CB.Items);
            ArrayList loginlist = new ArrayList(this.Login_CB.Items);
            ArrayList passwordlist = new ArrayList(this.Password_CB.Items);
            Properties.Settings.Default.Server = serverlist;
            Properties.Settings.Default.App = applist;
            Properties.Settings.Default.Cube = cubelist;
            Properties.Settings.Default.Login = loginlist ;
            Properties.Settings.Default.Password = passwordlist;
            Properties.Settings.Default.ClientPath = PathToClient_CB.Text;
            Properties.Settings.Default.Mode = Mode_CB.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        private void LoadSettings()
        {
            if (Properties.Settings.Default.Server != null)
            {
                this.Server_CB.Items.AddRange(Properties.Settings.Default.Server.ToArray());
            }
            if (Properties.Settings.Default.App != null)
            {
                this.Appname_CB.Items.AddRange(Properties.Settings.Default.App.ToArray());
            }
            if (Properties.Settings.Default.Cube != null)
            {
                this.Cubename_CB.Items.AddRange(Properties.Settings.Default.Cube.ToArray());
            }
            if (Properties.Settings.Default.Login != null)
            { 
                this.Login_CB.Items.AddRange(Properties.Settings.Default.Login.ToArray());
            }
            if (Properties.Settings.Default.Password != null)
            { 
                this.Password_CB.Items.AddRange(Properties.Settings.Default.Password.ToArray());
            }
            if (Properties.Settings.Default.ClientPath != null)
            {
                PathToClient_CB.Text = Properties.Settings.Default.ClientPath;
            }

            Mode_CB.SelectedIndex = Properties.Settings.Default.Mode;
        }

        private void Server_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!Server_CB.Items.Contains(Server_CB.Text) && Server_CB.Text != "")
                    Server_CB.Items.Add(Server_CB.Text);
        }

        private void Appname_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!Appname_CB.Items.Contains(Appname_CB.Text) && Appname_CB.Text != "")
                Appname_CB.Items.Add(Appname_CB.Text);
        }

        private void Cubename_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!Cubename_CB.Items.Contains(Cubename_CB.Text) && Cubename_CB.Text != "")
                Cubename_CB.Items.Add(Cubename_CB.Text);
        }

        private void Login_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!Login_CB.Items.Contains(Login_CB.Text) && Login_CB.Text != "")
                Login_CB.Items.Add(Login_CB.Text);
        }

        private void Password_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!Password_CB.Items.Contains(Password_CB.Text) && Password_CB.Text != "")
                Password_CB.Items.Add(Password_CB.Text);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Server_CB.Text != "")
            { 
                Server_CB.Items.Remove(Server_CB.SelectedItem);
                Server_CB.Text = "";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Appname_CB.Text != "")
                Appname_CB.Items.Remove(Appname_CB.SelectedItem);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Cubename_CB.Text != "")
                Cubename_CB.Items.Remove(Cubename_CB.SelectedItem);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Login_CB.Text != "")
                Login_CB.Items.Remove(Login_CB.SelectedItem);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Password_CB.Text != "")
                Password_CB.Items.Remove(Password_CB.SelectedItem);
        }

        private void Calcs_LV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Calcs_LV.SelectedItems.Count > 0)
            {
                Calc_RTB.Text = Calcs[Convert.ToInt32(Calcs_LV.SelectedItems[0].Text) - 1].calcscript;
                Log_RTB.Text = Calcs[Convert.ToInt32(Calcs_LV.SelectedItems[0].Text) - 1].log;
            }
            else
            {
                Calc_RTB.Text = "";
                Log_RTB.Text = "";
            }

        }

        private void Del_button_Click(object sender, EventArgs e)
        {
            if (Calcs_LV.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in Calcs_LV.SelectedItems)
                    lvi.Remove();
            }
        }

        private void CopyCalc_button_Click(object sender, EventArgs e)
        {
            if (Calc_RTB.Text != null)
                Clipboard.SetText(Calc_RTB.Text);
        }
    }

}
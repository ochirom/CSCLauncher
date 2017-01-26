using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Hotkeys;
using System.Diagnostics;

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
            ghk = new Hotkeys.GlobalHotkey(Constants.ALT, Keys.L, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ghk.Register();
            cnt = 0;
            LoadSettings();
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

                Calcs.Add(new Calculation(builder.ToString(), cnt, PathToMaxlTextBox.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text));
                
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
                    Calcs[Calcs.Count - 1].Execute_Maxl();
                });

                // Job complete handler
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate (object o, RunWorkerCompletedEventArgs args)
                {
                    if (Calcs_LV.SelectedItems.Count > 0)
                        Log_RTB.Text = Calcs[Convert.ToInt32(Calcs_LV.SelectedItems[0].Text) - 1].log;

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
            openFileDialog1.Filter = "CMD File | *.cmd";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathToMaxlTextBox.Text = openFileDialog1.FileName;
            }
        }


        private void CopyLog_button_Click(object sender, EventArgs e)
        {
            if (Log_RTB.Text != null)
                Clipboard.SetText(Log_RTB.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArrayList serverlist = new ArrayList(this.comboBox1.Items);
            ArrayList applist = new ArrayList(this.comboBox2.Items);
            ArrayList cubelist = new ArrayList(this.comboBox3.Items);
            ArrayList loginlist = new ArrayList(this.comboBox4.Items);
            ArrayList passwordlist = new ArrayList(this.comboBox5.Items);
            Properties.Settings.Default.Server = serverlist;
            Properties.Settings.Default.App = applist;
            Properties.Settings.Default.Cube = cubelist;
            Properties.Settings.Default.Login = loginlist ;
            Properties.Settings.Default.Password = passwordlist;
            Properties.Settings.Default.StartMaxlPath = PathToMaxlTextBox.Text;
            Properties.Settings.Default.Save();
        }
        private void LoadSettings()
        {
            if (Properties.Settings.Default.Server != null)
            {
                this.comboBox1.Items.AddRange(Properties.Settings.Default.Server.ToArray());
                //this.comboBox1.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.App != null)
            {
                this.comboBox2.Items.AddRange(Properties.Settings.Default.App.ToArray());
                //this.comboBox2.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.Cube != null)
            {
                this.comboBox3.Items.AddRange(Properties.Settings.Default.Cube.ToArray());
                //this.comboBox3.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.Login != null)
            { 
                this.comboBox4.Items.AddRange(Properties.Settings.Default.Login.ToArray());
                //this.comboBox4.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.Password != null)
            { 
                this.comboBox5.Items.AddRange(Properties.Settings.Default.Password.ToArray());
                //this.comboBox5.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.StartMaxlPath != null)
            {
                PathToMaxlTextBox.Text = Properties.Settings.Default.StartMaxlPath;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!comboBox1.Items.Contains(comboBox1.Text) && comboBox1.Text != "")
                    comboBox1.Items.Add(comboBox1.Text);
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!comboBox2.Items.Contains(comboBox2.Text) && comboBox2.Text != "")
                comboBox2.Items.Add(comboBox2.Text);
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!comboBox3.Items.Contains(comboBox3.Text) && comboBox3.Text != "")
                comboBox3.Items.Add(comboBox3.Text);
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!comboBox4.Items.Contains(comboBox4.Text) && comboBox4.Text != "")
                comboBox4.Items.Add(comboBox4.Text);
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!comboBox5.Items.Contains(comboBox5.Text) && comboBox5.Text != "")
                comboBox5.Items.Add(comboBox5.Text);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox1.Text != "")
            { 
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                comboBox1.Text = "";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox2.Text != "")
                comboBox2.Items.Remove(comboBox2.SelectedItem);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox3.Text != "")
                comboBox3.Items.Remove(comboBox3.SelectedItem);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox4.Text != "")
                comboBox4.Items.Remove(comboBox4.SelectedItem);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox5.Text != "")
                comboBox5.Items.Remove(comboBox5.SelectedItem);
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
    public class Calculation
    {
        public string calcscript;
        private int id;
        public string log;
        public string status;
        public string time;
        private string PathToMaxl;
        private string server;
        private string appname;
        private string cubename;
        private string login;
        private string password;

        public Calculation(string calcscript, int cnt, string PathToMaxl, string server,string appname, string cubename, string login, string password)
        {
            
            this.calcscript = calcscript;
            this.id = cnt;
            this.PathToMaxl = PathToMaxl;
            this.server = server;
            this.appname = appname;
            this.cubename = cubename;
            this.login = login;
            this.password = password;
        }

        public void Execute_Maxl()
        {
            Create_MaxL_Template();
            string command = "call " + PathToMaxl + @" """ + AppDomain.CurrentDomain.BaseDirectory + @"\filled_template" + id + @".mxl""";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            this.log = cmd.StandardOutput.ReadToEnd();
            Check_Status();


        }

        private void Create_MaxL_Template()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\template.mxl");
            string content = reader.ReadToEnd();
            reader.Close();
            content = content.Replace(@"$admin$", login);
            content = content.Replace(@"$password$", password);
            content = content.Replace(@"$server$", server);
            content = content.Replace(@"$appname$", appname);
            content = content.Replace(@"$cubename$", cubename);
            /*Del comments from code*/
            content = content.Replace(@"$calcscript$", Regex.Replace(calcscript, @"(?s)\s*\/\/.+?\n|\/\*.*?\*\/\s*", String.Empty));

            StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\filled_template"+ id + ".mxl", false, Encoding.UTF8);
            writer.Write(content);
            writer.Close();
        }

        private void Check_Status()
        {
            if (log.Contains("Calculation executed"))
            {
                this.status = "Success";
                Match calctime = Regex.Match(log, @"Total Calc Elapsed Time : \[.*\] seconds.");
                if (calctime.Success)
                {
                    this.time = Regex.Match(calctime.Value, @"\[(.*)\]").Value;
                }
            }
            else
            {
                this.status = "Error";
            }
        }
    }
}



    namespace Hotkeys
{
    public class GlobalHotkey
    {
        private int modifier;
        private int key;
        private IntPtr hWnd;
        private int id;

        public GlobalHotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }

        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    public static class Constants
    {
        //modifiers
        public const int NOMOD = 0x0000;
        public const int ALT = 0x0001;
        public const int CTRL = 0x0002;
        public const int SHIFT = 0x0004;
        public const int WIN = 0x0008;

        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }


}

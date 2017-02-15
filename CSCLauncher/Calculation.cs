using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace CSCLauncher
{
    public class Calculation
    {
        public string calcscript;
        public string log;
        public string status;
        public string time;
        protected string PathToClient;
        protected string server;
        protected string appname;
        protected string cubename;
        protected string login;
        protected string password;

        public Calculation(string calcscript, string PathToClient, string server, string appname, string cubename, string login, string password)
        {

            this.calcscript = calcscript;
            this.PathToClient = PathToClient;
            this.server = server;
            this.appname = appname;
            this.cubename = cubename;
            this.login = login;
            this.password = password;
            this.log = "";
            this.status = "";
            this.time = "";
        }

        public virtual void Execute() {}

        //public virtual void Create_Template() {}

        //public virtual void Check_Status() {}
    }

    public class MaxlCalculation : Calculation
    {
        public MaxlCalculation(string calcscript, string PathToClient, string server, string appname, string cubename, string login, string password):base(calcscript, PathToClient, server, appname, cubename, login, password) { }

        public override void Execute()
        {
            string filename = DateTime.Now.ToString("yyyyMMdd_HHmmssf");

            Process cmd = new Process();
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            Create_Template(filename);

            cmd.StartInfo.FileName = PathToClient + @"\startMaxl.cmd";
            cmd.StartInfo.Arguments = @" """ + AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + @".mxl""";
            cmd.Start();
            this.log = cmd.StandardOutput.ReadToEnd();
            cmd.Close();

            Check_Status();

            //Write log to file
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".log", false, Encoding.UTF8))
            {
                writer.Write(this.log);
            }
        }

        private void Create_Template(string filename)
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Template\maxl_template.mxl");
            
            string content = reader.ReadToEnd();
            reader.Close();
            content = content.Replace(@"$admin$", login);
            content = content.Replace(@"$password$", password);
            content = content.Replace(@"$server$", server);
            content = content.Replace(@"$appname$", appname);
            content = content.Replace(@"$cubename$", cubename);
            /*Del comments from code*/
            content = content.Replace(@"$calcscript$", Regex.Replace(calcscript, @"(?s)\s*\/\/.+?\n|\/\*.*?\*\/\s*", String.Empty));

            StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".mxl", false, Encoding.UTF8);
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
                this.time = "-";
            }
        }
    }


    public class EssCMDCalculation : Calculation
    {
        public EssCMDCalculation(string calcscript, string PathToClient, string server, string appname, string cubename, string login, string password) : base(calcscript, PathToClient, server, appname, cubename, login, password) { }

        public override void Execute()
        {
            string filename = DateTime.Now.ToString("yyyyMMdd_HHmmssf");

            Process cmd = new Process();
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            Create_Template(filename);

            cmd.StartInfo.FileName = PathToClient + @"\startEsscmd.cmd";
            cmd.StartInfo.Arguments = @" """ + AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + @".escr""";

            cmd.Start();
            cmd.Close();


            //Place to think about - EssCMD need time to write log file
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".log"))
                Thread.Sleep(1000);

            try
            {
                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".log"))
                {
                    this.log = reader.ReadToEnd();
                }
            }
            catch
            {
                Thread.Sleep(1000);
                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".log"))
                {
                    this.log = reader.ReadToEnd();
                }
            }

            Check_Status();
        }

        private void Create_Template(string filename)
        {
            string content = "";
            using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Template\esscmd_template.escr"))
            {
                content = reader.ReadToEnd();
            }

            content = content.Replace(@"$admin$", login);
            content = content.Replace(@"$password$", password);
            content = content.Replace(@"$server$", server);
            content = content.Replace(@"$appname$", appname);
            content = content.Replace(@"$cubename$", cubename);
            content = content.Replace(@"$calcfile$", @"""" + AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + @".csc""");
            content = content.Replace(@"$logfile$", @"""" + AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + @".log""");

            //esscmd script creation
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".escr", false, Encoding.ASCII))
            {
                writer.Write(content);
            }

            //calcscript file creation
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".csc", false, Encoding.ASCII))
            {
                writer.Write(calcscript);
            }

        }

        private void Check_Status()
        {
            if (this.log.Contains("Total Calc Elapsed"))
            {
                this.status = "Success";
                Match calctime = Regex.Match(log, @"Total Calc Elapsed Time .* : \[.*\] seconds.");
                if (calctime.Success)
                {
                    this.time = Regex.Match(calctime.Value, @"\[([0-9\.].*)\]").Value;
                }
            }
            else
            {
                this.status = "Error";
                this.time = "-";
            }
        }
    }
}
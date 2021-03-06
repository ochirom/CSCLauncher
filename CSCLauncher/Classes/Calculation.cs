﻿using System;
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
        protected ConnectionData credentials = new ConnectionData();

        public Calculation(string calcscript, string PathToClient, ConnectionData credentials)
        {

            this.calcscript = calcscript;
            this.PathToClient = PathToClient;
            this.credentials.server = credentials.server;
            this.credentials.appname = credentials.appname;
            this.credentials.cubename = credentials.cubename;
            this.credentials.login = credentials.login;
            this.credentials.password = credentials.password;
            this.log = "";
            this.status = "Running";
            this.time = "-";
        }

        public virtual void Execute() {}

    }

    public class MaxlCalculation : Calculation
    {
        public MaxlCalculation(string calcscript, string PathToClient, ConnectionData credentials) :base(calcscript, PathToClient, credentials) { }

        public override void Execute()
        {
            string filename = DateTime.Now.ToString("yyyyMMdd_HHmmssf")
                + "_" + credentials.appname + "_" + credentials.cubename;

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
            content = content.Replace(@"$admin$", credentials.login);
            content = content.Replace(@"$password$", credentials.password);
            content = content.Replace(@"$server$", credentials.server);
            content = content.Replace(@"$appname$", credentials.appname);
            content = content.Replace(@"$cubename$", credentials.cubename);
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
        public EssCMDCalculation(string calcscript, string PathToClient, ConnectionData credentials) : base(calcscript, PathToClient, credentials) { }

        public override void Execute()
        {
            string filename = DateTime.Now.ToString("yyyyMMdd_HHmmssf")
                + "_" + credentials.appname + "_" + credentials.cubename;

            Process cmd = new Process();
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            Create_Template(filename);

            cmd.StartInfo.FileName = PathToClient + "\\startEsscmd.cmd";
            cmd.StartInfo.Arguments = @" """ + AppDomain.CurrentDomain.BaseDirectory + @"Log\" + filename + @".escr""";
            cmd.Start();
            cmd.WaitForExit();
            cmd.Close();

            string logfile = AppDomain.CurrentDomain.BaseDirectory + @"Log\" + filename + ".log";

            try
            {
                using (StreamReader reader = new StreamReader(logfile))
                {
                    this.log = reader.ReadToEnd();
                }
            }
            catch
            {
                MessageBox.Show("Can't open log file");
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

            content = content.Replace(@"$admin$", credentials.login);
            content = content.Replace(@"$password$", credentials.password);
            content = content.Replace(@"$server$", credentials.server);
            content = content.Replace(@"$appname$", credentials.appname);
            content = content.Replace(@"$cubename$", credentials.cubename);
            content = content.Replace(@"$calcfile$", @"""" + AppDomain.CurrentDomain.BaseDirectory + @"Log\" + filename + @".csc""");
            content = content.Replace(@"$logfile$", @"""" + AppDomain.CurrentDomain.BaseDirectory + @"Log\" + filename + @".log""");

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

            //File.Create(AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + filename + ".log");

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
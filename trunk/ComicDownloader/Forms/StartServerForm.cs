using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using NetduinoLibrary.Toolbox;
using System.IO;
using Cx.Windows.Forms;
using ExtendedWebBrowser2;

namespace ComicDownloader.Forms
{
    public partial class StartServerForm : MdiChildForm
    {
        public StartServerForm()
        {
            InitializeComponent();
        }

        private void bntBrowse_Click(object sender, EventArgs e)
        {
            

            if (folderBrowserDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                txtDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        static int FreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
        WebServer httpServer;
        private void bntStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (bntStart.Tag != null && bntStart.Tag.ToString() == "Running")
                {
                    
                    httpServer.Stop();
                    bntStart.Tag = "Stopped";
                    bntStart.Text = "Start";
                }
                else
                {
                    httpServer = new WebServer(freePort, 99, txtDir.Text);
                    httpServer.CommandReceived += new WebServer.GetRequestHandler(server_CommandReceived);
                    httpServer.Start();
                    bntStart.Tag = "Running";
                    bntStart.Text = "Stop";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private int freePort = FreeTcpPort();
        string ipAddress = "";
        private void StartServerForm_Load(object sender, EventArgs e)
        {
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);
            ipAddress = ip.AddressList.FirstOrDefault(p=>p.AddressFamily == AddressFamily.InterNetwork).ToString();
            freePort = FreeTcpPort();

            linkLabel1.Text = "http://" + ipAddress + ":" + freePort;

        }

        void server_CommandReceived(object obj, WebServer.WebServerEventArgs e)
        {

            if (!string.IsNullOrEmpty(e.rawURL))
            {
                if (e.rawURL.StartsWith("[[$ROOT]]"))
                {

                    string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string theDirectory = Path.GetDirectoryName(fullPath);

                    string url = e.rawURL.Replace("[[$ROOT]]", theDirectory + "\\HTML");
                    WebServer.SendFileOverHTTP(e.response, url);

                }
                else
                {
                    WebServer.SendFileOverHTTP(e.response, ((WebServer)obj).RootDirectory + "\\" + e.rawURL);
                }
            }
            else
            {

                string html = createlistingHtml(((WebServer)obj).RootDirectory);
                WebServer.SendFileOverHTTP(e.response, html);
            }
        }

        private string createlistingHtml(string p)
        {
            DirectoryInfo info = new DirectoryInfo(p);
            string fileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".html");

            var template = File.OpenText("HTML\\treetable\\TEMPLATE.html").ReadToEnd();

            using (var stream = new StreamWriter(File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {


                //foreach (var fi  in info.GetFiles())
                //{
                //    stream.Write(string.Format("<a href='{0}' >{1}</a> </br>", fi.Name, fi.Name));
                //}
                StringBuilder sb = new StringBuilder();
                //sb.AppendFormat("<ul>");
                string path = "";
                //string list = GetListing(info, sb, path);
                string parentNode = "";
                int level = 0;
                GenerateHtml(info, sb, path, parentNode,level);
                //sb.AppendFormat("</ul>");
                template = template.Replace("[[$LISTING]]", sb.ToString());
                stream.Write(template);
            }
            return fileName;
        }

        private void GenerateHtml(DirectoryInfo info, StringBuilder sb, string path, string parentNode, int level)
        {
            int count = 1;
            var subDirs  = info.GetDirectories();
            if(subDirs!=null)
            foreach (var item in subDirs)
            {
                if(string.IsNullOrEmpty(parentNode))
                    sb.AppendFormat("<tr data-tt-id='{0}'>", count, parentNode);
                else
                    sb.AppendFormat("<tr data-tt-id='{0}' data-tt-parent-id='{1}'>", parentNode + "-" + count.ToString(), parentNode);
               sb.AppendFormat("     <td>");
               sb.AppendFormat("         <span class='folder'>{0}</span>", item.Name);
               sb.AppendFormat("    </td>");
                sb.AppendFormat("      <td> {0} </td>","Folder");
                sb.AppendFormat("      <td> {0} </td>","---");
                sb.AppendFormat("</tr>");
                string node = string.IsNullOrEmpty( parentNode)? count.ToString(): parentNode+"-"+count.ToString();

                GenerateHtml(item, sb, path + "/" + item.Name, node, level++);
                count++;
            }

            var files = info.GetFiles();
            if (files != null)
            {
                foreach (var item in files)
                {
                    if (string.IsNullOrEmpty(parentNode))
                        sb.AppendFormat("<tr data-tt-id='{0}'>", count, parentNode);
                    else
                        sb.AppendFormat("<tr data-tt-id='{0}' data-tt-parent-id='{1}'>", parentNode+"-"+count.ToString(), parentNode);
                    sb.AppendFormat("     <td>");
                    sb.AppendFormat("         <span class='file'><a href='{0}' target='_blank'>{1}</a></span>", path+"/"+ item.Name,item.Name);
                    sb.AppendFormat("    </td>");
                    sb.AppendFormat("      <td> {0} </td>", "File");
                    sb.AppendFormat("      <td> {0} </td>", item.Length.ToKB());
                    sb.AppendFormat("</tr>");
                    count++;
                }
            }
        }

        private string GetListing(DirectoryInfo info, StringBuilder sb, string path)
        {
            var subFolders = info.GetDirectories();
            if (subFolders.Count() > 0)
            {
                sb.AppendFormat("<ul>");
                foreach (var sub in subFolders)
                {
                    sb.AppendFormat("<input type='checkbox' id='item-1-{0}'/>", "0");

                    sb.AppendFormat("<label for='{0}'>{1}</label>", "0", sub.Name);
                    //sb.AppendFormat("<ul>");
                    GetListing(sub, sb, path + "/" + sub.Name);
                    
                    //sb.AppendFormat("</ul>");
                }
                sb.AppendFormat("</ul>");
            }
            if (info.GetFiles().Count() > 0)
            {


                foreach (var item in info.GetFiles())
                {
                    sb.Append("<li>");
                    sb.AppendFormat("<a href='{0}'>{1}</a>", path + "/" + item.Name, item.Name);
                    sb.Append("</li>");
                }

            }
            return sb.ToString();
        }

        private void GenerateHtml(DirectoryInfo sub, StringBuilder sb, string p, int p_2)
        {
            throw new NotImplementedException();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            BrowserForm form = new BrowserForm(linkLabel1.Text);
            form.ShowDialog(this);
        }
        
        

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace DDay.Update
{
    public class CommandLine
    {
        #region Private Fields

        private string _File;
        private string _Parameters;

        #endregion

        #region Public Properties

        public string File
        {
            get { return _File; }
            set { _File = value; }
        }

        public string Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; }
        }

        #endregion

        #region Constructors

        public CommandLine() { }
        public CommandLine(XmlNode elm, XmlNamespaceManager nsmgr)
        {
            if (elm.Attributes["file"] != null)
                File = elm.Attributes["file"].Value;
            if (elm.Attributes["parameters"] != null)
                Parameters = elm.Attributes["parameters"].Value;
        }

        #endregion

        #region Public Methods

        public void Run(string workingDirectory, string[] parameters)
        {
            List<string> parms = new List<string>(parameters);
            for (int i = 0; i < parms.Count; i++)
                parms[i] = "\"" + parms[i] + "\"";

            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(File, Parameters);
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.Arguments = string.Join(" ", parms.ToArray());
            process.Start();
        }

        #endregion
    }
}

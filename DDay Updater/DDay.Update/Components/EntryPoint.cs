using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class EntryPoint
    {
        #region Private Fields

        private string _Name;
        private string _DependencyName;
        private AssemblyIdentity _AssemblyIdentity;
        private CommandLine _CommandLine;        

        #endregion

        #region Public Properties

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string DependencyName
        {
            get { return _DependencyName; }
            set { _DependencyName = value; }
        }

        public AssemblyIdentity AssemblyIdentity
        {
            get { return _AssemblyIdentity; }
            set { _AssemblyIdentity = value; }
        }

        public CommandLine CommandLine
        {
            get { return _CommandLine; }
            set { _CommandLine = value; }
        }
        
        #endregion

        #region Constructors

        public EntryPoint() { }
        public EntryPoint(XmlNode elm, XmlNamespaceManager nsmgr)
        {
            if (elm.Attributes["name"] != null)
                Name = elm.Attributes["name"].Value;
            if (elm.Attributes["dependencyName"] != null)
                DependencyName = elm.Attributes["dependencyName"].Value;

            // Load the assembly identity
            XmlNode node = elm.SelectSingleNode("asmv2:assemblyIdentity", nsmgr);
            if (node != null)
                AssemblyIdentity = new AssemblyIdentity(this, node, nsmgr);

            // Load the command line
            node = elm.SelectSingleNode("asmv2:commandLine", nsmgr);
            if (node != null)
                CommandLine = new CommandLine(node, nsmgr);
        }

        #endregion

        #region Public Methods

        public void Run(string workingDirectory, string[] parameters)
        {
            if (CommandLine != null)
            {
                CommandLine.Run(workingDirectory, parameters);
            }
        }

        #endregion
    }
}

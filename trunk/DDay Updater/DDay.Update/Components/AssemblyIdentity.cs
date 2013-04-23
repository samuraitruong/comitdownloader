using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class AssemblyIdentity
    {
        #region Private Fields

        private string _Name;
        private Version _Version;
        private string _PublicKeyToken;
        private ProcessorArchitectureType _ProcessorArchitecture;        
        private object _Parent;
        private string _Language = "neutral";        

        #endregion

        #region Public Properties

        /// <summary>
        /// Required. Identifies the human-readable name of the
        /// deployment for informational purposes. If Name contains
        /// special characters, such as single or double quotes,
        /// the application may fail to activate.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Required. Specifies the version number of the deployment,
        /// in the following format: major.minor.build.revision. 
        /// This value must be updated to process any updates for the
        /// application.
        /// </summary>
        public Version Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// Optional. Specifies a 16-character hexadecimal string
        /// that represents the last 8 bytes of the SHA-1 hash value
        /// of the public key under which the deployment manifest is
        /// signed. The public key used to sign must be 2048 bits or
        /// greater.
        /// </summary>
        public string PublicKeyToken
        {
            get { return _PublicKeyToken; }
            set { _PublicKeyToken = value; }
        }

        /// <summary>
        /// Required. Specifies the microprocessor.
        /// </summary>
        public ProcessorArchitectureType ProcessorArchitecture
        {
            get { return _ProcessorArchitecture; }
            set { _ProcessorArchitecture = value; }
        }

        /// <summary>
        /// Optional. For compatibility with Windows side-by-side
        /// installation technology. The only allowed value is win32.
        /// </summary>
        public string Type
        {
            get { return "win32"; }
            set { }
        }

        /// <summary>
        /// Optional. Identifies the two part language codes of the
        /// assembly. For example, EN-US, which stands for English
        /// (U.S.). The default is neutral. This element is in the
        /// asmv2 namespace.
        /// </summary>
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }

        public object Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }

        #endregion

        #region Constructors

        public AssemblyIdentity(object parent)
        {
            Parent = parent;
        }
        public AssemblyIdentity(object parent, XmlNode elm, XmlNamespaceManager nsmgr)
            : this(parent)
        {
            if (elm.Attributes["name"] != null)
                Name = elm.Attributes["name"].Value;
            if (elm.Attributes["version"] != null)
                Version = new Version(elm.Attributes["version"].Value);
            if (elm.Attributes["publicKeyToken"] != null)
                PublicKeyToken = elm.Attributes["publicKeyToken"].Value;
            if (elm.Attributes["language"] != null)
                Language = elm.Attributes["language"].Value;
        }

        #endregion
    }

    #region ProcessorArchitectureType enum

    public enum ProcessorArchitectureType
    {
        msil,
        x86,
        IA64,
        amd64
    }

    #endregion
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class DeploymentProvider
    {
        #region Private Fields

        private string _CodeBase;

        #endregion

        #region Public Properties

        /// <summary>
        /// Required. Identifies the location, as a Uniform Resource Identifier
        /// (URI), of the deployment manifest that is used to update the ClickOnce
        /// application. This element also allows for forwarding update locations
        /// for CD-based installations. Must be a valid URI.
        /// </summary>
        public string CodeBase
        {
            get { return _CodeBase; }
            set { _CodeBase = value; }
        }

        #endregion

        #region Constructors

        public DeploymentProvider() { }
        public DeploymentProvider(XmlNode elm, XmlNamespaceManager nsmgr)
        {
            if (elm.Attributes["codebase"] != null)
                CodeBase = elm.Attributes["codebase"].Value;
        }

        #endregion
    }
}

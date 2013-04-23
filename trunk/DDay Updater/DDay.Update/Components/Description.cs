using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class Description
    {
        #region Private Fields

        private string _Publisher;
        private string _Product;
        private Uri _SupportUrl;        

        #endregion

        #region Public Properties

        /// <summary>
        /// Required. Identifies the company name used
        /// when identifying the program.
        /// </summary>
        public string Publisher
        {
            get { return _Publisher; }
            set { _Publisher = value; }
        }

        /// <summary>
        /// Required. Identifies the full product name.
        /// </summary>
        public string Product
        {
            get { return _Product; }
            set { _Product = value; }
        }

        /// <summary>
        /// Optional. Specifies a support URL that is shown in
        /// the Add or Remove Programs item in Control Panel. A
        /// shortcut to this URL is also created for application
        /// support in the Windows Start menu, when the deployment
        /// is configured for installation. This happens during
        /// a standard ClickOnce installation.
        /// </summary>
        public Uri SupportUrl
        {
            get { return _SupportUrl; }
            set { _SupportUrl = value; }
        }

        #endregion

        #region Constructors

        public Description() { }
        public Description(XmlNode elm, XmlNamespaceManager nsmgr)
        {
            string asmv2 = nsmgr.LookupNamespace("asmv2");
            if (elm.Attributes["publisher", asmv2] != null)
                Publisher = elm.Attributes["publisher", asmv2].Value;
            if (elm.Attributes["product", asmv2] != null)
                Product = elm.Attributes["product", asmv2].Value;
            if (elm.Attributes["supportUrl", asmv2] != null)
                SupportUrl = new Uri(elm.Attributes["supportUrl", asmv2].Value);
        }

        #endregion
    }
}

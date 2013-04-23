using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class Deployment
    {
        #region Private Fields

        private bool _Install;
        private Version _MinimumRequiredVersion;
        private bool _MapFileExtensions;
        private bool _DisallowUrlActivation;
        private bool _TrustUrlParameters;
        private DeploymentProvider _DeploymentProvider;       
        private Manifest _Parent;        

        #endregion

        #region Public Properties

        /// <summary>
        /// Required. Specifies whether this application defines
        /// a presence on the Windows Start menu and in the
        /// Control Panel Add or Remove Programs application.
        /// Valid values are true and false. If false, ClickOnce
        /// will always run the latest version of this application
        /// from the network, and will not recognize the subscription
        /// element.
        /// </summary>
        public bool Install
        {
            get { return _Install; }
            set { _Install = value; }
        }

        /// <summary>
        /// Optional. Specifies the minimum version of this application
        /// that can run on the client. If the version number of the
        /// application is less than the version number supplied in the
        /// deployment manifest, the application will not run. Version
        /// numbers must be specified in the format N.N.N.N, where N is
        /// an unsigned integer. If the install attribute is false,
        /// minimumRequiredVersion must not be set.
        /// </summary>
        public Version MinimumRequiredVersion
        {
            get { return _MinimumRequiredVersion; }
            set { _MinimumRequiredVersion = value; }
        }

        /// <summary>
        /// Optional. Defaults to false. If true, all files in the
        /// deployment must have a .deploy extension. ClickOnce will strip
        /// this extension off these files as soon as it downloads them
        /// from the Web server. If you publish your application by using
        /// Visual Studio, it automatically adds this extension to all
        /// files. This parameter allows all the files within a ClickOnce
        /// deployment to be downloaded from a Web server that blocks
        /// transmission of files ending in "unsafe" extensions such as
        /// .exe.
        /// </summary>
        public bool MapFileExtensions
        {
            get { return _MapFileExtensions; }
            set { _MapFileExtensions = value; }
        }

        /// <summary>
        /// Optional. Defaults to false. If true, prevents an installed
        /// application from being started by clicking the URL or entering
        /// the URL into Internet Explorer. If the install attribute is
        /// not present, this attribute is ignored.
        /// </summary>
        public bool DisallowUrlActivation
        {
            get { return _DisallowUrlActivation; }
            set { _DisallowUrlActivation = value; }
        }

        /// <summary>
        /// Optional. Defaults to false. If true, allows the URL to
        /// contain query string parameters that are passed into the
        /// application, much like command-line arguments are passed
        /// to a command-line application. If the disallowUrlActivation
        /// attribute is true, trustUrlParameters must either be excluded
        /// from the manifest, or explicitly set to false.
        /// </summary>
        public bool TrustUrlParameters
        {
            get { return _TrustUrlParameters; }
            set { _TrustUrlParameters = value; }
        }

        /// <summary>
        /// Required if the deployment manifest contains a subscription
        /// section; otherwise, optional. This element is a child of the
        /// deployment element.
        /// </summary>
        public DeploymentProvider DeploymentProvider
        {
            get { return _DeploymentProvider; }
            set { _DeploymentProvider = value; }
        }

        /// <summary>
        /// The manifest that this deployment belongs to.
        /// </summary>
        public Manifest Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }

        #endregion

        #region Constructors

        public Deployment(Manifest parent)
        {
            Parent = parent;
        }

        public Deployment(Manifest parent, XmlNode elm, XmlNamespaceManager nsmgr)
            : this(parent)
        {
            if (elm.Attributes["install"] != null)
                Install = Convert.ToBoolean(elm.Attributes["install"].Value);
            if (elm.Attributes["minimumRequiredVersion"] != null)
                MinimumRequiredVersion = new Version(elm.Attributes["minimumRequiredVersion"].Value);
            if (elm.Attributes["mapFileExtensions"] != null)
                MapFileExtensions = Convert.ToBoolean(elm.Attributes["mapFileExtensions"].Value);
            if (elm.Attributes["disallowUrlActivation"] != null)
                DisallowUrlActivation = Convert.ToBoolean(elm.Attributes["disallowUrlActivation"].Value);
            if (elm.Attributes["trustUrlParameters"] != null)
                TrustUrlParameters = Convert.ToBoolean(elm.Attributes["trustUrlParameters"].Value);

            // Get the deploymentProvider node, if it exists
            XmlNode node = elm.SelectSingleNode("asmv2:deploymentProvider", nsmgr);
            
            // Create a DeploymentProvider object from the XML
            if (node != null)
                DeploymentProvider = new DeploymentProvider(node, nsmgr);
        }

        #endregion
    }
}

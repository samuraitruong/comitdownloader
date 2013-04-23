using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DDay.Update.Configuration
{
    /// <summary>
    /// FIXME: need to add a "Preserve" and "Remove" sections
    /// to allow the user to preserve original files (i.e. app.config files
    /// that get incorrectly replaced by a "newer" copy, or remove
    /// files to save space or because they conflict with other files).
    /// </summary>
    public class DDayUpdateConfigurationSection : ConfigurationSection
    {
        static private IUpdateNotifier _UpdateNotifier;
        static private IVersionManager _VersionManager;        

        [ConfigurationProperty("uri", IsRequired = true)]
        public Uri Uri
        {
            get { return new Uri(this["uri"].ToString()); }
            set { this["uri"] = value.AbsoluteUri; }
        }

        [ConfigurationProperty("automatic", IsRequired = false, DefaultValue = true)]
        public bool Automatic
        {
            get { return (bool)this["automatic"]; }
            set { this["automatic"] = value; }
        }

        [ConfigurationProperty("notifier", IsRequired = false)]
        public string NotifierString
        {
            get { return (string)this["notifier"]; }
            set { this["notifier"] = value; }
        }

        [ConfigurationProperty("versionManager", IsRequired = false)]
        public string VersionManagerString
        {
            get { return (String)this["versionManager"]; }
            set { this["versionManager"] = value; }
        }

        [ConfigurationProperty("removePriorToVersion", IsRequired = false)]
        public string RemovePriorToVersionString
        {
            get { return (String)this["removePriorToVersion"]; }
            set { this["removePriorToVersion"] = value; }        
        }

        [ConfigurationProperty("keepVersions", IsRequired = false)]
        public int? KeepVersions
        {
            get { return (int?)this["keepVersions"]; }
            set { this["keepVersions"] = value; }
        }

        [ConfigurationProperty("bootstrapFilesFolder", IsRequired = false)]
        public string BootstrapFilesFolder
        {
            get { return (string)this["bootstrapFilesFolder"]; }
            set { this["bootstrapFilesFolder"] = value; }
        }

        [ConfigurationProperty("useUserFolder", IsRequired = false, DefaultValue = false)]
        public bool UseUserFolder
        {
            get { return (bool)this["useUserFolder"]; }
            set { this["useUserFolder"] = value; }
        }

        [ConfigurationProperty("usePublicFolder", IsRequired = false, DefaultValue = false)]
        public bool UsePublicFolder
        {
            get { return (bool)this["usePublicFolder"]; }
            set { this["usePublicFolder"] = value; }
        }

        [ConfigurationProperty("Preserve", IsRequired = false)]
        public KeyValuePairConfigurationElementCollection Preserve
        {
            get { return (KeyValuePairConfigurationElementCollection)this["Preserve"]; }
            set { this["Preserve"] = value; }
        }

        [ConfigurationProperty("Remove", IsRequired = false)]
        public KeyValuePairConfigurationElementCollection Remove
        {
            get { return (KeyValuePairConfigurationElementCollection)this["Remove"]; }
            set { this["Remove"] = value; }
        }

        [ConfigurationProperty("username", IsRequired = false)]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = false)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("domain", IsRequired = false)]
        public string Domain
        {
            get { return (string)this["domain"]; }
            set { this["domain"] = value; }
        }

        public IUpdateNotifier UpdateNotifier
        {
            get
            {
                try
                {
                    if (_UpdateNotifier == null)
                    {
                        Type type = Type.GetType(NotifierString, false);
                        if (type != null)
                            _UpdateNotifier = Activator.CreateInstance(type) as IUpdateNotifier;
                    }
                }
                catch { }
                return _UpdateNotifier;
            }
            set
            {
                _UpdateNotifier = value;
                NotifierString = value.GetType().FullName;
            }
        }

        public IVersionManager VersionManager
        {
            get
            {
                try
                {
                    if (_VersionManager == null)
                    {
                        Type type = Type.GetType(VersionManagerString, false);
                        if (type != null)
                            _VersionManager = Activator.CreateInstance(type) as IVersionManager;
                        else _VersionManager = new VersionManager();
                    }
                }
                catch
                {
                    _VersionManager = new VersionManager();
                }
                return _VersionManager;
            }
            set
            {
                _VersionManager = value;
                VersionManagerString = value.GetType().FullName;
            }
        }

        public Version RemovePriorToVersion
        {
            get
            {
                try
                {
                    if (RemovePriorToVersionString != null)
                        return new Version(RemovePriorToVersionString);
                }
                catch { }
                return null;
            }
            set
            {
                RemovePriorToVersionString = value.ToString();
            }
        }
    }
}

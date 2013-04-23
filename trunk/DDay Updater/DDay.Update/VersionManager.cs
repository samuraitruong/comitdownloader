using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DDay.Update
{
    public class VersionManager : IVersionManager
    {
        #region IVersionManager Members

        public Version[] LocalVersions
        {
            get
            {
                List<Version> versions = new List<Version>();

                string basePath = UpdateManager.VersionRepositoryFolder;
                foreach (string dir in Directory.GetDirectories(basePath))
                {
                    try
                    {
                        string versionName = Path.GetFileName(dir);
                        Version version = new Version(versionName);
                        versions.Add(version);
                    }
                    catch { }
                }

                // Sort the versions in descending order
                versions.Sort(delegate(Version v1, Version v2)
                {
                    return v2.CompareTo(v1);
                });

                return versions.ToArray();
            }
        }
        
        public void RemoveVersion(Version version)
        {
            string basePath = UpdateManager.VersionRepositoryFolder;
            string dirPath = Path.Combine(basePath, version.ToString());

            // Remove the version
            if (Directory.Exists(dirPath))
                Directory.Delete(dirPath, true);
            else ; // FIXME: throw an exception
        }

        #endregion
    }
}

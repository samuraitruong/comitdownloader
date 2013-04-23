using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ComicDownloader.Installer
{
    class RegistryHelper
    {
        /// <summary>
        /// Checks if the registry entry at the given path exists or not
        /// </summary>
        /// <param name="path">path of the registry</param>
        /// <returns>True/False</returns>
        public bool CheckRegistry(string path)
        {
            try
            {
                RegistryKey regkey = Registry.LocalMachine.OpenSubKey(path);
                if (regkey == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Reads the registry value at the given path with the given key name
        /// </summary>
        /// <param name="path">Path of the registry entry</param>
        /// <param name="key">name of the key</param>
        /// <returns>Value of the key</returns>
        public string ReadRegistry(string path, string key)
        {
            try
            {
                RegistryKey regkey = Registry.LocalMachine.OpenSubKey(path);
                string RegValue = regkey.GetValue(key).ToString();
                if (string.IsNullOrEmpty(RegValue))
                {
                    return null;
                }
                else
                {
                    return RegValue;
                }
            }
            catch (Exception ex)
            {
                return "No Entry";
            }

        }


        /// <summary>
        /// Edits the registry at the given path with the new value
        /// </summary>
        /// <param name="path">registry path</param>
        /// <param name="key">key value</param>
        /// <param name="value">new value</param>
        /// <returns>bool</returns>
        public bool EditRegistry(string path, string key, string value)
        {
            try
            {
                RegistryKey regkey = Registry.LocalMachine.OpenSubKey(path, true);
                RegistrySecurity rs = regkey.GetAccessControl(AccessControlSections.Access);
                rs.SetGroup(new NTAccount("Administrators"));
                rs.SetOwner(new NTAccount("Administrators"));
                rs.SetAccessRuleProtection(false, false);
                regkey.SetAccessControl(rs);
                regkey.SetValue(key, value, RegistryValueKind.DWord);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a registry entry at the given path with given key and value
        /// </summary>
        /// <param name="path">Registry subkey path to create</param>
        /// <param name="key">name of the key in the entry</param>
        /// <param name="value">value of the key</param>
        /// <returns>bool</returns>
        public bool WriteRegistry(string path, string key, string value)
        {
            try
            {
                Registry.LocalMachine.CreateSubKey(path);
                RegistryKey regkey = Registry.LocalMachine.OpenSubKey(path, true);
                regkey.SetValue(key, value);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the registry entry at the given path 
        /// </summary>
        /// <param name="path">path of the registry</param>
        /// <returns>bool</returns>
        public bool DeleteRegistry(string path)
        {
            try
            {
                Registry.LocalMachine.DeleteSubKey(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

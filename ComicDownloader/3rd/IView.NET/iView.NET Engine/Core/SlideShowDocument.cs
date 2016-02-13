//::///////////////////////////////////////////////////////////////////////////
//:: File Name: SlideShowDocument.cs
//::///////////////////////////////////////////////////////////////////////////
/*
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 * 
 */
//::///////////////////////////////////////////////////////////////////////////
//:: Contact: sdaily2004@hotmail.com 
//:: Created By: Stephen Daily
//:: Created On: 8 April 2011
//:: Copyright © 2011 Stephen Daily
//::///////////////////////////////////////////////////////////////////////////
//:: Pre Processor Directives
//::///////////////////////////////////////////////////////////////////////////
#define DEBUG
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System; using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides properties and methods for loading, creating and saving iView.NET slide show files (.ssf).
    /// </summary>
    public class SlideShowDocument
    {
        #region Fields and properties

        private const string SSF_FILE_ID = "SSF";

        private SSFDescriptor m_Descriptor;
        private List<string> m_sEntries;

        /// <summary>
        /// Gets or sets the Version property.
        /// </summary>
        public byte Version
        {
            get { return m_Descriptor.Version; }
            set { m_Descriptor.Version = value; }
        }

        /// <summary>
        /// Gets or sets the EntryCount property.
        /// </summary>
        public int EntryCount
        {
            get { return m_Descriptor.EntryCount; }
            set { m_Descriptor.EntryCount = value; }
        }

        /// <summary>
        /// Gets or sets the TransitionMode property.
        /// </summary>
        public TransitionMode TransitionMode
        {
            get { return m_Descriptor.TransitionMode; }
            set { m_Descriptor.TransitionMode = value; }
        }

        /// <summary>
        /// Gets or sets the WaitInterval property.
        /// </summary>
        public int WaitInterval
        {
            get { return m_Descriptor.WaitInterval; }
            set { m_Descriptor.WaitInterval = value; }
        }

        /// <summary>
        /// Gets or sets the FadeSpeed property.
        /// </summary>
        public float FadeSpeed
        {
            get { return m_Descriptor.FadeSpeed; }
            set { m_Descriptor.FadeSpeed = value; }
        }

        /// <summary>
        /// Gets or sets the Date property.
        /// </summary>
        public string Date
        {
            get { return m_Descriptor.Date; }
            set { m_Descriptor.Date = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the SlideShowDocument class initialized with default values.
        /// </summary>
        public SlideShowDocument()
        {
            m_Descriptor = SSFDescriptor.Empty;
            m_sEntries = new List<string>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads a slide show file from the specified file path.
        /// </summary>
        /// <param name="sFilePath">Specifies the full name of the slide show file to load.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="IView.Engine.Core.FileFormatException"></exception>
        public void Load(string sFilePath)
        {
            if (string.IsNullOrEmpty(sFilePath))
                throw new ArgumentException("The specified string cannot be null, empty or just white space.", "sFilePath");

            try
            {
                using (Stream oStream = new FileStream(sFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader oReader = new BinaryReader(oStream, Encoding.Default))
                    {
                        if (oReader.ReadString() != SSF_FILE_ID)
                            throw new FileFormatException("Unknown file structure.");
                        
                        // Read the descriptor values.
                        m_Descriptor.Version = oReader.ReadByte();
                        m_Descriptor.EntryCount = oReader.ReadInt32();
                        m_Descriptor.Date = oReader.ReadString();

                        // Padding.
                        oReader.ReadByte();

                        m_Descriptor.WaitInterval = oReader.ReadInt32();
                        m_Descriptor.TransitionMode = (TransitionMode)oReader.ReadInt32();
                        m_Descriptor.FadeSpeed = oReader.ReadSingle();

                        // Padding.
                        oReader.ReadByte();

                        // Unpack and add the entries.
                        m_sEntries = new List<string>(UnPackEntries(oReader.ReadString()));
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFilePath"></param>
        public void Save(string sFilePath)
        {

        }

        /// <summary>
        /// Creates an iView.NET slide show file at the specified location with the specified parameters.
        /// </summary>
        /// <param name="sFilePath">Specifies the full path of the slide show file.</param>
        /// <param name="Descriptor">Specifies a slide show file descriptor that will be written to the file.</param>
        /// <param name="sEntries">Specifies the file path entries to write to the file.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public void Create(string sFilePath, SSFDescriptor Descriptor, string[] sEntries)
        {
            if (string.IsNullOrEmpty(sFilePath))
                throw new ArgumentException("The specified string cannot be null, empty or just white space.", "sFilePath");

            try
            {
                using (Stream oStream = new FileStream(sFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter oWriter = new BinaryWriter(oStream, Encoding.Default))
                    {
                        // Write the file descriptor values.
                        oWriter.Write(SSF_FILE_ID);
                        oWriter.Write(Descriptor.Version);
                        oWriter.Write(Descriptor.EntryCount);
                        oWriter.Write(Descriptor.Date);

                        // Padding.
                        oWriter.Write((byte)0);

                        // Write the slide show values.
                        oWriter.Write(Descriptor.WaitInterval);
                        oWriter.Write((int)Descriptor.TransitionMode);
                        oWriter.Write(Descriptor.FadeSpeed);

                        // Padding.
                        oWriter.Write((byte)0);

                        // Pack and add the entries.
                        oWriter.Write(PackEntries(sEntries));
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
        }

        /// <summary>
        /// Gets the entries contained within the current slide show document.
        /// </summary>
        /// <returns></returns>
        public string[] GetEntries()
        {
            return m_sEntries.ToArray();
        }

        /// <summary>
        /// Packs the specified string array into a single string value.
        /// </summary>
        /// <param name="sEntries">Specifies the the string array to pack.</param>
        /// <returns></returns>
        private string PackEntries(string[] sEntries)
        {
            if ((sEntries != null) && (sEntries.Length > 0))
                return string.Join("|", sEntries);
            return string.Empty;
        }

        /// <summary>
        /// Unpacks the specified string into a string array.
        /// </summary>
        /// <param name="sEntries">Specifies the string to unpack.</param>
        /// <returns></returns>
        private string[] UnPackEntries(string sEntries)
        {
            if (!string.IsNullOrEmpty(sEntries))
                return sEntries.Split(new char[] { '|' });
            return new string[0];
        }

        #endregion
    }
}
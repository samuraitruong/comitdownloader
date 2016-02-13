//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageEditManagement.cs
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
//:: Created On: 29 October 2010
//:: Copyright © 2011 Stephen Daily
//::///////////////////////////////////////////////////////////////////////////
//:: Pre Processor Directives
//::///////////////////////////////////////////////////////////////////////////
#define DEBUG_DATA
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System; using System.Net;
using System.Collections.Generic;
using System.Drawing;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides undo and redo functionallity for image editing.
    /// </summary>
    public class ImageEditManagement : IDisposable
    {
        #region Fields and properties

        private bool m_bIsDisposed;
        private int m_nIndex;
        private int m_nMaxUndos;
        private List<Bitmap> m_oBitMaps;

        /// <summary>
        /// Gets a value indicating whether dispose has been called on this object.
        /// </summary>
        public bool IsDisposed
        {
            get { return m_bIsDisposed; }
        }

        /// <summary>
        /// Gets a value indicating whether the user can undo the last edited operation.
        /// </summary>
        public bool CanUndo
        {
            get
            {
                return ((m_oBitMaps.Count > 1) && (m_nIndex > 0));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user can redo the last undo operation.
        /// </summary>
        public bool CanRedo
        {
            get
            {
                return (m_nIndex + 1 < m_oBitMaps.Count);
            }
        }

        /// <summary>
        /// Gets the number of undo elements currently in the list.
        /// </summary>
        public int Count
        {
            get { return m_oBitMaps.Count; }
        }

        #endregion

        #region Constructors and destructors

        /// <summary>
        /// Creates a new instance of the ImageEditManagement class initialized with the specified parameters.
        /// </summary>
        /// <param name="nMaxUndos">Sets the maximum number of undo elements for this instance.</param>
        public ImageEditManagement(int nMaxUndos)
        {            
            m_nMaxUndos = nMaxUndos;
            m_oBitMaps = new List<Bitmap>();
        }

        /// <summary>
        /// Class destructor.
        /// </summary>
        ~ImageEditManagement()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an undo element to the list.
        /// </summary>
        /// <param name="oImage">Specifies the image to save to the undo list.</param>
        public void Add(Image oImage)
        {
            if (oImage == null)
                return;

            int nIndex = m_nIndex + 1;

            if (m_oBitMaps.Count < m_nMaxUndos)
            {
                // If the index is not pointing to the end of the list, remove the items
                // past the index value.
                if (nIndex < m_oBitMaps.Count)
                {
                    // Iterate the list and delete the files.
                    for (int n = nIndex; n < m_oBitMaps.Count; n++)
                    {
                        m_oBitMaps[n].Dispose();
                        m_oBitMaps[n] = null;
                    }

                    // Remove the elements that have been orphaned.
                    m_oBitMaps.RemoveRange(nIndex, m_oBitMaps.Count - nIndex);
                }

                // Add the path to the array list.
                m_oBitMaps.Add(new Bitmap(oImage, oImage.Size));

                // Update the index value.
                m_nIndex = m_oBitMaps.Count - 1;
            }
            else
            {
                // If the index is not pointing to the end of the list, remove the elements
                // past the index value.
                if (nIndex < m_oBitMaps.Count)
                {
                    // Iterate the list and delete the files.
                    for (int n = nIndex; n < m_oBitMaps.Count; n++)
                    {
                        m_oBitMaps[n].Dispose();
                        m_oBitMaps[n] = null;
                    }

                    // Remove the elements that have been orphaned.
                    m_oBitMaps.RemoveRange(nIndex, m_oBitMaps.Count - nIndex);
                }
                else
                {
                    m_oBitMaps[0].Dispose();
                    m_oBitMaps[0] = null;
                    m_oBitMaps.RemoveAt(0);
                }

                // Add the path to the array list.
                m_oBitMaps.Add(new Bitmap(oImage, oImage.Size));

                // Update the index value.
                m_nIndex = m_oBitMaps.Count - 1;
            }
        }

        /// <summary>
        /// Clears all the elements from the list.
        /// </summary>
        public void Clear()
        {
            if (m_oBitMaps.Count <= 0)
                return;

            // Iterate the list and delete clean up the images.
            for (int n = 0; n < m_oBitMaps.Count; n++)
            {
                m_oBitMaps[n].Dispose();
                m_oBitMaps[n] = null;
            }

            // Reset field members.
            m_nIndex = 0;
            m_oBitMaps.Clear();
        }

        /// <summary>
        /// Gets the previous image in the undo list.
        /// </summary>
        /// <returns></returns>
        public Bitmap Undo()
        {
            if (m_oBitMaps.Count > 0)
            {
                if (m_nIndex > 0)
                    --m_nIndex;

                return new Bitmap(m_oBitMaps[m_nIndex]);
            }

            return null;
        }

        /// <summary>
        /// Gets the next image in the undo list.
        /// </summary>
        /// <returns></returns>
        public Bitmap Redo()
        {
            if (m_oBitMaps.Count > 0)
            {
                if (m_nIndex < m_oBitMaps.Count - 1)
                    ++m_nIndex;

                return new Bitmap(m_oBitMaps[m_nIndex]);
            }

            return null;
        }

        /// <summary>
        /// Cleans up all the resources used by this class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Cleans up all resources used by this class.
        /// </summary>
        /// <param name="bDispose">Specifies whether to clean up managed resources.</param>
        protected virtual void Dispose(bool bDispose)
        {
            if (!m_bIsDisposed)
            {
                if (bDispose)
                {
                    // Dispose of the images.
                    for (int n = 0; n < m_oBitMaps.Count; n++)
                    {
                        if (m_oBitMaps[n] != null)
                        {
                            m_oBitMaps[n].Dispose();
                            m_oBitMaps[n] = null;
                        }
                    }

                    // Delete the list.
                    m_oBitMaps.Clear();
                    m_oBitMaps = null;
                }

                m_bIsDisposed = true;
            }
        }

        #endregion
    }
}

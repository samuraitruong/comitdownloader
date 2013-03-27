//::///////////////////////////////////////////////////////////////////////////
//:: File Name: RecentPlacesCollection.cs
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
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides a collection container for the RecentPlacesCollection class. Provides methods for adding, 
    /// removing and enumerating through a RecentPlacesCollection list.
    /// </summary>
    public class RecentPlacesCollection
    {
        #region Fields and properties

        private const int DEFAULT_CAPACITY = 5;

        private List<RecentPlace> m_sRecentLocations;

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        public int Count
        {
            get { return m_sRecentLocations.Count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the RecentPlacesCollection class that is empty
        /// and has the default initial capacity.
        /// </summary>
        public RecentPlacesCollection()
        {
            m_sRecentLocations = new List<RecentPlace>(DEFAULT_CAPACITY);
        }

        /// <summary>
        /// Creates a new instance of the RecentPlacesCollection class that is initialized
        /// with the specified capacity.
        /// </summary>
        /// <param name="nCapacity">Specifies the initial capacity of the collection.</param>
        public RecentPlacesCollection(int nCapacity)
        {
            m_sRecentLocations = new List<RecentPlace>(nCapacity);
        }

        /// <summary>
        /// Creates a new instance of the RecentPlacesCollection class that contains 
        /// elements copied from the specified favourite collection.
        /// </summary>
        /// <param name="oFavourites">Specifies an array of Favourite objects to add to the collection.</param>
        public RecentPlacesCollection(RecentPlace[] oRecentPlaces)
        {
            m_sRecentLocations = new List<RecentPlace>(oRecentPlaces);
        }

        /// <summary>
        /// Creates a new instance of the RecentPlacesCollection class that contains 
        /// elements copied from the specified string collection.
        /// </summary>
        /// <param name="oStringCollection">Specifies the StringCollection object to add to the collection.</param>
        public RecentPlacesCollection(StringCollection oStringCollection)
        {
            m_sRecentLocations = new List<RecentPlace>();

            if (oStringCollection != null)
            {
                // Add the string collection.
                foreach (string sString in oStringCollection)
                {
                    string[] sData = sString.Split('|');

                    if ((sData != null) && (sData.Length == 2))
                        this.Add(new RecentPlace(sData[0], sData[1]));
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the elements in the collection as an array.
        /// </summary>
        /// <returns></returns>
        public RecentPlace[] ToArray()
        {
            return m_sRecentLocations.ToArray();
        }

        /// <summary>
        /// Returns the elements in the collection as a StringCollection type.
        /// </summary>
        /// <returns></returns>
        public StringCollection ToStringCollection()
        {
            StringCollection oCollection = new StringCollection();

            foreach (RecentPlace oRecentPlace in m_sRecentLocations)
                oCollection.Add(oRecentPlace.DisplayName + "|" + oRecentPlace.Location);

            return oCollection;
        }

        /// <summary>
        /// Adds the specified object to the end of the collection.
        /// </summary>
        /// <param name="oFavourite">Specifies a RecentPlace object to add to the end of the collection.</param>
        public void Add(RecentPlace oRecentPlace)
        {
            m_sRecentLocations.Add(oRecentPlace);
        }

        /// <summary>
        /// Removes the first occurrence of the specified object from the collection.
        /// </summary>
        /// <param name="oFavourite"></param>
        public void Remove(RecentPlace oRecentPlace)
        {
            m_sRecentLocations.Remove(oRecentPlace);
        }

        /// <summary>
        /// Removes the element at the specified index from the collection.
        /// </summary>
        /// <param name="nIndex">Specifies the index of the item in the collection to remove from the list.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public void RemoveAt(int nIndex)
        {
            try
            {
                m_sRecentLocations.RemoveAt(nIndex);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(e.Message, e);
            }
        }

        /// <summary>
        /// Clears all the elements in the list.
        /// </summary>
        public void Clear()
        {
            m_sRecentLocations.Clear();
        }

        #endregion
    }
}

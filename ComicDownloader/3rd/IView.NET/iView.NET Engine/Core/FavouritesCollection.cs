//::///////////////////////////////////////////////////////////////////////////
//:: File Name: FavouritesCollection.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides a collection container for the Favourite class. Provides methods for adding, 
    /// removing and enumerating through a FavouritesCollection list.
    /// </summary>
    public class FavouritesCollection : IEnumerable
    {
        #region Fields and properties

        private List<Favourite> m_oFavourites;

        /// <summary>
        /// Gets or sets the total number of elements the collection can hold without resizing.
        /// </summary>
        public int Capacity
        {
            get { return m_oFavourites.Capacity; }
            set { m_oFavourites.Capacity = value; }
        }

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        public int Count
        {
            get { return m_oFavourites.Count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the FavouritesCollection class that is empty
        /// and has the default initial capacity.
        /// </summary>
        public FavouritesCollection()
        {
            m_oFavourites = new List<Favourite>();
        }

        /// <summary>
        /// Creates a new instance of the FavouritesCollection class that is initialized
        /// with the specified capacity.
        /// </summary>
        /// <param name="nCapacity">Specifies the initial capacity of the collection.</param>
        public FavouritesCollection(int nCapacity)
        {
            m_oFavourites = new List<Favourite>(nCapacity);
        }

        /// <summary>
        /// Creates a new instance of the FavouritesCollection class that contains 
        /// elements copied from the specified favourite collection.
        /// </summary>
        /// <param name="oFavourites">Specifies an array of Favourite objects to add to the collection.</param>
        public FavouritesCollection(Favourite[] oFavourites)
        {
            m_oFavourites = new List<Favourite>(oFavourites);
        }

        /// <summary>
        /// Creates a new instance of the FavouritesCollection class that contains 
        /// elements copied from the specified string collection.
        /// </summary>
        /// <param name="oStringCollection">Specifies the StringCollection object to add to the collection.</param>
        public FavouritesCollection(StringCollection oStringCollection)
        {
            m_oFavourites = new List<Favourite>();

            if (oStringCollection != null)
            {
                // Add the string collection.
                foreach (string sString in oStringCollection)
                {
                    string[] sData = sString.Split('|');
                    
                    if ((sData != null) && (sData.Length == 3))
                        this.Add(new Favourite(sData[0], sData[1], sData[2]));
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the elements in the collection as an array.
        /// </summary>
        /// <returns></returns>
        public Favourite[] ToArray()
        {
            return m_oFavourites.ToArray();
        }

        /// <summary>
        /// Returns the elements in the collection as a StringCollection type.
        /// </summary>
        /// <returns></returns>
        public StringCollection ToStringCollection()
        {
            StringCollection oCollection = new StringCollection();

            foreach (Favourite oFavourite in m_oFavourites)
                oCollection.Add(oFavourite.Name + "|" + oFavourite.Created + "|" + oFavourite.Path);

            return oCollection;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (Favourite oFavourite in m_oFavourites)
                yield return oFavourite;
        }

        /// <summary>
        /// Adds a Favourite object to the end of the collection.
        /// </summary>
        /// <param name="oFavourite">Specifies a Favourite object to add to the end of the collection.</param>
        public void Add(Favourite oFavourite)
        {
            m_oFavourites.Add(oFavourite);
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="nIndex">Specifies the index at which to insert the element.</param>
        /// <param name="oFavourite">Specifies the object to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Insert(int nIndex, Favourite oFavourite)
        {
            try
            {
                m_oFavourites.Insert(nIndex, oFavourite);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(e.Message, e);
            }
        }

        /// <summary>
        /// Searches for the specified object and returns the zero based index value of the first occurence found in the collection.
        /// </summary>
        /// <param name="oFavourite">Specifies the object to search for.</param>
        /// <returns></returns>
        public int IndexOf(Favourite oFavourite)
        {
            return m_oFavourites.IndexOf(oFavourite);
        }

        /// <summary>
        /// Removes the first occurrence of the specified object from the collection.
        /// </summary>
        /// <param name="oFavourite">Specifies a Favourite object to add to the end of the collection.</param>
        public void Remove(Favourite oFavourite)
        {
            m_oFavourites.Remove(oFavourite);
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
                m_oFavourites.RemoveAt(nIndex);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(e.Message, e);
            }
        }

        /// <summary>
        /// Determines whether the specified object is in the collection.
        /// </summary>
        /// <param name="oFavourite">Specifies the object to search for.</param>
        /// <returns></returns>
        public bool Contains(Favourite oFavourite)
        {
            return m_oFavourites.Contains(oFavourite);
        }

        /// <summary>
        /// Removes all the elements from the collection.
        /// </summary>
        public void Clear()
        {
            m_oFavourites.Clear();
        }

        #endregion
    }
}

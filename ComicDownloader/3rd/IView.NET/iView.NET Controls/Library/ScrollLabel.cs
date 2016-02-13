//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ScrollLabel.cs
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
//:: Created On: 3 May 2011
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class ScrollLabel : Label
    {
        #region Fields and properties

        private int m_nMin = 0;
        private int m_nMax = 100;
        private int m_nVal = 0;
        private Point m_Pos = Point.Empty;

        /// <summary>
        /// Fires when the ScrollLabel value has changed.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets or sets the minimum value property.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int Minimum
        {
            get { return m_nMin; }
            set
            {
                if (value < m_nMax)
                {
                    if (value > m_nVal)
                        m_nVal = value;

                    m_nMin = value;
                }
                else
                {
                    if (!DesignMode)
                        throw new ArgumentOutOfRangeException("Minimum", "The specified value cannot be more than the Maximium value.");
                    else
                        MessageBox.Show("The specified value cannot be more than the Maximium value.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum value property.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int Maximum
        {
            get { return m_nMax; }
            set
            {
                if (value > m_nMin)
                {
                    if (value < m_nVal)
                        m_nVal = value;

                    m_nMax = value;
                }
                else
                {
                    if (!DesignMode)
                        throw new ArgumentOutOfRangeException("Maximum", "The specified value cannot be lass than the Minimum value.");
                    else
                        MessageBox.Show("The specified value cannot be more than the Minimum value.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the value property.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int Value
        {
            get { return m_nVal; }
            set
            {
                if ((value >= m_nMin) && (value <= m_nMax))
                {
                    m_nVal = value;
                    OnValueChanged(this, EventArgs.Empty);
                }
                else
                {
                    if (!DesignMode)
                        throw new ArgumentOutOfRangeException("Value", "The specified value cannot be lass than the Minimum or more than the Maximum value.");
                    else
                        MessageBox.Show("The specified value cannot be lass than the Minimum or more than the Maximum value.");
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.Enabled)
                m_Pos = MousePosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.Enabled)
                m_Pos = Point.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!this.Enabled)
                return;

            if (!m_Pos.IsEmpty)
            {
                int nX = MousePosition.X;

                if (nX > m_Pos.X)
                {
                    if (m_nVal < m_nMax)
                    {
                        ++m_nVal;
                        OnValueChanged(this, EventArgs.Empty);
                    }

                    m_Pos.X = nX;
                }
                else if (nX < m_Pos.X)
                {
                    if (m_nVal > m_nMin)
                    {
                        --m_nVal;
                        OnValueChanged(this, EventArgs.Empty);
                    }

                    m_Pos.X = nX;
                }
            }
        }

        #endregion
    }
}

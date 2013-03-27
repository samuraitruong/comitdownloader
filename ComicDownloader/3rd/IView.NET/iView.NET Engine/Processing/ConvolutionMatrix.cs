using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IView.Engine.Processing
{
    public class ConvolutionMatrix
    {
        private int m_nFactor = 0;
        private int m_nOffset = 0;
        private int m_nTopLeft = 0, m_nTopMiddle = 0, m_nTopRight = 0;
        private int m_nMiddleLeft = 0, m_nPixel = 1, m_nMiddleRight = 0;
        private int m_nBottomLeft = 0, m_nBottomMiddle = 0, m_nBottomRight = 0;
        
        public int Factor
        {
            get { return m_nFactor; }
            set { m_nFactor = value; }
        }

        public int Offset
        {
            get { return m_nOffset; }
            set { m_nOffset = value; }
        }

        public int TopLeft
        {
            get { return m_nTopLeft; }
            set { m_nTopLeft = value; }
        }

        public int TopMiddle
        {
            get { return m_nTopMiddle; }
            set { m_nTopMiddle = value; }
        }

        public int TopRight
        {
            get { return m_nTopRight; }
            set { m_nTopRight = value; }
        }

        public int MiddleLeft
        {
            get { return m_nMiddleLeft; }
            set { m_nMiddleLeft = value; }
        }

        public int Pixel
        {
            get { return m_nPixel; }
            set { m_nPixel = value; }
        }

        public int MiddleRight
        {
            get { return m_nMiddleRight; }
            set { m_nMiddleRight = value; }
        }

        public int BottomLeft
        {
            get { return m_nBottomLeft; }
            set { m_nBottomLeft = value; }
        }

        public int BottomMiddle
        {
            get { return m_nBottomMiddle; }
            set { m_nBottomMiddle = value; }
        }

        public int BottomRight
        {
            get { return m_nBottomRight; }
            set { m_nBottomRight = value; }
        }

        public void SetAll(int nValue)
        {
            m_nTopLeft = m_nTopMiddle = m_nTopRight =
                m_nMiddleLeft = m_nPixel = m_nMiddleRight =
                m_nBottomLeft = m_nBottomMiddle = m_nBottomRight = nValue;
        }
    }
}

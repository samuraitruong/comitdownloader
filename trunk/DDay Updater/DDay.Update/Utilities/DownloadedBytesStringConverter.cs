using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    static public class DownloadedBytesStringConverter
    {
        static public string Convert(double bytes)
        {
            return Convert(bytes, "0.00");
        }

        static public string Convert(double bytes, string format)
        {
            return Convert(bytes, bytes, format);
        }

        static public string Convert(double bytes, DirectionType direction)
        {
            return Convert(bytes, bytes, direction, "0.00");
        }

        static public string Convert(double bytes, DirectionType direction, string format)
        {
            return Convert(bytes, bytes, direction, format);
        }
        
        static public string Convert(double bytes, double reference)
        {            
            return Convert(bytes, GetConversionType(reference), "0.00");
        }

        static public string Convert(double bytes, double reference, string format)
        {
            return Convert(bytes, GetConversionType(reference), format);
        }

        static public string Convert(double bytes, double reference, DirectionType direction)
        {
            return Convert(bytes, reference, direction, "0.00");
        }
        static public string Convert(double bytes, double reference, DirectionType direction, string format)
        {
            ConversionType conversionType;
            conversionType = GetConversionType(reference);
            conversionType = MoveDirection(conversionType, direction);
            return Convert(bytes, conversionType, format);
        }

        static public string Convert(double bytes, ConversionType conversionType)
        {
            return Convert(bytes, conversionType, "0.00");
        }
        static public string Convert(double bytes, ConversionType conversionType, string format)
        {
            if (conversionType.ToString().Contains("i"))
            {
                return (bytes / Math.Pow(2, (int)conversionType)).ToString(format) +
                    " " +
                    conversionType.ToString();
            }
            else
            {
                return (bytes / Math.Pow(1000, (int)conversionType)).ToString(format) +
                    " " +
                    conversionType.ToString();
            }
        }

        #region Static Private Methods

        static private ConversionType GetConversionType(double reference)
        {
            ConversionType conversionType = ConversionType.MB;
            if (reference < Math.Pow(1000, 2) / 2)
                conversionType = ConversionType.kB;
            else if (reference < Math.Pow(1000, 3) / 2)
                conversionType = ConversionType.MB;
            else if (reference < Math.Pow(1000, 4) / 2)
                conversionType = ConversionType.GB;
            else if (reference < Math.Pow(1000, 5) / 2)
                conversionType = ConversionType.TB;

            return conversionType;
        }

        static private ConversionType MoveDirection(ConversionType conversion, DirectionType direction)
        {            
            int mult = 1;

            if (direction == DirectionType.Down)
                mult = -1;

            try
            {
                ConversionType newConversion = conversion;
                if (conversion.ToString().Contains("i"))
                    newConversion = (ConversionType)((int)conversion + (mult * 10));
                else
                    newConversion = (ConversionType)((int)conversion + mult);

                return newConversion;
            }
            catch
            {
                return conversion;
            }
        }

        #endregion

        public enum ConversionType
        {
            kB = 1,  // 1000 ^ 1
            MB = 2,  // 1000 ^ 2
            GB = 3,  // 1000 ^ 3
            TB = 4,  // 1000 ^ 4
            KiB = 10, // 2 ^ 10
            MiB = 20, // 2 ^ 20
            GiB = 30, // 2 ^ 30
            TiB = 40, // 2 ^ 40
        }

        public enum DirectionType
        {
            Down,
            Up
        }
    }
}

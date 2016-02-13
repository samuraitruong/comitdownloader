using System; using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using ComicDownloader;
using System.Resources;
using System.Windows.Forms;

namespace System
{
    public static class ObjectExtensions
    {
         
        public static void InvokeOnMainThread(this System.Windows.Forms.Control control, Action act)
        {
            control.Invoke(new MethodInvoker(act), null);
        }

        public static void ToFile<T>(this T obj, string filename, string secureKey)
        {
            var temp = Path.GetTempPath() + Path.GetRandomFileName();
            var xml = SerializationHelper.SerializeToXml<T>(obj);
            using (var file = new StreamWriter(File.Open(temp, FileMode.OpenOrCreate)))
            {
                file.Write(xml);
            }

            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            SecureHelper.EncryptFile(temp, filename, secureKey);

        }

        public static T FromFile<T>(this object obj, string filename, string secureKey) 
        {
            T info = default(T);
            try
            {
                if (File.Exists(filename))
                {
                    var temp = Path.GetTempPath() + Path.GetRandomFileName();

                    SecureHelper.DecryptFile(filename, temp, secureKey);

                    using (var file = File.OpenText(temp))
                    {
                        info = SerializationHelper.DeserializeFromXml<T>(file.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return info;

        }




    }
}


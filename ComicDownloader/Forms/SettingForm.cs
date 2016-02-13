using System; using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComicDownloader.Properties;
using Cx.Windows.Forms;

namespace ComicDownloader
{
    public partial class SettingForm : MdiChildForm
    {
        public const string SETTING_FILE = "Appsetting.000";
        public SettingForm()
        {
            InitializeComponent();
        }

         public static void SaveSetting(ComicDownloaderSettings setting)
        {
            var temp = Path.GetTempPath() + Path.GetRandomFileName();
            var xml = SerializationHelper.SerializeToXml<ComicDownloaderSettings>(setting);
            using (var file = new StreamWriter(File.Open(temp, FileMode.OpenOrCreate)))
            {
                file.Write(xml);
            }

            SecureHelper.EncryptFile(temp, SETTING_FILE, Resources.SecureKey);
        }

        public static ComicDownloaderSettings GetSetting() {
          

            if (File.Exists(SETTING_FILE))
            {
                var temp = Path.GetTempPath()+ Path.GetRandomFileName();

                SecureHelper.DecryptFile(SETTING_FILE, temp, Resources.SecureKey);

                using (var file = File.OpenText(temp))
                {
                    return SerializationHelper.DeserializeFromXml<ComicDownloaderSettings>(file.ReadToEnd());
                }
            }
            return new ComicDownloaderSettings();
        }

        
        private void SettingForm_Load(object sender, EventArgs e)
        {
            prgSettings.SelectedObject = GetSetting();
            
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            var obj = prgSettings.SelectedObject;
            SaveSetting(obj as ComicDownloaderSettings);
            this.Close();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

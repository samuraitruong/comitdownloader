using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public interface IDownloadableFile
    {
        FileDownloader GetDownloader();
    }
}

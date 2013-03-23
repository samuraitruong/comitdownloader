using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComicDownloader
{
    public class LongOperation : IDisposable
    {
        public LongOperation()
        {
            Cursor.Current = Cursors.WaitCursor;
        }
        public void Dispose()
        {
            Cursor.Current = Cursors.Default;
        }
    }
}

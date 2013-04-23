using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public class UpdateDownloadException : Exception
    {
        public UpdateDownloadException()
            : base("An error occurred while downloading a file during the update process.") { }
    }
}

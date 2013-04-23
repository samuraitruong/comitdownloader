using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public class ManifestException : Exception
    {
        public ManifestException()
            : base("An error occurred because a manifest was not found, or was not formatted correctly.") { }
    }
}

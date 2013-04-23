using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public interface IVersionManager
    {   
        Version[] LocalVersions { get; }
        void RemoveVersion(Version version);
    }
}

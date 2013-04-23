using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public interface IVersionManager
    {        
        void RemoveVersion(Version version);
    }
}

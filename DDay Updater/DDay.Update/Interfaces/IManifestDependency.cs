using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    /// <summary>
    /// Indicates that the dependency is attached to
    /// another Uri, and may need to be loaded in the
    /// future to gather all relevant information about
    /// the dependency.
    /// </summary>
    public interface IManifestDependency
    {
        void Load();
    }
}

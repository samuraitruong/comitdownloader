using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class Dependency
    {
        #region Private Fields

        private List<Dependency> _Dependencies;
        private Manifest _Parent;        

        #endregion

        #region Public Properties

        public List<Dependency> Dependencies
        {
            get { return _Dependencies; }
            set { _Dependencies = value; }
        }

        public IEnumerable<DependentAssembly> DependentAssemblies
        {
            get
            {
                foreach (Dependency dependency in Dependencies)
                {
                    if (dependency is DependentAssembly)
                        yield return (DependentAssembly)dependency;
                    foreach (DependentAssembly d in dependency.DependentAssemblies)
                        yield return d;
                }
            }
        }

        public Manifest Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }

        #endregion

        #region Constructors

        public Dependency(Manifest parent)
        {
            Dependencies = new List<Dependency>();
            Parent = parent;
        }

        public Dependency(Manifest parent, XmlNode elm, XmlNamespaceManager nsmgr) : this(parent)
        {
            // Load each dependent assembly
            foreach (XmlNode dependentAssembly in
                elm.SelectNodes("asmv2:dependentAssembly", nsmgr))
            {
                Dependencies.Add(new DependentAssembly(
                    Parent,
                    dependentAssembly,
                    nsmgr));
            }
        }

        #endregion
    }
}

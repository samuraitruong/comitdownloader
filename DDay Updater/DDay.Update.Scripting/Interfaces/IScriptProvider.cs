using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update.Scripting
{
    public interface IScriptProvider
    {
        IScript[] Get(DeploymentManifest deploymentManifest);
    }
}

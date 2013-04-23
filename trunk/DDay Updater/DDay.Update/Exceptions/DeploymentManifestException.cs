using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public class DeploymentManifestException : Exception
    {
        public DeploymentManifestException()
            : base("An error occurred because the deployment manifest was not found, or was not formatted correctly.") { }
    }
}

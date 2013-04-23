using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public class RequiresDeploymentManifestException : Exception        
    {
        public RequiresDeploymentManifestException()
            : base("The deployment manifest is required, but could not be found.")
        {
        }
    }
}

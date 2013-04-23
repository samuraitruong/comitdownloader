using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public class ApplicationStartException : Exception
    {
        public ApplicationStartException()
            : base("The application could not be started.") { }
    }
}

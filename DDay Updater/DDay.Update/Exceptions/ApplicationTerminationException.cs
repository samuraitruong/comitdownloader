using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public class ApplicationTerminationException : Exception
    {
        public ApplicationTerminationException()
            : base("The application to be updated did not terminate successfully.")
        {
        }
    }
}

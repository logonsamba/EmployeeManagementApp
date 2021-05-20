using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Exceptions
{
    public class CoreException : Exception
    {
        internal CoreException(string businessMessage)
            : base(businessMessage)
        {
        }

        internal CoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

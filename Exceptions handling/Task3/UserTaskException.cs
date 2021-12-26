using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class UserTaskException : Exception
    {
        public UserTaskException(string message)
            : base(message)
        { 
        
        }
    }
}

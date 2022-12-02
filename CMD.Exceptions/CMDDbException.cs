using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Exceptions
{
    public class CMDDbException : ApplicationException
    {
        public CMDDbException()
        { }
        public CMDDbException(string message) : base(message)
        {
        }
        public CMDDbException(string message, Exception e) : base(message, e)
        { }
    }
}


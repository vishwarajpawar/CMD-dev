using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Exceptions
{
    public class GetAllException:Exception
    {
        public GetAllException()
        {

        }
        public GetAllException(string message): base(message)
        {
            

        }
    }
    
}

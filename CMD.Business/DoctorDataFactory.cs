using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.Business;

namespace CMD.Business
{
    public class DoctorDataFactory
    {
        public static DoctorDataManager Create()
        {
            return new DoctorDataManager();
        }
    }
}

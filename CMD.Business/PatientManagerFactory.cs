using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    ///<summary>Returns an instance of PatientManager which in turn connects with the repositories<summary>///
    public class PatientManagerFactory
    {
        public static IPatientManager Create()
        {
            return new PatientManager();
        }
    }
}

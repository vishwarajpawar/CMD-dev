using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess.IRepositories;
using CMD.DataAccess;
using CMD.Entities;
namespace CMD.DataAccess.Factories
{
    /// <summary>
    ///  Factory class to inject the DoctorRepository object to referanced classes.
    /// </summary>
    public class PatientRepositoryFactory
    {
        public static IPatientRepository Create() 
        {
          return  new PatientRepository();
        }
    }
}

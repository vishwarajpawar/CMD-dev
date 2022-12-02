using CMD.DataAccess.Repository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CMD.UnitTests
{
    public class PatientMockRepository : DataAccess.IRepositories.IPatientRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> Find(string name)
        {
            Business.IPatientManager ipm = new Business.PatientManager();
            List<Patient> patients = new List<Patient> {
            new Patient { Patient_Id = 1, PatientName = "Patient1" },
            new Patient { Patient_Id = 2, PatientName = "Patient2" },
            new Patient { Patient_Id = 3, PatientName = "Patient3" },
            new Patient { Patient_Id = 4, PatientName = "Patient4" },
            new Patient { Patient_Id = 5, PatientName = "Patient5" },
            new Patient { Patient_Id = 6, PatientName = "Patient6" }
            
            };
            return ipm.FindPatient(name);
            
        }

        public IEnumerable<Patient> GetAll()
        {
            Business.IPatientManager ipm = new Business.PatientManager();
            return ipm.GetAllPatients();
        }

        
    }


}

    


using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface IPatientManager:IDisposable
    {
        IEnumerable<Entities.Patient> GetAllPatients();
        IEnumerable<Patient> FindPatient(string name);
        IEnumerable<GetParticularPatient_Result> GetSpecificPatientInfoByID(int id);
        IEnumerable<Entities.Patient> GetAllRecentPatients();
    }
}

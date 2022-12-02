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
    public class SpecificPatientMockRepository : DataAccess.IRepositories.ISpecificPatientRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetParticularPatient_Result> GetSpecificPatientInfo(int id)
        {
            Business.IPatientManager ipm = new Business.PatientManager();
            return ipm.GetSpecificPatientInfoByID(id);
        }
    }


}

    


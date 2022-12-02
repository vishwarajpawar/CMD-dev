using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.IRepositories
{
    public interface ISpecificPatientRepository:IDisposable
    {
        ///<summary>Defines the main structure of SpecificPatientRepository<summary>///
        IEnumerable<GetParticularPatient_Result> GetSpecificPatientInfo(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess.IRepositories;
using CMD.Entities;

namespace CMD.DataAccess.Repository
{
    public class GpBaseRepository
    {
        protected Entities.CMD_DatabaseEntities mycontext;

        public GpBaseRepository()
        {
            mycontext = new Entities.CMD_DatabaseEntities();
        }
    }
    
    ///<summary>Implements all the functionalities of ISpecificPatientRepositories Interface<summary>///
    public class SpecificPatientRepository : GpBaseRepository, ISpecificPatientRepository
    {
        public bool Add(GetParticularPatient_Result item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetParticularPatient_Result> Find(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetParticularPatient_Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public GetParticularPatient_Result GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This returns all the info of the specific patient using id. Here stored procedure GetParticularPatient_Result
        /// in DB is used to return all the data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IEnumerable<GetParticularPatient_Result></returns>
        public IEnumerable<GetParticularPatient_Result> GetSpecificPatientInfo(int id)
        {
            var result = mycontext.GetParticularPatient(id);
            return result.ToList();
        }

        public bool Update(GetParticularPatient_Result item)
        {
            throw new NotImplementedException();
        }
    }
}

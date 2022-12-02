using CMD.DataAccess.IRepositories;
using CMD.Entities;
using CMD.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    ///<summary>Calls the create function which creates the IRepository instances<summary>///
    public class PatientManager:IPatientManager
    {

        readonly IPatientRepository PatientRepo;
        readonly ISpecificPatientRepository SpecificPatientRepo;


        public PatientManager()
        {
            PatientRepo = DataAccess.Factories.PatientRepositoryFactory.Create();
            SpecificPatientRepo = DataAccess.Factories.SpecificPatientRepositoryFactory.Create();

        }

        public PatientManager(IPatientRepository PatientRepo)
        {
            this.PatientRepo = PatientRepo;

        }
        public PatientManager(ISpecificPatientRepository SpecificPatientRepo)
        {
            this.SpecificPatientRepo = SpecificPatientRepo;

        }


        /// <summary>
        /// Calls the Getall() function from the PatientRepository 
        /// </summary>
        /// <returns>IEnumerable<Patient></returns>
        public IEnumerable<Patient> GetAllPatients()
        {
            try
            {
                return PatientRepo.GetAll();
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }




        public IEnumerable<Patient> GetAllRecentPatients()
        {
            try
            {
                return PatientRepo.GetRecentPatients();
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// Calls the Find(string name) function from the PatientRepository 
        /// </summary>
        /// <returns>IEnumerable<Patient></returns>
        public IEnumerable<Patient> FindPatient(string name)
        {
            try
            {
                return PatientRepo.Find(name);
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Calls the GetSpecificPatientInfo(id) function from the SpecificPatientRepository 
        /// </summary>
        /// <returns>IEnumerable<Patient></returns>
        public IEnumerable<GetParticularPatient_Result> GetSpecificPatientInfoByID(int id)
        {
            try
            {


                return SpecificPatientRepo.GetSpecificPatientInfo(id);
            }
            catch (GetAllException ex)
            {
                throw ex;
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

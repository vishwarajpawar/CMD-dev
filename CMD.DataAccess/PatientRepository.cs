using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.Entities;
using CMD.DataAccess.IRepositories;
using System.Data.Entity.Core.Objects;

namespace CMD.DataAccess
{

    /// <summary>
    ///  A Patient Repository Class implementing 'CMD.DataAccess.IRepositories.IPatientRepository' 
    ///  Using Entities from Data Model From CMD.Entities. Using Patient entity and using on it Linq to perform 
    ///  Database Operations
    /// </summary>
    /// 

    public class BaseRepository  // Creating Base Repository 
    {
        protected CMD.Entities.CMD_DatabaseEntities mycontext;

        /// <summary>
        /// Calling BaseRepository for creating new object 
        /// </summary>
        public BaseRepository()
        {
            this.mycontext = new Entities.CMD_DatabaseEntities();
        }
    }

    /// <summary>
    /// Deriving Patient details from Base Repository  
    /// </summary>
    
    public class PatientRepository : BaseRepository, IPatientRepository
    {

        public bool Add(Patient item)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Patient> Find(string name)
        {

            var patients = mycontext.Patients.Where(p => p.PatientName.ToLower().StartsWith(name.ToLower())).OrderBy(p => p.PatientName);
            return patients;
        }
        /// <summary>
        /// Getting all the information from Patient
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAll()
        {
            try
            {
                IEnumerable<Patient> users = from usr in mycontext.Patients
                                             orderby usr.PatientName
                                             select usr;
                

                return users;
            }
            catch (InvalidOperationException ex)
            {

                throw ex;
            }
            
           
        }

        public IEnumerable<Patient> GetRecentPatients()
        {
            try
            {
                //var patients = mycontext.Patients.Where(p => p.Reg_Date >= DateTime.Now.AddDays(-7.0));
                var patients = mycontext.Patients.Where(p => EntityFunctions.AddDays(p.Reg_Date, 7) > DateTime.Now).OrderBy(p => p.PatientName);
                return patients;
            }
            catch (InvalidOperationException ex)
            {

                throw ex;
            }


        }



        public Patient GetById(int id)
        {
            var patient = GetAll().Where(p => p.Patient_Id == id).FirstOrDefault();

            return patient;
        }

        public bool Update(Patient item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllWithTerm(string term) {

            var patients = GetAll().Where(p => p.PatientName.ToLower().StartsWith(term.ToLower())).ToList();
            return patients;
        }

        public int GetId(string name) {

            var patient_id = GetAll().Where(p => p.PatientName == name).Select(p => p.Patient_Id).FirstOrDefault();

            return patient_id;


        }
       
        int IPatientRepository.Add(Patient item)
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    mycontext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

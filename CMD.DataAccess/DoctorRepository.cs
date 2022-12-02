using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess.IRepositories;
using CMD.Entities;
using CMD.Exceptions;
namespace CMD.DataAccess
{
    /// <summary>
    ///  A Doctor Repository Class implementing 'CMD.DataAccess.IRepositories.IDoctorRepository' 
    ///  Using Entities from Data Model From CMD.Entities. Using Doctor entity and using on it Linq to perform 
    ///  Database Operations
    /// </summary>

    public class DoctorRepository : BaseRepository, IRepositories.IDoctorRepository
    {
        public bool Add(Doctor item)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Doctor> Find(string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Getting all the information about Doctor 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Doctor> GetAll()
        {
            try
            {
                var users = from usr in mycontext.Doctors
                            orderby usr.DoctorName
                            select usr;

                return users;
            }
            catch (Exception ex)
            {

                throw new GetAllException(ex.Message);
            }

        }

        public IEnumerable<Doctor> GetAllIssues(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllWithTerm(string term)
        {
            throw new NotImplementedException();
        }

        public Doctor GetById(int id)
        {
            try
            {
                var doc = GetAll().Where(d => d.Doctor_Id == id).FirstOrDefault();
                return doc;
            }
            catch (Exception ex)
            {

                throw new GetAllException(ex.Message);
            }

        }

        public int GetId(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor Doc)
        {
            var context = mycontext.Doctors.Where(x => x.Doctor_Id == Doc.Doctor_Id).FirstOrDefault();
            context.DoctorName = Doc.DoctorName;
            context.NPINumber = Doc.NPINumber;
            context.ParcticeLocation = Doc.ParcticeLocation;
            context.PhoneNumber = Doc.PhoneNumber;
            context.Speciality = Doc.Speciality;
            context.Email = Doc.Email;
            mycontext.SaveChanges();
            mycontext.Dispose();

        }
        int IDoctorRepository.Add(Doctor item)
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

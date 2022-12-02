using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess;
using CMD.Entities;
using CMD.Exceptions;
using CMD.DataAccess.Factories;
using CMD.DataAccess.IRepositories;


namespace CMD.Business
{
    public class DoctorDataManager
    {
    
        
        IDoctorRepository DoctorRepo;
        

        public DoctorDataManager()
        {
            DoctorRepo = DataAccess.Factories.DoctorRepositoryFactory.Create();
        }

        public Doctor GetDoctorById(int id)
        {
            try
            {
                return DoctorRepo.GetById(id);
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }

        public void UpdateDoctorInformation(Doctor doctor)
        {
            try
            {
                DoctorRepo.Update(doctor);
            }

            catch(GetAllException ex)
            {
                throw ex;
            }
        }

    }
}

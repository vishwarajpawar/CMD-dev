using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess;
using CMD.Entities;
using CMD.Exceptions;

namespace CMD.Business
{
    public class BllLogic
    {
        DoctorRepository DoctorRepo = new DoctorRepository();
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

        public void UpdateUser(Doctor doctor)
        {
            DoctorRepo.Update(doctor);
        }

    }
}

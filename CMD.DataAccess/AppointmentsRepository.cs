using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.Entities;
using CMD.DataAccess.IRepositories;
using CMD.Exceptions;
using System.Data.Entity.Core.Objects;

namespace CMD.DataAccess
{
    /// <summary>
    ///  An Appointment Repository Class implementing 'CMD.DataAccess.IRepositories.IAppointmentRepository' 
    ///  Using Entities from Data Model From CMD.Entities. Using Appointment entity and using on it Linq to perform 
    ///  Database Operations
    /// </summary>


    public class AppointmentsRepository : BaseRepository, IAppointmentRepository
    {
        /// <summary>
        ///Method for adding new appointment 
        /// </summary>
        
        public int Add(Appointment item)
        {
            try {

                mycontext.Appointments.Add(item);  
                int result = mycontext.SaveChanges();


                return item.Appointment_Id;
            } 
            catch (Exception ex)
            {
                throw new GetAllException(ex.Message);
            }
        }

        public bool Cancel(int id)
        {
            try
            {
                Appointment appointment = GetById(id);
                appointment.Status = 2;
                appointment.DateTime_CancelAppointment = DateTime.Now;


                if(mycontext.SaveChanges()>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new GetAllException(ex.Message);
            }
        }

        public bool Confirm(int id)
        {
            try
            {
                Appointment appointment = GetById(id);
                appointment.Status = 1;
                appointment.DateTime_ConfirmAppoinment = DateTime.Now;

                if (mycontext.SaveChanges() >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new GetAllException(ex.Message);
            }
        }

        public bool Close(int id)
        {
            try
            {
                Appointment appointment = GetById(id);
                appointment.Status = 3;
                appointment.DateTime_CloseAppoinment = DateTime.Now;


                if (mycontext.SaveChanges() >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new GetAllException(ex.Message);
            }
        }



        /// <summary>
        /// Getting the name to find 
        /// </summary>

        public IEnumerable<Appointment> Find(string name)
        {
            throw new NotImplementedException();
        }
        

        public Appointment GetById(int id)
        {
            try
            {

          
            var app = (from a in mycontext.Appointments
                      where a.Appointment_Id == id
                      select a).FirstOrDefault();

            return (Appointment)app;

            }
            catch (ArgumentNullException ex)
            {

                throw ex;
            }
            catch (NotSupportedException ex)
            {

                throw ex;
            }
            catch (SqlException ex){

                throw ex;
            }
           
        }
        public IEnumerable<MedicalIssue> GetAllIssues(int id)
        {
            try
            {
                var issues = from i in mycontext.MedicalIssues
                             where i.Appointment_Id == id
                             select i;

                return issues;
            }
            catch (Exception ex)
            {

                throw new GetAllException(ex.Message);
            }
           
        }
        public bool Update(Appointment item)
        {
            throw new NotImplementedException();
        }

    
        public IEnumerable<Appointment> GetAllWithTerm(string term)
        {
            throw new NotImplementedException();
        }

        public int GetId(string name)
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
        /// <summary>
        /// Method for Getting Accepted Appintments
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Issue> GetAllIssues()
        {
            var issuesList = from issue in mycontext.Issues select issue;

            return issuesList;
        }


        //---------------------------------------------Dashboard Team-----------------------------------------------------
        public int AcceptedAppointmnets()
        {
            var accepted = from appointment in mycontext.Appointments where appointment.Status == 1 && (EntityFunctions.DiffDays(appointment.DateTime_Appoinment, DateTime.Now) == 0) select appointment;
            int count = accepted.Count();
            return count;
        }
        /// <summary>
        /// Method for Getting Total Appointment Cancelled
        /// </summary>
        /// <returns></returns>
        public int CancelledAppointments()
        {
            var Cancelled = from appointment in mycontext.Appointments where appointment.Status == 2 && (EntityFunctions.DiffDays(appointment.DateTime_Appoinment, DateTime.Now) == 0) select appointment;
            int count = Cancelled.Count();
            return count;
        } 
        /// <summary>
          /// Method for Getting Total Appointment
          /// </summary>
          /// <returns></returns>
        public int TotalAppointments()
        {
            var total = from appointment in mycontext.Appointments where (EntityFunctions.DiffDays(appointment.DateTime_Appoinment, DateTime.Now) == 0) select appointment;
            int count = total.Count();
            return count;
        }

        /// <summary>
        /// Getting all the information of Appointment 
        /// </summary>

        public IEnumerable<Appointment> GetAll()
        {
            try
            {
                var Appointments = from appointments in mycontext.Appointments.Include("Patient") select appointments;
                return Appointments;
            }
            catch (Exception ex)
            {

                throw new GetAllException(ex.Message);
            }

        }

        public IEnumerable<Appointment> GetAll(string Email)
        {
            var Appointments = from appointment in mycontext.Appointments.Include("Patient") where appointment.Doctor.Email == Email select appointment;
            return Appointments;
        }
        public string GetDoctorLocation(string Email)
        {
            var Location = mycontext.Doctors.Where(x => x.Email == Email).Select(x => x.ParcticeLocation).SingleOrDefault().ToString();
            return Location;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CMD.Exceptions;
using CMD.DataAccess;
using CMD.Entities;
using CMD.DataAccess.IRepositories;


namespace CMD.Business

{
    /// <summary>
    /// This class is part of Business layer.
    ///  Appoitement manager class using repository classes. it uses Repository objects and makes call to all repository methods. 
    ///  it combines all the logic required by the UI layer. 
    /// </summary>
    public class AppointmentManager : IAppointmentManager
    {
        // Declering Repository objects of interface type
        IPatientRepository PatientRepo;
        IDoctorRepository DoctorRepo;
        IAppointmentRepository AppRepo;


        public AppointmentManager()
        {
            AppRepo = DataAccess.Factories.AppointmentRepositoryFactory.Create();
            PatientRepo = DataAccess.Factories.PatientRepositoryFactory.Create();
            DoctorRepo = DataAccess.Factories.DoctorRepositoryFactory.Create();
        }


        public AppointmentManager(IAppointmentRepository AppRepo)
        {
            this.AppRepo = AppRepo;
        }
        public AppointmentManager(IDoctorRepository DoctorRepo)
        {
            this.DoctorRepo = DoctorRepo;
        }
        public AppointmentManager(IPatientRepository PatientRepo)
        {
            this.PatientRepo = PatientRepo;
        }


        /// <summary>
        /// get list of all paitents from database
        /// using repository methods.
        /// </summary>
        /// <returns>
        ///  returns 'IEnumerable<Patient>' type.
        /// </returns>
        public IEnumerable<Patient> GetAllPatients()
        {
            try
            {


                return (IEnumerable<Patient>)PatientRepo.GetAll();
            }
            catch (GetAllException ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Gets all the list of Doctores from database. 
        /// </summary>
        /// <returns>DoctorRepo.GetAll()</returns>
        public IEnumerable<Doctor> GetAllDocs()
        {
            try
            {


                return DoctorRepo.GetAll();
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///   Add Appointment to the database passing appointment type object to the appointment repository method 
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>appoitemt id for there recored recently added to the database</returns>
        public int AddAppointment(Appointment appointment)
        {
            try
            {


                int id = AppRepo.Add(appointment);

                return id;
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get Patient By  patient Id
        /// </summary>

        /// <returns>PatientRepo.GetById(id);</returns>
        public Patient GetPatientById(int id)
        {
            try
            {


                return PatientRepo.GetById(id);
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Getting Doctors by Doctor's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Getting Appointment by Id
        /// </summary>
        /// <returns></returns>
        public Appointment GetAppointmentById(int id)
        {
            try
            {


                return AppRepo.GetById(id);
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// get medical issues using IEnumerable 
        /// </summary>

        /// <returns></returns>
        public IEnumerable<string> GetMedicalIssues(int id)
        {
            try
            {


                List<string> ls = new List<string>();
                foreach (var issue in AppRepo.GetAllIssues(id))
                {
                    ls.Add(issue.Name);
                }
                return ls;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Getting All the name of the patients by the patient list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllWithTerm(string term)
        {
            try
            {



                var patients = PatientRepo.GetAllWithTerm(term).Select(p => p.PatientName).ToList();
                return patients;
            }
            catch (GetAllException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get id for patient 
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetPatientId(string name)
        {
            try
            {


                var patient_id = PatientRepo.GetId(name);

                return patient_id;
            }
            catch (GetAllException ex)
            {
                throw ex;
            }


        }

        public bool ValidateAppointmentTime(DateTime time, int id)
        {



            var allAppointment = AppRepo.GetAll();
            var doctor = DoctorRepo.GetById(id);
            foreach (var appointment in allAppointment)
            {
                if (appointment.Doc_Id == doctor.Doctor_Id && appointment.DateTime_Appoinment.Date == time.Date)
                {
                    TimeSpan interval = time - appointment.DateTime_Appoinment;
                    if (time == appointment.DateTime_Appoinment && (interval.Minutes > 30))
                    {
                        return true;
                    }

                    return false;
                }

            }
            return true;
        }
        //------------------------------------------------------------------------------------------dashboard team---------------------------------------------
        /// <summary>
        /// To Get Total Number of Accepted Appointments
        /// </summary>

        public int AppointmentAccepted()
        {
            try
            {
                return AppRepo.AcceptedAppointmnets();
            }
            catch (CustomException ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// To Get Total Number of Cancelled Appointments
        /// </summary>
        public int AppointmentCancelled()
        {
            try
            {
                return AppRepo.CancelledAppointments();
            }
            catch (CustomException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// To Get Total Number of Appointments
        /// </summary>
        public int AppointmentAll()
        {
            try
            {
                return AppRepo.TotalAppointments();
            }
            catch (CustomException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// To Get Total Number of Appointments in Grid View
        /// </summary>
        public IEnumerable<Appointment> GetAllAppointment()
        {
            try
            {
                return AppRepo.GetAll();
            }
            catch (CustomException ex)
            {
                throw ex;
            }

        }
        public IEnumerable<Appointment> GetAllAppointment(string Email)
        {
            try
            {
                return AppRepo.GetAll(Email);
            }
            catch (CustomException ex)
            {
                throw ex;
            }

        }
        public bool Cancel(int id)
        {
            bool isCancelled = false;
            try
            {
                isCancelled = AppRepo.Cancel(id);

                return isCancelled;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Issue> GetIssues()
        {
            return AppRepo.GetAllIssues().ToList();
        }
        public string GetDoctorLocation(string Email)
        {
            return AppRepo.GetDoctorLocation(Email);
        }
    }
}

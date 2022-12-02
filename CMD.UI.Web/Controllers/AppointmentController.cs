using CMD.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMD.Business;
using CMD.Entities;

namespace CMD.UI.Web.Controllers

// <summary>
///  An Appointment Controller Class implementing 
/// </summary>
{
    [Authorize]
    public class AppointmentController : Controller
    {
        Business.IAppointmentManager appointmentmanager;


        /// <summary>
        /// Creating Appointment manager factory Using Business Layer
         /// </summary>
        public AppointmentController()
        {
            appointmentmanager =  Business.AppointmentManagerFactory.Create();
        }

        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Getting Action On Appointment
        /// it uses object of AppointmentViewModel
        /// It Shows Name of Doctor and Patient and also List of Issues name like Hand Issue, Head Issue etc.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult AddAppointment()
        {

            AppointmentViewModel AP = new AppointmentViewModel();

            var list = appointmentmanager.GetAllPatients();
            var DocList = appointmentmanager.GetAllDocs();
            AP.Patients = new SelectList(list, "Patient_Id", "PatientName");
            AP.Doctors = new SelectList(DocList, "Doctor_Id", "DoctorName");

            List<SelectListItem> Issueslist = appointmentmanager.GetIssues().ConvertAll(a =>


            {
                return new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Name



                };



            });


            AP.Issues = Issueslist;

            return View(AP);

        }


        /// <summary>
        /// Getting Result On Appointment
        /// it uses object of AppointmentViewModel
        /// It Shows Name of Doctor and Patient and also List of Issues name like Hand Issue, Head Issue etc.
        /// link:http://localhost:44364/Appointment/AddAppointment/
        /// </summary>
        /// <returns></returns>



        //Getting Result of Add Appointment
        [HttpPost]
        [ValidateAntiForgeryToken]
            
        public ActionResult AddAppointment(AppointmentViewModel appointment)
        {
            if (ModelState.IsValid)
            {
                Appointment ap = new Appointment();

                
                //appointment.Patient_Id = appointment.Patient_Id;
                appointment.Patient_Id = appointmentmanager.
                    GetPatientId(appointment.PatientName);
                ap.Patient_Id = appointment.Patient_Id;
                ap.Doc_Id = appointment.Doctor_Id;
                ap.DoctorsNote = "NA";
                ap.Comment = appointment.Reason;
                ap.Status = 0;
                ap.DateTime_Appoinment = new DateTime(appointment.Date.Year, appointment.Date.Month, appointment.Date.Day, appointment.Time.Hour, appointment.Time.Minute, appointment.Time.Second);



                bool checkTime = appointmentmanager.ValidateAppointmentTime(ap.DateTime_Appoinment,ap.Doc_Id);
                if (!checkTime)
                {
                    ModelState.AddModelError("time", "Appoitment slot booked already!!");

                    var list = appointmentmanager.GetAllPatients();
                    appointment.Patients = new SelectList(list, "Patient_Id", "PatientName");
                    var DocList = appointmentmanager.GetAllDocs();
                    appointment.Doctors = new SelectList(DocList, "Doctor_Id", "DoctorName");


                    List<SelectListItem> Issueslist = appointmentmanager.GetIssues().ConvertAll(a =>


                    {
                        return new SelectListItem()
                        {
                            Text = a.Name,
                            Value = a.Name



                        };



                    });

                    
                    appointment.Issues = Issueslist;

                    return View(appointment);
                }


                foreach (var issue in appointment.MedicalIssues)
                {
                    ap.MedicalIssues.Add(new MedicalIssue() { Patient_Id = appointment.Patient_Id, Name = issue });
                }


                var result = appointmentmanager.AddAppointment(ap);


                appointment.AppointmentId = result;
               
                if (result != 0)
                    return RedirectToAction("ViewAppointmentSummary", appointment);
            }
            else {
                var list = appointmentmanager.GetAllPatients();
                appointment.Patients = new SelectList(list, "Patient_Id", "PatientName");
                var DocList = appointmentmanager.GetAllDocs();
                appointment.Doctors = new SelectList(DocList, "Doctor_Id", "DoctorName");


                List<SelectListItem> Issueslist = appointmentmanager.GetIssues().ConvertAll(a =>


                {
                    return new SelectListItem()
                    {
                        Text = a.Name,
                        Value = a.Name
                    };
                });



                appointment.Issues = Issueslist;

                return View(appointment);
            }
            return View(appointment);
        }


        //Getting  View Appointment Summary
        /// <summary>
        /// Its Show the Output Patient Name ,Doctor Name ,Medical Issue And DateTime
        /// link:http://localhost:44364/Appointment/AddAppointment/ViewAppointSummary
        /// </summary>

        [HttpGet]
        
        public ActionResult ViewAppointmentSummary(AppointmentViewModel appointment)
        {

            appointment.Patient = appointmentmanager.GetPatientById(appointment.Patient_Id);
            appointment.Doctor = appointmentmanager.GetDoctorById(appointment.Doctor_Id);
            appointment.MedicalIssues = appointmentmanager.GetMedicalIssues(appointment.AppointmentId);
            appointment.DateTime = new DateTime(appointment.Date.Year, appointment.Date.Month, appointment.Date.Day, appointment.Time.Hour, appointment.Time.Minute, appointment.Time.Second);

            return View(appointment);
        }


        /// <summary>
        /// Gets list of All Patients based on term searched
        /// Returns json result to incoming request by jquery method autocomplete which is written in View
        /// </summary>
       
        public JsonResult GetPatients(string term)
        {
            List<string> patients = appointmentmanager.GetAllWithTerm(term).ToList();

            return Json(patients, JsonRequestBehavior.AllowGet);
        }

    }
}
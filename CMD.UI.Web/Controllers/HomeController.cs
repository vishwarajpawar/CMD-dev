using CMD.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMD.UI.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IAppointmentManager appointmentmanager;

        public HomeController()
        {
            appointmentmanager = CMD.Business.AppointmentManagerFactory.Create();
        }

        /// <summary>
        /// Action Method for Dashboard
        /// </summary>

        [HttpGet]
        public ActionResult Index()
        {
            var result = appointmentmanager.AppointmentAccepted();
            ViewBag.message = result;
            var result1 = appointmentmanager.AppointmentCancelled();
            ViewBag.message1 = result1;
            var result2 = appointmentmanager.AppointmentAll();
            ViewBag.message2 = result2;
            var Location = appointmentmanager.GetDoctorLocation(User.Identity.Name);
            ViewBag.DoctorLocation = Location;
            var appointments = appointmentmanager.GetAllAppointment(User.Identity.Name);
            return View(appointments);
        }

        /// <summary>
        /// Action Method for Filter 
        /// </summary>
        [HttpPost]
        public ActionResult Index(string datefilter)
        {
            var option = Request.Form["filter"];
            var result = appointmentmanager.AppointmentAccepted();
            ViewBag.message = result;
            var result1 = appointmentmanager.AppointmentCancelled();
            ViewBag.message1 = result1;
            var result2 = appointmentmanager.AppointmentAll();
            ViewBag.message2 = result2;
            var Location = appointmentmanager.GetDoctorLocation(User.Identity.Name);
            ViewBag.DoctorLocation = Location;
            if (option == "4")
            {
                var appointments = appointmentmanager.GetAllAppointment(User.Identity.Name);
                return View(appointments);
            }
            else if (option != null)
            {
                var appointments = appointmentmanager.GetAllAppointment(User.Identity.Name).Where(x => x.Status == int.Parse(option));
                return View(appointments);
            }
            else
            {
                var datefilterappointments = appointmentmanager.GetAllAppointment(User.Identity.Name).Where(x => x.DateTime_Appoinment.ToString("yyy-MM-dd") == datefilter);
                return View(datefilterappointments);
            }



        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
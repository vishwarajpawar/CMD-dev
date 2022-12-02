using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMD.Entities;
using CMD.Business;

namespace CMD.UI.Web.Controllers
{
    public class ViewAppointmentController : Controller
    {

        IAppointmentManager AppointmentManager;

        public ViewAppointmentController()
        {
            AppointmentManager = AppointmentManagerFactory.Create();
        }

        // GET: ViewAppointment
        public ActionResult Index(string id)
        {
            //1. Get the  Appointment Information
            //Appointment appointment = GetAppointment(Convert.ToInt32(id));

            //if(appointment != null)
                //WRite you code here

            return View();
        }

        public ActionResult Approve(string id)
        {
           
            return View();
        }
        public ActionResult Cancel(string id)
        {
            if (id != null)
                AppointmentManager.Cancel(Convert.ToInt32( id));

            return View();
        }
        public ActionResult Close(string id)
        {

            return View();
        }
        public ActionResult SaveComments(Appointment appointment)
        {

            return View();
        }

        public Appointment GetAppointment(int appointmentId)
        {
            Appointment appointment = null;

            if (appointmentId > 0)
                appointment = AppointmentManager.GetAppointmentById(appointmentId);

    

            return appointment;
        }
    }
}
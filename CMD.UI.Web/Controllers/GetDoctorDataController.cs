using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMD.UI.Web.Models;
using CMD.Business;
using CMD.Exceptions;
using CMD.Entities;

namespace CMD.UI.Web.Controllers
{
    [Authorize]
    public class GetDoctorDataController : Controller
    {

        Business.DoctorDataManager BL;

        public GetDoctorDataController()
        {
            BL = Business.DoctorDataFactory.Create();
        }

        // GET: GetDoctorData
        public ActionResult ViewDoctorData(int id)
        {
            Doctor doc = BL.GetDoctorById(id);
            return View(doc);
        }
        [HttpGet]
        public ActionResult EditDoctorData(int id)
        {
            Doctor doc = BL.GetDoctorById(id);
            return View(doc);
        }
        [HttpPost]
        public ActionResult Save(Doctor doctor)
        {
            BL.UpdateDoctorInformation(doctor);
            int id = doctor.Doctor_Id;
            return RedirectToAction("viewdoctordata", new {id});

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMD.Business;
using PagedList.Mvc;
using PagedList;
using CMD.Exceptions;
using CMD.Entities;



namespace CMD.UI.Web.Controllers
{
    [Authorize]
    public class ViewPatientController : Controller
    {


        Business.IPatientManager patientManager;
        public ViewPatientController()
        {
            patientManager = Business.PatientManagerFactory.Create();
        }

        public ViewPatientController(IPatientManager patientManager)
        {
           patientManager = Business.PatientManagerFactory.Create();
        }

        /// <summary>
        /// To display no. of required patients info using pagination starting from one page and having
        /// limit of 4 patients info.
        /// </summary>
        /// <param name="page"></param>
        /// <returns> ActionResult </returns>
        [HttpGet]
        public ActionResult Index(int? page =1)
        {
            var users = patientManager.GetAllPatients();


            int Size_Of_Page = 4;
            int No_Of_Page = (page ?? 4);

            //return View(users);

            return View(users.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        /// <summary>
        /// This is to display the patient info by searching with name.
        /// </summary>
        /// <param name="search"></param>
        /// <returns>ActionResult</returns>
       

        [HttpPost]
        public ActionResult Index(string search)
        {
            if (search != "recentPatients")
            {
                return View(patientManager.FindPatient(search).ToPagedList(1, 6));
            }
            else if (search == "recentPatients")
            {
                return View(patientManager.GetAllRecentPatients().ToPagedList(1, 6));
            }
            else
            {
                return View();
            }
        }




        /// <summary>
        ///
        /// This is to display the all the details of the patient like appointment history etc
        /// </summary>
        ///
        /// <param name="id"></param>
        /// <returns>ActionResult</returns>
        [HttpPost]

        public ActionResult IndexGP(int id)
        {
            //Class1 PatientRepo = new Class1();

            ClassSpecificPatient Sp = new ClassSpecificPatient();
            return View(Sp.getSpecificPatient(id));
        }
        



    }
}
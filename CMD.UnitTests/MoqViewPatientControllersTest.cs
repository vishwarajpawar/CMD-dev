using CMD.DataAccess.IRepositories;
using CMD.UI.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Xunit;
using PagedList;

namespace CMD.UnitTests
{
    /// <summary>
    /// Unit Tests Of all major functionalities
    /// </summary>
    [TestClass]
    public class MoqViewPatientControllersTest
    {
        private CMD.UI.Web.Controllers.ViewPatientController _controller;

        [TestMethod]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            _controller = new CMD.UI.Web.Controllers.ViewPatientController();
            var result = _controller.Index(2) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_ActionExecutes_ReturnsViewForIndexGP()
        {
            _controller = new CMD.UI.Web.Controllers.ViewPatientController();
            var result = _controller.IndexGP(2) as ViewResult;
            Assert.IsNotNull(result);
        }

        
        [TestMethod]
        public void TestGetAllPatient()
        {
            PatientMockRepository patientRepo = new PatientMockRepository();
        
            Mock<IPatientRepository> mockApRop = new Mock<IPatientRepository>();
            mockApRop.Setup(ar => ar.GetAll()).Returns(patientRepo.GetAll());
            Business.PatientManager manager = new Business.PatientManager(mockApRop.Object);
            var obj = manager.GetAllPatients().ToList();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(List<Entities.Patient>));
            Assert.AreEqual(9, obj.Count);
        }

        [TestMethod]
        public void TestSearchPatientByName()
        {
            PatientMockRepository patientRepo = new PatientMockRepository();

            Mock<IPatientRepository> mockApRop = new Mock<IPatientRepository>();
            mockApRop.Setup(ar => ar.Find("J")).Returns(patientRepo.Find("J"));
            Business.PatientManager manager = new Business.PatientManager(mockApRop.Object);
            var obj = manager.FindPatient("J").ToList();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(List<Entities.Patient>));
            Assert.AreEqual(2, obj.Count);
        }

        [TestMethod]
        public void TestSearchSpecificPatientByName()
        {
            SpecificPatientMockRepository patientRepo = new SpecificPatientMockRepository();

            Mock<ISpecificPatientRepository> mockApRop = new Mock<ISpecificPatientRepository>();
            mockApRop.Setup(ar => ar.GetSpecificPatientInfo(1)).Returns(patientRepo.GetSpecificPatientInfo(1));
            Business.PatientManager manager = new Business.PatientManager(mockApRop.Object);
            var obj = manager.GetSpecificPatientInfoByID(1).ToList();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(List<Entities.GetParticularPatient_Result>));
            Assert.AreEqual(6, obj.Count);
        }
    }
}

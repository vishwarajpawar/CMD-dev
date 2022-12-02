using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CMD;
using CMD.UI.Web.Controllers;
using System.Web.Mvc;
using CMD.DataAccess;
using CMD.DataAccess.IRepositories;
using CMD.Entities;
using Moq;
using CMD.Business;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// summary for Mocking Unit Testing//
/// </summary>


namespace CMD.UnitTests
{

    /// <summary>
    /// Summary For Mocking Appointment Manager
    /// </summary>

    [TestClass]
    public class MockingAppointmentManager
    {

        [TestMethod]
        public void TestGetAppointmentById()
        {

            //arrange

            AppointmentsRepository aprepo = new AppointmentsRepository();


            // Mock the Appointment Repository using Moq
            Mock<IAppointmentRepository> mockApRop = new Mock<IAppointmentRepository>();


            // Complete the setup of our Mock Appointment Repository
            mockApRop.Setup(ar => ar.GetById(It.IsAny<int>())).Returns((int i) => aprepo.GetById(i));

            //act
            
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);

            // verify that our new Appointment has been saved
            Appointment obj = (Appointment)manager.GetAppointmentById(3);
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(Appointment));
            Assert.AreEqual(3, obj.Appointment_Id);


        }


        /// <summary>
          //for Patient By Id
        /// </summary>
        [TestMethod]
        public void TestGetPatientById()
        {

            //arrange

            //Create object of Appointment Repository 
            PatientRepository patientRepo = new PatientRepository();


            // Mock the IPatient Repository using Moq
            Mock<IPatientRepository> mockApRop = new Mock<IPatientRepository>();


            // // Complete the setup of our Mock Patient Repository
            mockApRop.Setup(ar => ar.GetById(It.IsAny<int>())).Returns((int i) => patientRepo.GetById(i));

          
            
            //act//
            
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);


            // verify that our new Patient has been saved
            Patient obj = manager.GetPatientById(6);
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(Patient));
            Assert.AreEqual("Neemesha Sharma", obj.PatientName);


        }
        /// <summary>
        /// For Get All Patient
        /// </summary>

        [TestMethod]
            public void TestGetAllPatient()
            {   

                //arrange
                //Create object for Patient Repository
                PatientRepository patientRepo = new PatientRepository();

                //// Mock the IPatient Repository using Moq
               Mock<IPatientRepository> mockApRop = new Mock<IPatientRepository>();




                mockApRop.Setup(ar => ar.GetAll()).Returns(patientRepo.GetAll());

                //act
                AppointmentManager manager = new AppointmentManager(mockApRop.Object);



                var obj = manager.GetAllPatients().ToList();
                //assert
                Assert.IsNotNull(obj);
                Assert.IsInstanceOfType(obj, typeof(List<Patient>));
                Assert.AreEqual(9, obj.Count);


            }

        

        [TestMethod]
        public void TestGetAllDoctors() 
        {
            DoctorRepository DoctorRepo = new DoctorRepository();

            Mock<IDoctorRepository> mockApRop = new Mock<IDoctorRepository>();

            mockApRop.Setup(ar => ar.GetAll()).Returns(DoctorRepo.GetAll());

            //act
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);



            var obj = manager.GetAllDocs().ToList();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(List<Doctor>));
            Assert.AreEqual(7, obj.Count);
        }


        [TestMethod]
        public void TestGetDoctorById()
        {

            //arrange

            DoctorRepository DoctorRepo = new DoctorRepository();

            Mock<IDoctorRepository> mockApRop = new Mock<IDoctorRepository>();

            mockApRop.Setup(ar => ar.GetById(It.IsAny<int>())).Returns((int i) => DoctorRepo.GetById(i));

            //act
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);



            Doctor obj = manager.GetDoctorById(4);
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(Doctor));
            Assert.AreEqual("Elizabeth Savannah", obj.DoctorName);


        }
        //-------------------------------------------------------------Dashboard Team ------------------------------------------------------------------

        /// <summary>
        /// To Get All Appointments in Grid View
        /// </summary>

        [TestMethod]
        public void TestGetAllAppointments()
        {

            //arrange

            AppointmentsRepository AppRepo = new AppointmentsRepository();

            Mock<IAppointmentRepository> mockApRop = new Mock<IAppointmentRepository>();

            mockApRop.Setup(ar => ar.GetAll()).Returns(AppRepo.GetAll());

            //act
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);



            var obj = manager.GetAllAppointment().ToList();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(List<Appointment>));
            Assert.AreEqual(31, obj.Count);


        }

        /// <summary>
        /// To Get Count All Accepted Apppointments
        /// </summary>


        [TestMethod]
        public void TestGetAccepted()
        {

            //arrange

            AppointmentsRepository AppRepo = new AppointmentsRepository();

            Mock<IAppointmentRepository> mockApRop = new Mock<IAppointmentRepository>();

            mockApRop.Setup(ar => ar.AcceptedAppointmnets()).Returns(AppRepo.AcceptedAppointmnets());

            //act
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);



            var obj = manager.AppointmentAccepted();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.Int32));
            Assert.AreEqual(10, obj);


        }

        /// <summary>
        /// To Get Count All Cancelled Appointments
        /// </summary>

        [TestMethod]
        public void TestGetCancelled()
        {

            //arrange

            AppointmentsRepository AppRepo = new AppointmentsRepository();

            Mock<IAppointmentRepository> mockApRop = new Mock<IAppointmentRepository>();

            mockApRop.Setup(ar => ar.CancelledAppointments()).Returns(AppRepo.CancelledAppointments());

            //act
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);



            var obj = manager.AppointmentCancelled();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.Int32));
            Assert.AreEqual(0, obj);


        }

        /// <summary>
        /// To Get Count of Total Number of Appointments
        /// </summary>

        [TestMethod]
        public void TestGetTotalAppointment()
        {

            //arrange

            AppointmentsRepository AppRepo = new AppointmentsRepository();

            Mock<IAppointmentRepository> mockApRop = new Mock<IAppointmentRepository>();

            mockApRop.Setup(ar => ar.TotalAppointments()).Returns(AppRepo.TotalAppointments());

            //act
            AppointmentManager manager = new AppointmentManager(mockApRop.Object);



            var obj = manager.AppointmentAll();
            //assert
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.Int32));
            Assert.AreEqual(10, obj);


        }
    }
}

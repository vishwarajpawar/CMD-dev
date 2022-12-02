using CMD.Entities;
using System;
using System.Collections.Generic;

namespace CMD.Business
{
    public interface IAppointmentManager
    {
        int AddAppointment(Appointment appointment);
        int AppointmentAccepted();
        int AppointmentAll();
        int AppointmentCancelled();
        IEnumerable<Appointment> GetAllAppointment();
        IEnumerable<Appointment> GetAllAppointment(string Email);
        IEnumerable<Doctor> GetAllDocs();
        IEnumerable<Patient> GetAllPatients();
        IEnumerable<string> GetAllWithTerm(string term);
        Appointment GetAppointmentById(int id);
        Doctor GetDoctorById(int id);
        IEnumerable<string> GetMedicalIssues(int id);
        Patient GetPatientById(int id);
        int GetPatientId(string name);
        bool ValidateAppointmentTime(DateTime time, int id);

        bool Cancel(int id);
        List<Issue> GetIssues();

        string GetDoctorLocation(string Email);
    }
}
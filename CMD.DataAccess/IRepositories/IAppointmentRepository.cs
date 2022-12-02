using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.Entities;

//Interface Repository for Appointment//

namespace CMD.DataAccess.IRepositories
{  
  public  interface IAppointmentRepository : IDisposable // Creating Interface //
    {
        //Fetching Details of the Appointment Repository//

        IEnumerable<Appointment> GetAll(); 
        Appointment GetById(int id);
        IEnumerable<Appointment> Find(string name);
        bool Update(Appointment item);
        IEnumerable<Appointment> GetAllWithTerm(string term);
        int GetId(string name);
        IEnumerable<MedicalIssue> GetAllIssues(int id); 
        int Add(Appointment item);
        int AcceptedAppointmnets();
        int CancelledAppointments();
        int TotalAppointments();
        IEnumerable<Appointment> GetAll(string Email);

        IEnumerable<Issue> GetAllIssues();
        bool Cancel(int id);
        string GetDoctorLocation(string Email);
    }
}

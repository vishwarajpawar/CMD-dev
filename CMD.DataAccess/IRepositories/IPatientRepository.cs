using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface for Patient Repository //
namespace CMD.DataAccess.IRepositories
{
   public interface IPatientRepository : IDisposable //Creating Interface//
    {

        // fetching details of Patient Repository//


        IEnumerable<Patient> GetAll();
        IEnumerable<Entities.Patient> GetRecentPatients();
        Patient GetById(int id);    
        IEnumerable<Patient> Find(string name); 
        bool Update(Patient item);  //
        IEnumerable<Patient> GetAllWithTerm(string term);
        int GetId(string name);
        int Add(Patient item);
    }
}

using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Interface for  Doctor Repository// 
namespace CMD.DataAccess.IRepositories
{
   public  interface IDoctorRepository : IDisposable
    {

        // fetching details of Doctor Repository//

        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        IEnumerable<Doctor> Find(string name);
        void Update(Doctor Doc);
        int GetId(string name);
        int Add(Doctor item);
    }
}

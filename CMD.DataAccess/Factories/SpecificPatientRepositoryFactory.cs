using CMD.DataAccess.IRepositories;
using CMD.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.Factories
{
    public class SpecificPatientRepositoryFactory
    {
        ///<summary>Returns an instance of Specific Patient Repository which Implements the functionalities<summary>///
        public static ISpecificPatientRepository Create()
        {
            return new SpecificPatientRepository();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess;


namespace CMD.Business
{
    public class ClassSpecificPatient
    {
        public List<Entities.GetParticularPatient_Result> getSpecificPatient(int id)
        {
            //var dal = new DataAccess.Repository.PatientRepository();
             var  ds = new DataAccess.Repository.SpecificPatientRepository();
            return ds.GetSpecificPatientInfo(id).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.Business;
/// <summary>
/// Creating Appointment Manager Factory 
/// </summary>
namespace CMD.Business
{
    public class AppointmentManagerFactory
    {
        public static IAppointmentManager Create()
        {
            return new AppointmentManager();
        }

       
    }
}

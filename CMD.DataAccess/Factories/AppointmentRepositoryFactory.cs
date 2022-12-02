using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess.IRepositories;
using CMD.DataAccess;
using CMD.Entities;
namespace CMD.DataAccess.Factories
{
    /// <summary>
    ///     Factory class to inject the AppointmentRepository object to referanced classes.
    /// </summary>
    public class AppointmentRepositoryFactory
    {
       public static IAppointmentRepository Create()
        {
            return new AppointmentsRepository();
        }
    }
}

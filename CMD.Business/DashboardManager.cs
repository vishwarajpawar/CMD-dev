
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DataAccess;
using CMD.DataAccess.IRepositories;
using CMD.Entities;
using CMD.Exceptions;
namespace CMD.Business
{
    public class DashboardManager
    {
        IAppointmentRepository AppRepo;
        public DashboardManager()
        {
            AppRepo = DataAccess.Factories.AppointmentRepositoryFactory.Create();
        }
        public DashboardManager(IAppointmentRepository AppRepo)
        {
            this.AppRepo = AppRepo;
        }
        public int AppointmentAccepted()
        {
            try
            {
                return AppRepo.AcceptedAppointmnets();
            }
            catch (CMDDbException ex)
            {
                throw ex;
            }
        }
        public int AppointmentCancelled()
        {
            try
            {
                return AppRepo.CancelledAppointments();
            }
            catch (CMDDbException ex)
            {
                throw ex;
            }
        }
        public int AppointmentAll()
        {
            try
            {
                return AppRepo.TotalAppointments();
            }
            catch (CMDDbException ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Appointment> GetAllAppointment()
        {
            try
            {
                return AppRepo.GetAll();
            }
            catch (CMDDbException ex)
            {
                throw ex;
            }
        }
    }
}


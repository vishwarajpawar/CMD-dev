using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Custom Validation  for Appointment and Appointment should be or more than Today's Date 
/// </summary>
namespace CMD.UI.Web.Custom_Validation
{
    public class CustomAppointmentDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value).Date;
            DateTime validDate = DateTime.Now.AddDays(30);
            
            return dateTime >= DateTime.Now.Date && dateTime <= validDate;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMD.Business;
using CMD.Entities;


/// <summary>
/// Custom Validation  for Registered User and Patient Id should be Greater thane zero 
/// </summary>
namespace CMD.UI.Web.Custom_Validation
{
    public class CustomIsRegisteredUser : ValidationAttribute
    {
        public override bool IsValid(object value) 
        {

            AppointmentManager BL = new AppointmentManager();
            int patient = BL.GetPatientId((string)value);

            return patient>0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Custom Validation for Time and Time should be Between 9.00 am to 7.00 pm
/// </summary>
namespace CMD.UI.Web.Custom_Validation
{
    public class CustomTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);

            return dateTime.Hour <= 19 && dateTime.Hour >= 9;
        }
    }
}
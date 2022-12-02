using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMD.Entities;
using CMD.UI.Web.Custom_Validation;

/// <summary>
///  description of Appointment View Model and using Entities and Custom Validation
/// </summary>
namespace CMD.UI.Web.ViewModel
{
    /// <summary>
    /// Method for AppointmentViewModel
    /// </summary>

    public class AppointmentViewModel
    {
    /// <summary>
    /// Validation for all the methods present in the Custom Validation and also throwing the error message for wrong input
    /// </summary>

        public SelectList Patients { get; set; }
        [Required]
        public int Patient_Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Please write Name")]
        [CustomIsRegisteredUser(ErrorMessage ="User Is not Registered!!")]
        public string PatientName { get; set; }
        [Required]
        public int Doctor_Id { get; set; }
        
        public SelectList Doctors { get; set; }

        [Display(Name = "Select Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is a required filed")]
        [CustomAppointmentDate(ErrorMessage = "Date must be Grater than or equal to Today's Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Select Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Time is a required filed")]
        [CustomTimeAttribute(ErrorMessage = "Time must be between 9 AM to 7 PM")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please specify the reason for Appointment")]
        public string Reason { get; set; }
        [Required]
        public IEnumerable<string> MedicalIssues { get; set; }
        public IEnumerable<SelectListItem> Issues { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        
        public int AppointmentId { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime DateTime_ConfirmAppointment { get; set; }

        public DateTime DateTime_CancelAppointment { get; set; }

        public DateTime DateTime_CloseAppointment { get; set; }

        public byte Status { get; set; }
    }
}
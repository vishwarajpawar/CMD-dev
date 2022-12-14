
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CMD.Entities
{

using System;
    using System.Collections.Generic;
    
public partial class Appointment
{
        public DateTime DateTime_CancelAppointment;
        public DateTime DateTime_CloseAppoinment;
        public DateTime DateTime_ConfirmAppoinment;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Appointment()
    {

        this.Tests = new HashSet<Test>();

        this.MedicalIssues = new HashSet<MedicalIssue>();

        this.Prescriptions = new HashSet<Prescription>();

    }


    public int Appointment_Id { get; set; }

    public int Patient_Id { get; set; }

    public int Doc_Id { get; set; }

    public byte Status { get; set; }

    public System.DateTime DateTime_Appoinment { get; set; }

    public string Comment { get; set; }

    public string DoctorsNote { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Test> Tests { get; set; }

    public virtual Doctor Doctor { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<MedicalIssue> MedicalIssues { get; set; }

    public virtual Patient Patient { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Prescription> Prescriptions { get; set; }



}

}

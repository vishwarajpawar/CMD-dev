
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
    
public partial class Symptom
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Symptom()
    {

        this.Patient_Symptom = new HashSet<Patient_Symptom>();

    }


    public int SymptomId { get; set; }

    public string SymptomName { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Patient_Symptom> Patient_Symptom { get; set; }

}

}
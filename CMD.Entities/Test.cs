
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
    
public partial class Test
{

    public int Test_Id { get; set; }

    public string TestName { get; set; }

    public int Appointment_Id { get; set; }



    public virtual Appointment Appointment { get; set; }

}

}

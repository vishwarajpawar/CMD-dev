
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
    
public partial class Recommendation
{

    public int Recommendation_Id { get; set; }

    public int Rec_Doctor_Id { get; set; }

    public int Patient_Id { get; set; }



    public virtual Doctor Doctor { get; set; }

    public virtual Patient Patient { get; set; }

}

}
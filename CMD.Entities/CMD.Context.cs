﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class CMD_DatabaseEntities : DbContext
{
    public CMD_DatabaseEntities()
        : base("name=CMD_DatabaseEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<ActiveIssue> ActiveIssues { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<MedicalIssue> MedicalIssues { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Patient_Symptom> Patient_Symptom { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Recommendation> Recommendations { get; set; }

    public virtual DbSet<Symptom> Symptoms { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Vital> Vitals { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }


    public virtual ObjectResult<GetBYId_Result> GetBYId(Nullable<int> id)
    {

        var idParameter = id.HasValue ?
            new ObjectParameter("id", id) :
            new ObjectParameter("id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBYId_Result>("GetBYId", idParameter);
    }


    public virtual ObjectResult<GetParticularPatient_Result> GetParticularPatient(Nullable<int> id)
    {

        var idParameter = id.HasValue ?
            new ObjectParameter("id", id) :
            new ObjectParameter("id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetParticularPatient_Result>("GetParticularPatient", idParameter);
    }

}

}

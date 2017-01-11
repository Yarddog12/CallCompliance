﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CallCompliance.DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CallComplianceModelContainer : DbContext
    {
        public CallComplianceModelContainer()
            : base("name=CallComplianceModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int AddExceptionsPhoneNumber(string phoneNumber, Nullable<System.DateTime> dateTimeExceptionGranted, string requestorId, string requestorName, string requestorDepartment, Nullable<int> exceptionReasonId, Nullable<int> syStudentId, string nameAssigned, string notes)
        {
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var dateTimeExceptionGrantedParameter = dateTimeExceptionGranted.HasValue ?
                new ObjectParameter("DateTimeExceptionGranted", dateTimeExceptionGranted) :
                new ObjectParameter("DateTimeExceptionGranted", typeof(System.DateTime));
    
            var requestorIdParameter = requestorId != null ?
                new ObjectParameter("RequestorId", requestorId) :
                new ObjectParameter("RequestorId", typeof(string));
    
            var requestorNameParameter = requestorName != null ?
                new ObjectParameter("RequestorName", requestorName) :
                new ObjectParameter("RequestorName", typeof(string));
    
            var requestorDepartmentParameter = requestorDepartment != null ?
                new ObjectParameter("RequestorDepartment", requestorDepartment) :
                new ObjectParameter("RequestorDepartment", typeof(string));
    
            var exceptionReasonIdParameter = exceptionReasonId.HasValue ?
                new ObjectParameter("ExceptionReasonId", exceptionReasonId) :
                new ObjectParameter("ExceptionReasonId", typeof(int));
    
            var syStudentIdParameter = syStudentId.HasValue ?
                new ObjectParameter("SyStudentId", syStudentId) :
                new ObjectParameter("SyStudentId", typeof(int));
    
            var nameAssignedParameter = nameAssigned != null ?
                new ObjectParameter("NameAssigned", nameAssigned) :
                new ObjectParameter("NameAssigned", typeof(string));
    
            var notesParameter = notes != null ?
                new ObjectParameter("Notes", notes) :
                new ObjectParameter("Notes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddExceptionsPhoneNumber", phoneNumberParameter, dateTimeExceptionGrantedParameter, requestorIdParameter, requestorNameParameter, requestorDepartmentParameter, exceptionReasonIdParameter, syStudentIdParameter, nameAssignedParameter, notesParameter);
        }
    
        public virtual ObjectResult<cplxExceptionReasonsNames> GetExceptionReasonsNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<cplxExceptionReasonsNames>("GetExceptionReasonsNames");
        }
    
        public virtual ObjectResult<cplxStudentInfoByPhoneNumber> GetStudentInfoByPhoneNumber(string phoneNumber)
        {
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<cplxStudentInfoByPhoneNumber>("GetStudentInfoByPhoneNumber", phoneNumberParameter);
        }
    }
}

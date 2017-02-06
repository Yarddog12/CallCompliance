using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public class UnblockViewModel : UserManagementModelBase {

		// move into a base class
		public string PhoneNumber { get; set; }
		public List<ExceptionReasonNamesModel> ExceptionReasonNames { get; set; } = new List<ExceptionReasonNamesModel>();

		// Note: these three values will come from the base class and I will probably rename them per comments below.
		//public string RequestId { get; set; }		// LoginIdentity  (JBECKWITH)  RequestId
		//public string RequestName { get; set; }		// FullName		  (John Beckwith)	RequestName
		//public string ReqDepartment { get; set; }	// Department	  (App Dev)			ReqDepartment
		public int ReasonId { get; set; }
		public int StudentId { get; set; }
		public string NameAssigned { get; set; }
		public string Notes { get; set; }

		public UnblockViewModel()
		{
			
		}
	}

	public class ExceptionReasonNamesModel {
		public int Id { get; set; }
		public string ReasonName { get; set; }

		public ExceptionReasonNamesModel() { }

		public ExceptionReasonNamesModel(int id, string reasonName) {
			Id = id;
			ReasonName = reasonName;
		}
	}
}
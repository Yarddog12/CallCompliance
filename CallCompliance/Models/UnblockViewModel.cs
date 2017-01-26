using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public class UnblockViewModel {

		// move into a base class
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public List<ExceptionReasonNamesModel> ExceptionReasonNames { get; set; } = new List<ExceptionReasonNamesModel>();

		public string RequestId { get; set; }
		public string RequestName { get; set; }
		public string ReqDepartment { get; set; }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public class UnblockViewModel {

		public string PhoneNumber { get; set; }
		public List<ExceptionReasonNamesModel> ExceptionReasonNames { get; set; } = new List<ExceptionReasonNamesModel>();

		public string requestId { get; set; }
		public string requestName { get; set; }
		public string reqDepartment { get; set; }
		public int reasonId { get; set; }
		public int studentId { get; set; }
		public string nameAssigned { get; set; }
		public string notes { get; set; }

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
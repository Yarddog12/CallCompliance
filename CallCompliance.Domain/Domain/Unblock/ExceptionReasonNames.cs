using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCompliance.Domain.Domain.Unblock {
	public class ExceptionReasonNames {
		public int Id { get; set; }
		public string ReasonName { get; set; }
		public DateTime DateTimeAdded { get; set; }
		public DateTime DateTimeModified { get; set; }
		public bool ActiveFlag { get; set; }

		public ExceptionReasonNames(int id, string reasonName, DateTime dateTimeAdded, DateTime dateTimeModified, bool activeFlag) {
			Id = id;
			ReasonName = reasonName;
			DateTimeAdded = dateTimeAdded;
			DateTimeModified = dateTimeModified;
			ActiveFlag = activeFlag;
		}
	}
}

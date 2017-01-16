using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCompliance.Domain.Domain.Unblock {
	public class ExceptionReasonNames {
		public int Id { get; set; }
		public string ReasonName { get; set; }

		public ExceptionReasonNames(int id, string reasonName) {
			Id = id;
			ReasonName = reasonName;
		}
	}
}

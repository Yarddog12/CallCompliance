using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public class CoolDownViewModel : UserManagementModelBase {
		public string PhoneNumber { get; set; }
		public string StudentName { get; set; }
		public int StudentId { get; set; }
		public string Notes { get; set; }

		public CoolDownViewModel () { }
	}
}
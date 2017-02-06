using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public class CoolDownViewModel : UserManagementModelBase {
		public string PhoneNumberCoolDown { get; set; }
		public string StudentName { get; set; }
		public string StudentNumber { get; set; }
		public string Notes { get; set; }
	}
}
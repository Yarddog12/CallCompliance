using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {

	// Items from AD that are useful to other classes when saving data.
	public abstract class UserManagementModelBase {
		public int StaffId { get; set; }			// 2308
		public string LoginIdentity { get; set; }	// JBECKWITH
		public string FullName { get; set; }		// John Beckwith
		public string Department { get; set; }		// App Dev
		public string EmailAddress { get; set; }	// jbeckwith@ultimatemedical.edu
		public string PhotoData { get; set; }
		public string GoogleApiUserId { get; set; }

		public UserManagementModelBase() {
			this.PhotoData = "/Content/Images/DefaultUserImage.png";
		}
	}
}
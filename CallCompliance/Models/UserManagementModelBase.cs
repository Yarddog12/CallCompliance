using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public abstract class UserManagementModelBase {
		public int UserId { get; set; }
		public string DisplayName { get; set; }
		public string EmailAddress { get; set; }
		public string PhotoData { get; set; }
		public string GoogleApiUserId { get; set; }

		public UserManagementModelBase() {
			this.PhotoData = "/Content/Images/DefaultUserImage.png";
		}
	}
}
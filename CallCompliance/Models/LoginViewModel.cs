using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public class LoginViewModel : UserManagementModelBase {
		public string UserName { get; set; }
		public string Password { get; set; }

		public LoginViewModel() { }

	}
}
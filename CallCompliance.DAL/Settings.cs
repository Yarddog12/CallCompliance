using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CallCompliance.DAL {
	public static class Settings {

		public static ConnectionStringSettings CallComplianceDatabaseConnection {
			get {
				try {
					ConnectionStringSettings connection = ConfigurationManager.ConnectionStrings["UMATeleCom"];
					return connection;
				}
				catch (Exception ex) {
					return new ConnectionStringSettings ();
				}
			}
		}
	}
}

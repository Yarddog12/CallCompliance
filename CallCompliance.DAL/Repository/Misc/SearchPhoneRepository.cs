using System;
using System.Collections.Generic;
using System.Linq;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.Misc {
	public class SearchPhoneRepository : UserManagementBase {

		public static string ClassNameError = "Error in MiscRepository ->";

		/// <summary>
		/// This is for the search at the top where you enter a phone number, and look to see what table (menu) this phone number lives.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<cplxTableNameWherePhoneNumberIsLocated> GetTableName (string phoneNumber) {

			List<cplxTableNameWherePhoneNumberIsLocated> ret = new List<cplxTableNameWherePhoneNumberIsLocated> ();
			try {
				ret = _ctx.GetTableNameWherePhoneNumberIsLocated(phoneNumber).ToList ();

			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "GetTableName()");
				throw;
			}

			return ret;
		}
	}
}

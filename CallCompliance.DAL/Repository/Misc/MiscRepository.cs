using System;
using System.Linq;
using System.Collections.Generic;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.Misc {
	public class MiscRepository : UserManagementBase {

		public static string ClassNameError = "Error in MiscRepository ->";

		/// <summary>
		/// This is for Unblock drop down of Exception Reason Names
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

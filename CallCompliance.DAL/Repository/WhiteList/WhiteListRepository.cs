using System;
using static CallCompliance.Fx.Formatters;

namespace CallCompliance.DAL.Repository.WhiteList {
	public class WhiteListRepository : UserManagementBase {

		public static string ClassNameError = "Error in WhiteListRepository ->";

		public void AddWhiteListPhoneNumber(string phoneNumber,
											string reqId,
											string reqName,
											string reqDepartment,
											string notes,
											bool? dncOverride) {

			DateTime? dt = DateTime.Now;

			try {
				string formattedPhone = Helpers.FormatPhoneNumber(phoneNumber);
				_ctx.AddWhitelistPhoneNumber(phoneNumber, reqId, reqName, reqDepartment, notes, dncOverride);
				_logger.Info ("Phone number " + formattedPhone + " successfully added to white list by user " + reqName);

			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "AddWhiteListPhoneNumber parameters: " +
					phoneNumber   + Comma +
					reqId         + Comma +
					reqName       + Comma +
					reqDepartment + Comma +
					notes);
				throw;
			}
		}
	}
}

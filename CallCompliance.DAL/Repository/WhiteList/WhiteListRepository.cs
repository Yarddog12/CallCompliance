using System;

namespace CallCompliance.DAL.Repository.WhiteList {
	public class WhiteListRepository : UserManagementBase {

		public static string ClassNameError = "Error in WhiteListRepository ->";

		public void AddWhiteListPhoneNumber(string phoneNumber,
											string reqId,
											string reqName,
											string reqDepartment,
											string notes) {

			DateTime? dt = DateTime.Now;

			try {
				_ctx.AddWhitelistPhoneNumber(phoneNumber, reqId, reqName, reqDepartment, notes);
				_logger.Info ("Phone number " + phoneNumber + " successfully added to white list by user " + reqName);

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

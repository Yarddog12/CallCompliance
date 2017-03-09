using System;
using static CallCompliance.Fx.Formatters;

namespace CallCompliance.DAL.Repository.CoolDown {
	public class CoolDownNumberRepository : UserManagementBase {

		public static string ClassNameError = "Error in CoolDownNumberRepository ->";

		/// <summary>
		/// The user has pressed Save on the Cool Down page.
		/// </summary>
		/// <param name="phoneNumber"></param>
		/// <param name="reqId"></param>
		/// <param name="reqName"></param>
		/// <param name="reqDepartment"></param>
		/// <param name="notes"></param>
		/// <param name="studentId"></param>
		/// <param name="studentName"></param>
		public void AddCoolDownPhoneNumber(string phoneNumber,
									string reqId,
									string reqName,
									string reqDepartment,
									string notes,
									int studentId,
									string studentName) {

			DateTime? dt = DateTime.Now;

			

			try {
				string formattedPhone = Helpers.FormatPhoneNumber(phoneNumber);
				_ctx.AddCooldownsPhoneNumber(phoneNumber, dt, reqId, reqName, reqDepartment, notes, studentId, studentName);
				_logger.Info ("Phone number " + formattedPhone + " successfully Cooled Down by user " + reqName);

			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "AddCooldownsPhoneNumber parameters: " + 
					phoneNumber   + Comma +
					reqId         + Comma +
					reqName       + Comma +
					reqDepartment + Comma + 
					notes         + Comma +
					studentId     + Comma +
					studentName   + Comma);
				throw;
			}
		}
	}
}

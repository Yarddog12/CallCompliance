using System;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.CoolDown {
	public class CoolDownNumberRepository : UserManagementBase {

		public void AddCoolDownPhoneNumber(string phoneNumber,
									string reqId,
									string reqName,
									string reqDepartment,
									string notes,
									int studentId,
									string studentName) {

			DateTime? dt = DateTime.Now;

			try {
				
				//using (var dbContext = new CallComplianceModelContainer ()) {
					_ctx.AddCooldownsPhoneNumber(phoneNumber, dt, reqId, reqName, reqDepartment, notes, studentId, studentName);
				//}
			} catch (Exception ex) {
				_logger.Error (ex, "Could not cool down " + phoneNumber);
				throw ex;
			}
		}
	}
}

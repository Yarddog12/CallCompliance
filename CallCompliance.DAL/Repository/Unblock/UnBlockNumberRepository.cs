using System;
using System.Collections.Generic;
using System.Linq;
using CallCompliance.DAL.Logging;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.Unblock {
	public class UnBlockNumberRepository : UserManagementBase {

		public static string ClassNameError = "Error in UnblockNumberRepository ->";

		public IEnumerable<cplxExceptionReasonsNames> GetExceptionReasonNames() {

			List<cplxExceptionReasonsNames> ret = new List<cplxExceptionReasonsNames>();
			try {
				_logger.Info ("Logger initialized.");
				//using (var dbContext = new CallComplianceModelContainer()) {
					ret = _ctx.GetExceptionReasonsNames().ToList();
				//}
			}
			catch (Exception ex) {
				_logger.Error(ex, ClassNameError + "GetExceptionReasonNames()");
			}

			return ret;
		}

		public IEnumerable<cplxStudentInfoByPhoneNumber> GetStudentInfoByPhoneNumbers(string phoneNumber) {
			
			List<cplxStudentInfoByPhoneNumber> ret = new List<cplxStudentInfoByPhoneNumber>();
			try {
				//using (var dbContext = new CallComplianceModelContainer()) {
					ret = _ctx.GetStudentInfoByPhoneNumber(phoneNumber).ToList();
				//}
			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "GetStudentInfoByPhoneNumbers (" + phoneNumber + ")");
			}

			return ret;
		}

		public void AddExceptionPhoneNumber(string phoneNumber, 
											string reqId, 
											string reqName, 
											string reqDepartment,
											int reasonId, 
											int studentId, 
											string nameAssigned, 
											string notes) {

			DateTime? dt = DateTime.Now;

			try {
				//using (var dbContext = new CallComplianceModelContainer()) {
					_ctx.AddExceptionsPhoneNumber(phoneNumber, dt, reqId, reqName, reqDepartment, reasonId, studentId, nameAssigned, notes);
				//}
			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "AddExceptionsPhoneNumber parameters: " + phoneNumber + Comma + 
					reqId + Comma + 
					reqName + Comma + 
					reqDepartment + Comma + 
					reasonId + Comma + 
					studentId + Comma + 
					nameAssigned + Comma + 
					notes);
				throw ex;
			}
		}
	}
}

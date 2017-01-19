using System;
using System.Collections.Generic;
using System.Linq;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.Unblock {
	public class UnBlockNumberRepository {

		public IEnumerable<cplxExceptionReasonsNames> GetExceptionReasonNames() {
			
			List<cplxExceptionReasonsNames> ret = new List<cplxExceptionReasonsNames>();
			try {
				using (var dbContext = new CallComplianceModelContainer()) {
					ret = dbContext.GetExceptionReasonsNames().ToList();
				}
			}
			catch (Exception ex) {
				// log something.
			}

			return ret;
		}

		public IEnumerable<cplxStudentInfoByPhoneNumber> GetStudentInfoByPhoneNumbers(string phoneNumber) {
			
			List<cplxStudentInfoByPhoneNumber> ret = new List<cplxStudentInfoByPhoneNumber>();
			try {
				using (var dbContext = new CallComplianceModelContainer()) {
					ret = dbContext.GetStudentInfoByPhoneNumber(phoneNumber).ToList();
				}
			} catch (Exception ex) {
				// log something.
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
				using (var dbContext = new CallComplianceModelContainer()) {
					dbContext.AddExceptionsPhoneNumber(phoneNumber, dt, reqId, reqName, reqDepartment, reasonId, studentId, nameAssigned, notes);
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

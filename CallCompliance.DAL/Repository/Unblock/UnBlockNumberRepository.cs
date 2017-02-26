using System;
using System.Collections.Generic;
using System.Linq;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.Unblock {
	public class UnBlockNumberRepository : UserManagementBase {

		public static string ClassNameError = "Error in UnblockNumberRepository ->";

		/// <summary>
		/// This is for Unblock drop down of Exception Reason Names
		/// </summary>
		/// <returns></returns>
		public IEnumerable<cplxExceptionReasonsNames> GetExceptionReasonNames() {

			List<cplxExceptionReasonsNames> ret = new List<cplxExceptionReasonsNames>();
			try {
				ret = _ctx.GetExceptionReasonsNames().ToList();
			}
			catch (Exception ex) {
				_logger.Error(ex, ClassNameError + "GetExceptionReasonNames()");
				throw;
			}

			return ret;
		}

		public IEnumerable<cplxStudentInfoByPhoneNumber> GetStudentInfoByPhoneNumbers(string phoneNumber) {
			
			List<cplxStudentInfoByPhoneNumber> ret = new List<cplxStudentInfoByPhoneNumber>();
			try {
				ret = _ctx.GetStudentInfoByPhoneNumber(phoneNumber).ToList();

			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "GetStudentInfoByPhoneNumbers (" + phoneNumber + ")");
				throw;
			}

			return ret;
		}

		/// <summary>
		/// The user has pressed the Save button on the Unblock page.
		/// </summary>
		/// <param name="phoneNumber"></param>
		/// <param name="reqId"></param>
		/// <param name="reqName"></param>
		/// <param name="reqDepartment"></param>
		/// <param name="reasonId"></param>
		/// <param name="studentId"></param>
		/// <param name="nameAssigned"></param>
		/// <param name="notes"></param>
		public void AddExceptionPhoneNumber(string phoneNumber, 
											string reqId, 
											string reqName, 
											string reqDepartment,
											int reasonId, 
											int studentId, 
											string nameAssigned, 
											string notes,
											bool isStudent) {

			DateTime? dt = DateTime.Now;

			try {
				_ctx.AddExceptionsPhoneNumber(phoneNumber, dt, reqId, reqName, reqDepartment, reasonId, studentId, nameAssigned, notes, isStudent);
				_logger.Info ("Phone number " + phoneNumber + " successfully blocked by user " + reqName);

			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "AddExceptionsPhoneNumber parameters: " + 
					phoneNumber   + Comma + 
					reqId         + Comma + 
					reqName       + Comma + 
					reqDepartment + Comma + 
					reasonId      + Comma + 
					studentId     + Comma + 
					nameAssigned  + Comma + 
					notes);
				throw;
			}
		}
	}
}

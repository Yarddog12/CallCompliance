using System;
using System.Collections.Generic;
using System.Linq;
using CallCompliance.DAL.Models;
using static CallCompliance.Fx.Formatters;

namespace CallCompliance.DAL.Repository.DNC {
	public class DncRepository : UserManagementBase {

		public static string ClassNameError = "Error in DncRepository ->";

		/// <summary>
		/// This is for Dnc List names
		/// </summary>
		/// <returns></returns>
		public IEnumerable<cplxDNCListsListNames> GetDncNames() {

			List<cplxDNCListsListNames> ret = new List<cplxDNCListsListNames> ();
			try {
				ret = _ctx.GetDNCListsListNames().ToList ();
			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "GetDncNames()");
				throw;
			}

			return ret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phoneNumber"></param>
		/// <param name="reqId"></param>
		/// <param name="reqName"></param>
		/// <param name="reqDepartment"></param>
		/// <param name="dncListId"></param>
		public void AddDncPhoneNumber(string phoneNumber,
											string reqId,
											string reqName,
											string reqDepartment,
											int dncListId) {

			try {

				string formattedPhone = Helpers.FormatPhoneNumber(phoneNumber);
				_ctx.AddDNCPhoneNumber(phoneNumber, dncListId, reqId, reqName, reqDepartment);
				_logger.Info ("Phone number " + formattedPhone + " successfully added to DNC by user " + reqName);

			} catch (Exception ex) {
				_logger.Error(ex, ClassNameError + "AddDNCPhoneNumber parameters: " +
				                  phoneNumber + Comma +
				                  reqId + Comma +
				                  reqName + Comma +
				                  reqDepartment + Comma +
				                  dncListId);
				throw;

			}
		}
	}
}

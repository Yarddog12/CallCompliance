using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.Admin {
	public class AdminRepository : UserManagementBase {

		public static string ClassNameError = "Error in AdminRepository ->";

		public void UpdateCallCap (string parmName, int parmValue, string modifiedBy) {

			try {
				_ctx.UpdateParametersValue(parmName, parmValue, modifiedBy);
				_logger.Info ("ParmName: " + parmName + " changed to value: " + parmValue + " modified by: " + modifiedBy);

			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "CallCaps parameters: " +
					parmName + Comma +
					parmValue + Comma +
					modifiedBy + Comma);
				throw;
			}
		}

		public List<cplxParametersValues> GetCallCap() {

			List<cplxParametersValues> ret = new List<cplxParametersValues>();
			try {
				ret = _ctx.GetParametersValues().ToList();

			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "GetCallCap: ");
				throw;
			}

			return ret;
		}
	}
}

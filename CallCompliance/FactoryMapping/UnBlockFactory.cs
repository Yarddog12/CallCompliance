using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using CallCompliance.DAL.Models;
using CallCompliance.Models;


namespace CallCompliance.FactoryMapping {
	public class UnBlockFactory {

		public ExceptionReasonNamesModel Create(cplxExceptionReasonsNames c) {
			if (c == null) {
				throw new ArgumentNullException("cplxExceptionNames", "No Exception reasons for dropdown box returned.");
			}

			return new ExceptionReasonNamesModel(c.Id, c.ReasonName);
		}
	}
}
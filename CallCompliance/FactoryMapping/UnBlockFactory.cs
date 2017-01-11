using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using CallCompliance.DAL.Models;
using CallCompliance.Domain.Domain.Unblock;


namespace CallCompliance.FactoryMapping {
	public class UnBlockFactory {

		public ExceptionReasonNames Create(cplxExceptionReasonsNames c) {
			if (c == null) {
				throw new ArgumentNullException("cplxExceptionNames", "No Exception reasons for dropdown box returned.");
			}

			return new ExceptionReasonNames (c.Id, c.ReasonName, c.DateTimeAdded, c.DateTimeModified, c.ActiveFlag);
		}
	}
}
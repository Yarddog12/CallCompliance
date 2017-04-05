using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCompliance.DAL.Models;
using CallCompliance.Models;

namespace CallCompliance.FactoryMapping {
	public class MiscFactory {
		public MiscViewModel Create(cplxTableNameWherePhoneNumberIsLocated c) {
			if (c == null) {
				throw new ArgumentNullException ("cplxTableNameWherePhoneNumberIsLocated", "No phone number found in table.");
			}

			return new MiscViewModel (c.TableName);
		}
	}
}

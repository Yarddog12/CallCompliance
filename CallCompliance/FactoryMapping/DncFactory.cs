using System;
using CallCompliance.DAL.Models;
using CallCompliance.Models;

namespace CallCompliance.FactoryMapping {
	public class DncFactory {
		public DncListNamesModel Create(cplxDNCListsListNames c) {
			if (c == null) {
				throw new ArgumentNullException ("cplxDNCListsListNames", "No Exception reasons for dropdown box returned.");
			}

			return new DncListNamesModel(c.Id, c.ListName);
		}
	}
}
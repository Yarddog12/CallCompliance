using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCompliance.Models {
	public class DncViewModel {

		public string PhoneNumber { get; set; }
		public List<DncListNamesModel> DncListNames { get; set; } = new List<DncListNamesModel> ();
	}

	public class DncListNamesModel {
		public int Id { get; set; }
		public string DncNames { get; set; }

		public DncListNamesModel() { }

		public DncListNamesModel(int id, string dncNames) {
			Id = id;
			DncNames = dncNames;
		}
	}
}
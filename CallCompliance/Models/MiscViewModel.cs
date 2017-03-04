using System;
using System.Collections.Generic;

namespace CallCompliance.Models {
	public class MiscViewModel {
		public List<MiscViewModel> TableNameList { get; set; } = new List<MiscViewModel> ();
		public string TableName { get; set; }
		public MiscViewModel() { }

		public MiscViewModel(string tableName) {
			TableName = tableName;
		}
	}
}
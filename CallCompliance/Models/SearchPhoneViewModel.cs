using System;
using System.Collections.Generic;

namespace CallCompliance.Models {
	public class SearchPhoneViewModel {
		public List<SearchPhoneViewModel> TableNameList { get; set; } = new List<SearchPhoneViewModel> ();
		public string TableName { get; set; }
		public SearchPhoneViewModel() { }

		public SearchPhoneViewModel(string tableName) {
			TableName = tableName;
		}
	}
}
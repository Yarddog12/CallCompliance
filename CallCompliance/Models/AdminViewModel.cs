using System;

namespace CallCompliance.Models {
	public class AdminViewModel : UserManagementModelBase {

		public string ModifiedBy { get; set; }

		// I really should shoot myself for doing this..but no time to do it right...
		// refactor when re-writing in Core, Azure and CodeFirst.
		public string ParmName1 { get; set; }
		public int ParmValue1 { get; set; }
		public string ParmName2 { get; set; }
		public int ParmValue2 { get; set; }
		public string ParmName3 { get; set; }
		public int ParmValue3 { get; set; }
		public string ParmName4 { get; set; }
		public int ParmValue4 { get; set; }
		public string ParmName5 { get; set; }
		public int ParmValue5 { get; set; }
		public string ParmName6 { get; set; }
		public int ParmValue6 { get; set; }
		public string ParmName7 { get; set; }
		public int ParmValue7 { get; set; }
		public string ParmName8 { get; set; }
		public int ParmValue8 { get; set; }
		public string ParmName9 { get; set; }
		public int ParmValue9 { get; set; }
		public string ParmName10 { get; set; }
		public int ParmValue10 { get; set; }
		public string ParmName11 { get; set; }
		public int ParmValue11 { get; set; }
		public string ParmName12 { get; set; }
		public int ParmValue12 { get; set; }

		public AdminViewModel() { }
	}
}
using System;
using System.ComponentModel.DataAnnotations;

namespace CallCompliance.Models {
	public class TestModel {
		[Key]
		public int TestId { get; set; }
		public string Label { get; set; }
		public string Description { get; set; }
	}

	public class TestPost {
		[Key]
		public int PostId { get; set; }
		public string Value { get; set; }
		public int TestId { get; set; }
		public virtual TestModel TestModel { get; set; }
	}
}
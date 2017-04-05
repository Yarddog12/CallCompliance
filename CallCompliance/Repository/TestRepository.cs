using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCompliance.Models;
using CallCompliance.TestData;

namespace CallCompliance.Repository {
	public class TestRepository {
		public IEnumerable<TestModel> GetTestModels () {
			using (var ctx = new TestContext ()) {
				return ctx.Models.ToList ();
			}
		}
	}
}
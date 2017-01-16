using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCompliance.Models;
using System.Data.Entity;

namespace CallCompliance.TestData {
	public class TestContext : DbContext {
		public DbSet<TestModel> Models { get; set; }
		public DbSet<TestPost> Posts { get; set; }
	}
}
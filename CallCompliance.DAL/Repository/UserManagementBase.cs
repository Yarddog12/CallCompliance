using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCompliance.DAL.Logging;
using CallCompliance.DAL.Models;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace CallCompliance.DAL.Repository {

	/// <summary>
	/// NOTE: We should create a services layer and put this there.
	/// 
	/// Base class for services. This class has a member, _ctx.
	/// This context is an instance of EF entities, the EF context
	/// our data. For testing, this context can (and should) be injected 
	/// with a test context when the concrete service is instantiated.
	/// </summary>
	public class UserManagementBase : IDisposable {
		protected CallComplianceModelContainer _ctx;
		private bool _disposed = false;
		protected static Logger _logger = DiagnosticLogging.LoggerInitialization();

		public UserManagementBase(CallComplianceModelContainer ctx) {
			_ctx = ctx;

#if DEBUG
			_ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine (s);
#endif
		}

		public UserManagementBase() {
			_ctx = new CallComplianceModelContainer ();

#if DEBUG
			_ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine (s);
#endif
		}

		#region IDisposable
		public void Dispose() {
			Dispose (true);
			GC.SuppressFinalize (this);
		}
		protected virtual void Dispose(bool disposing) {
			if (_disposed) {
				return;
			}
			if (disposing) {
			}
			_disposed = true;
		}
		#endregion
	}

	
}


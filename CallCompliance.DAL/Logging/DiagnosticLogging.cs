using System;

using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace CallCompliance.DAL.Logging {
	public static class DiagnosticLogging {

		public static Logger LoggerInitialization() {
            // If you're having any problems, turn on the internal logger.

            //InternalLogger.LogToConsole = true;
            //InternalLogger.LogLevel = LogLevel.Trace;
            //InternalLogger.LogFile = "c:\\Log\\log.txt";
			Logger _logger;

            var config = new LoggingConfiguration();
            var target = new DatabaseTarget("dbtarget");

			target.ConnectionString = Settings.CallComplianceDatabaseConnection.ConnectionString;
            target.CommandText = LOG_COMMAND_TEXT;
            target.Parameters.Add(new DatabaseParameterInfo("@thread", new SimpleLayout("${threadid}")));
            target.Parameters.Add(new DatabaseParameterInfo("@level", new SimpleLayout("${level}")));
            target.Parameters.Add(new DatabaseParameterInfo("@logger", new SimpleLayout("${logger}")));
            target.Parameters.Add(new DatabaseParameterInfo("@message", new SimpleLayout("${message}")));
            target.Parameters.Add(new DatabaseParameterInfo("@exception", new SimpleLayout("${exception:format=toString}")));

            var rule = new LoggingRule("*", LogLevel.Trace, target);
            config.LoggingRules.Add(rule);

            config.AddTarget(target);

            LogManager.Configuration = config;

            // Enable these commands when troubleshooting.
            // LogManager.ThrowExceptions = true;
            // LogManager.ThrowConfigExceptions = true;

            _logger = LogManager.GetCurrentClassLogger();

			return _logger;
		}

		/// <summary>
		/// Insert statement used by nLog for writing to the database.
		/// </summary>
		public const string LOG_COMMAND_TEXT = @"INSERT INTO [Compliance].[DiagnosticLog] 
                ( [LogDate], [ThreadId], [EventLevel], [LoggerName], [Message], [Exception]) 
                VALUES ( GETDATE(), @thread, @level, @logger, @message, @exception)";
	}
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.EntityFrameworkCore.Logging
{
	/* EXAMPLE
	 * 
	 * dbHitSpiderDataContext db = new dbHitSpiderDataContext(config=>config.EnableSensitiveDataLogging().UseLoggerFactory(new MyLoggerFactory(msg=>Trace.WriteLine(msg))));
	 * 
	*/
	/// <summary>
	/// EXAMPLE:
	/// dbHitSpiderDataContext db = new dbHitSpiderDataContext(config=>config.EnableSensitiveDataLogging().UseLoggerFactory(new MyLoggerFactory(msg=>Trace.WriteLine(msg))));
	/// </summary>
	/// 
	public class MyLoggerFactory : LoggerFactory
	{
		public MyLoggerFactory(Action<string> logCallback) : base(new[] { new MyLoggerProvider(logCallback) })
		{
		}
	}

	public class MyLoggerProvider : ILoggerProvider
	{
		Action<string> _logCallback;
		public MyLoggerProvider(Action<string> logCallback)
		{
			_logCallback = logCallback;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new MyLogger(_logCallback);
		}

		public void Dispose()
		{
		}
	}

	public class MyLogger : ILogger
	{
		Action<string> _logCallback;

		public MyLogger(Action<string> logCallback)
		{
			_logCallback = logCallback;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return new MyState();
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			_logCallback?.Invoke(formatter(state, exception));
		}
	}

	public class MyState : IDisposable
	{
		public void Dispose()
		{

		}
	}
}

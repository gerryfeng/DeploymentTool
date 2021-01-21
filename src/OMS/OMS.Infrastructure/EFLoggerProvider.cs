using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.Infrastructure
{
    public class EFLoggerProvider:ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new EFLogger(categoryName);
        

        public void Dispose()
        {
        }

    }

    public class EFLogger : ILogger
    {
        private readonly string categoryName;

        public EFLogger(string categoryName) => this.categoryName = categoryName;

        public IDisposable BeginScope<TState>(TState state)
        {
           return null;
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if(categoryName == DbLoggerCategory.Database.Command.Name && logLevel == LogLevel.Information)
            {
                var logContent = formatter(state, exception);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logContent);
                Console.ResetColor();
            }
            
        }
    }


}

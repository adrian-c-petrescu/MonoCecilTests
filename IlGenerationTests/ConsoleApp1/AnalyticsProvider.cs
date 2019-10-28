using System;

namespace ConsoleApp1
{
    public class AnalyticsProvider
    {
        public static IDisposable BeginScope()
        {
            return new DisposableScope();
        }
    }
}

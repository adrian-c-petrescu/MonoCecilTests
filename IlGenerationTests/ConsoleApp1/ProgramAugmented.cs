using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class DemoClass
    {
        public int ReturningFunction(int num, string str)
        {
            using (AnalyticsProvider.BeginScope())
            {
                int x = num + int.Parse(str);
                Console.WriteLine($"Returning num={num}; str={str} ");
                return 2 * num + x;
            }
        }

        public void VoidFunction()
        {
            using (AnalyticsProvider.BeginScope())
            {
                Console.WriteLine("I'm not doing a thing.");
            }
        }

        public IEnumerable<string> YieldingFunction()
        {
            using (AnalyticsProvider.BeginScope())
            {
                yield return "Hello";
                yield return "World";
            }
        }

        // We have to make a distinction betweek async functions and functions returning Task in the Mono.Cecil converter
        public async Task<string> AsyncFunction()
        {
            using (AnalyticsProvider.BeginScope())
            {
                Console.WriteLine("AsyncFunction");

                await Task.Delay(100);
                return "It worked";
            }
        }

        public async Task<string> ReturningAsyncFunction()
        {
            using (AnalyticsProvider.BeginScope())
            {
                Console.WriteLine("AsyncFunction");
                return await Task.Delay(100).ContinueWith(task => "It worked");
            }
        }

        private string _aProperty;

        public string AProperty
        {
            get
            {
                using (AnalyticsProvider.BeginScope())
                {
                    return _aProperty;
                }
            }
            set
            {
                using (AnalyticsProvider.BeginScope())
                {
                    _aProperty = value;
                }
            }
        }
    }


    public class AnalyticsProvider
    {
        public static IDisposable BeginScope()
        {
            return new DisposableScope();
        }
    }

    public class DisposableScope : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
}

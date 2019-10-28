using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.TargetCode
{
    public class DemoWrappedCallClass
    {
        public void VoidFunction()
        {
            using (AnalyticsProvider.BeginScope())
            {
                __Wrapped_VoidFunction();
            }
        }

        public void __Wrapped_VoidFunction()
        {
            Console.WriteLine("I'm not doing a thing.");
        }

        public int ReturningFunction(int num, string str)
        {
            using (AnalyticsProvider.BeginScope())
            {
                return __Wrapped_ReturningFunction(num, str);
            }
        }

        public int __Wrapped_ReturningFunction(int num, string str)
        {
            int x = num + int.Parse(str);
            Console.WriteLine($"Returning num={num}; str={str} ");
            return 2 * num + x;
        }

        public async Task<string> AsyncFunction()
        {
            using (AnalyticsProvider.BeginScope())
            {
                return await __Wrapped_AsyncFunction();
            }
        }

        // We have to make a distinction betweek async functions and functions returning Task in the Mono.Cecil converter
        public async Task<string> __Wrapped_AsyncFunction()
        {
            Console.WriteLine("AsyncFunction");

            await Task.Delay(100);
            return "It worked";
        }

        public int TemplateFunction<TClass, TStruct, TNew>(TClass cls, TStruct str)
            where TClass : class
            where TStruct : struct
            where TNew : new()
        {
            using (AnalyticsProvider.BeginScope())
            {
                return __Wrapped_TemplateFunction<TClass, TStruct, TNew>(cls, str);
            }
        }

        public int __Wrapped_TemplateFunction<TClass, TStruct, TNew>(TClass cls, TStruct str)
            where TClass : class
            where TStruct : struct
            where TNew : new()
        {
            var text = $"{cls.ToString()}{str.ToString()}{new TNew().ToString()}";
            Console.WriteLine(text);

            return int.Parse(text);
        }

        [Some]
        public string MethodWithAttributes(string a, string b)
        {
            return a + b;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TargetCode
{
    public class DemoClass
    {
        public int TemplateFunction<TClass, TStruct, TNew>(TClass cls, TStruct str)
            where TClass : class
            where TStruct : struct
            where TNew : new()
        {
            var text = $"{cls.ToString()}{str.ToString()}{new TNew().ToString()}";
            Console.WriteLine(text);

            return int.Parse(text);
        }

        public int ReturningFunction(int num, string str)
        {
            int x = num + int.Parse(str);
            Console.WriteLine($"Returning num={num}; str={str} ");
            return 2 * num + x;
        }

        public void VoidFunction()
        {
            Console.WriteLine("I'm not doing a thing.");
        }

        public IEnumerable<string> YieldingFunction()
        {
            yield return "Hello";
            yield return "World";
        }

        // We have to make a distinction betweek async functions and functions returning Task in the Mono.Cecil converter
        public async Task<string> AsyncFunction()
        {
            Console.WriteLine("AsyncFunction");

            await Task.Delay(100);
            return "It worked";
        }

        public Task<string> ReturningAsyncFunction()
        {
            Console.WriteLine("AsyncFunction");

            return Task.Delay(100).ContinueWith(task => "It worked");
        }

        public string AProperty { get; set; }

        [Some]
        public string MethodWithAttributes(string a, string b)
        {
            return a + b;
        }
    }
}

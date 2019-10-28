using ConsoleApp1.TargetCode;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new DemoClass().TemplateFunction<string, int, object>("4", 5);
        }
    }
}

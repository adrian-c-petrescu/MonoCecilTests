using System;

namespace ConsoleApp1
{
    public class DisposableScope : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
}

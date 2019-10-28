using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFody
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dto = new Dto();
            Console.WriteLine(dto.Method(4, "hello mate"));
        }
    }

    public class Dto
    {
        private int _num;
        private string _str;
        private DateTime _date;

        public Dto()
        {
            _num = 5;
            _str = "hello";
            _date = DateTime.Now;
        }

        [CaptureCall]
        public int Method(int param1, string param2)
        {
            Console.WriteLine("This method existed before");
            return 5;
        }
    }
}

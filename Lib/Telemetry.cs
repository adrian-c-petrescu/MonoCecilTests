using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class Telemetry
    {
        public static void LogTheThing(string message, object[] parameters, object instance)
        {

            Console.WriteLine($"Message: {message}; Parameters: {string.Join(",", parameters)}; ClassFields: {instance.GetHashCode()}");
        }
    }
}

using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Linq;

namespace Weaver
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Usage: Weaver [weaved-assembly]");

                return 1;
            }

            // 1
            var pathToOriginalDll = args[0];
                // Path.GetFullPath(Path.Combine(assemblyLocation, ""));

            // 2
            var pathToWeavedDll = pathToOriginalDll.Replace(".exe", ".weaved.exe");
            // File.Copy(pathToOriginalDll, pathToBackupDll, true);

            // 3
            var moduleDefinition = ModuleDefinition.ReadModule(pathToOriginalDll, new ReaderParameters { ReadSymbols = true });

            // 4
            //var mainMethod = moduleDefinition
            //    .GetTypes()
            //    .Single(t => t.Name == "Dto")
            //    .Methods
            //    .Single(m => m.Name.Contains("Method"));
            var mainMethod = moduleDefinition
                .GetTypes()
                .Single(t => t.Name == "Program")
                .Methods
                .Single(m => m.Name == "Main");

            // 5
            var processor = mainMethod.Body.GetILProcessor();
            var firstInstruction = processor.Body.Instructions.Skip(1).First();
            var writeLineInstruction = processor.Body.Instructions.First(i => i.OpCode == OpCodes.Call);

            // 6
            processor.InsertBefore(firstInstruction, processor.Create(OpCodes.Ldstr, "This I Wove!"));
            processor.InsertBefore(firstInstruction, writeLineInstruction);

            // 7
            // var stream = new FileStream(pathToOriginalDll, FileMode.OpenOrCreate);
            moduleDefinition.Write(pathToWeavedDll, new WriterParameters { WriteSymbols = true });

            return 0;
        }
    }
}

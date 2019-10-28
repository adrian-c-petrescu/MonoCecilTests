using Fody;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWeaver.Fody
{
    public class ModuleWeaver : BaseModuleWeaver
    {
        public ModuleDefinition ModuleDefinition { get; set; }

        public override void Execute()
        {
            //ModuleDefinition
            //    .Types
            //    .Where(type => type.Attributes.C)


            ModuleDefinition.Types.Add(
               new TypeDefinition("TestNamespace", "TestType",
                      TypeAttributes.Public,
               ModuleDefinition.ImportReference(typeof(object))));
        }

        public override IEnumerable<string> GetAssembliesForScanning()
        {
            yield return "mscorlib";
            yield return "System";
            yield return "System.Runtime";
            yield return "System.Core";
            yield return "netstandard";
            yield return "System.Collections";
            yield return "System.ObjectModel";
            yield return "System.Threading";
            yield return "FSharp.Core";
            yield return "System.Diagnostics.Tools";
            yield return "System.Diagnostics.Debug";
        }
    }
}

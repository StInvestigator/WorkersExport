using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkersExport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AssemblyName assemblyToLoad = AssemblyName.GetAssemblyName("Workers.dll");
            Assembly assembly = Assembly.Load(assemblyToLoad);
            Module module = assembly.GetModule("Workers.dll");
            Type[] type = module.GetTypes();

            object worker = Activator.CreateInstance(type[0],"Misha",20,200);
            MethodInfo workerMethod = type[0].GetMethod("work");
            workerMethod.Invoke(worker, null);

            object manager = Activator.CreateInstance(type[1], "Ivan", 22, 400);
            MethodInfo managerMethod = type[1].GetMethod("work");
            managerMethod.Invoke(manager, null);

            object director = Activator.CreateInstance(type[2], "Alex", 41, 800);
            MethodInfo directorMethod = type[2].GetMethod("work");
            directorMethod.Invoke(director, null);

            object programmer = Activator.CreateInstance(type[3], "Olexiy", 22, 500);
            MethodInfo programmerMethod = type[3].GetMethod("work");
            programmerMethod.Invoke(programmer, null);

            Console.ReadKey();
        }
    }
}

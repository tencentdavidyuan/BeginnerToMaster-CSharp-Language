using System;
using System.Reflection;
using System.Security.Permissions;


namespace _023_AssemblyExample {
    
    /// <summary>
    /// 表示一个程序集，它是一个可重用、无版本冲突并且可自我描述的公共语言运行时应用程序构建基块。
    /// </summary>
    class Program {
        private int factor;
        public Program(int f) {
            factor = f;
        }

        public int ExampleMethod(int x) {
            Console.WriteLine("\nExample.SampleMethod({0}) executes.", x);
            return x * factor;
        }


        static void Main(string[] args) {
            Assembly assem = typeof(Program).Assembly;

            Console.WriteLine("Assembly Full Name: ");
            Console.WriteLine(assem.FullName);

            AssemblyName assemName = assem.GetName();
            Console.WriteLine("\nname {0}:", assemName.Name);

            Console.WriteLine("\n{0}.{1}", assemName.Version.Major, assemName.Version.Minor);

            Console.WriteLine("\nAssembly CodeBase:");
            Console.WriteLine(assemName.CodeBase);


            // 创建实例
            Console.WriteLine("\n Assembly.CreatInstance: ");
            Object o = assem.CreateInstance(
                "_023_AssemblyExample.Program", 
                false, 
                BindingFlags.ExactBinding,
                null,
                new Object[] { 2 }, 
                null, 
                null);

            // 存在装箱操作
            MethodInfo m = assem.GetType("_023_AssemblyExample.Program").GetMethod("ExampleMethod");
            Object ret = m.Invoke(o, new object[] { 42 });
            Console.WriteLine("SampleMethod returned {0}.", ret.ToString());


            // 
            Console.WriteLine("\nAssembly entry point:");
            Console.WriteLine(assem.EntryPoint);

            Console.Read();
        }


    }
}

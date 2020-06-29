using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_TypeExample {
    class Program {

        class AnyConnection {
            public int _a;
            public string _name;
        }

        class UIConnection : AnyConnection{
            public int _b;
        }

        static void Main(string[] args) {
            Type t = typeof(UIConnection);
            Console.WriteLine("name = " + t.Name);            
            Console.WriteLine("fullName = " + t.FullName);
            Console.WriteLine("assemblyQualifiedName = " + t.AssemblyQualifiedName);

            Console.WriteLine("baseType = " + t.BaseType);
            Console.WriteLine("baseType.baseType = " + t.BaseType.BaseType);

            Console.Read();
        }
    }
}

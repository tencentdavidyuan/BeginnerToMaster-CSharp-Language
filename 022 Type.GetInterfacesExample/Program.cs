using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022_Type.GetInterfacesExample {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("\r\n Interfaces implemented by Dictionary<int, string>: \r\n");

            foreach (var tInterface in typeof(Dictionary<int, string>).GetInterfaces()) {
                Console.WriteLine(tInterface.ToString());
            }


            Console.Read();
        }
    }
}

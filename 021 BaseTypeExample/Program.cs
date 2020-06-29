using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_Type.BaseTypeExample {
    class Program {

        /// <summary>
        /// 1. 使用递归列出了在程序集中找到的每个类的完整继承层次结构
        /// 
        /// 2. 基类型是当前类型直接从中继承的类型。 Object是唯一没有基类型的类型，
        /// 因此 null 作为 Object的基类型返回。
        ///
        /// 3. 接口从零个或多个基接口继承;因此，如果 Type 对象表示一个接口，则此属性将返回 null。 
        /// 可以通过 GetInterfaces 或 FindInterfaces确定基接口。
        /// 
        /// 4. 如果当前 Type 表示构造的泛型类型，则基类型将反映泛型参数。 以下面的声明为例：
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            FindDerivedClass();


            Console.Read();
        }

        public static void FindDerivedClass() {
            foreach (var t in typeof(Program).Assembly.GetTypes()) {
                Console.WriteLine("{0} derived from：", t.FullName);

                var derived = t;
                do {
                    derived = derived.BaseType;
                    if (derived != null)
                        Console.WriteLine("     {0}", derived.FullName);
                } while (derived != null);
                Console.WriteLine();
            }
        }

    }


    public class A {
    }
    public class B : A {
    }
    public class C : B {
    }

    public class D<T> { }

    public class F<T> : D<T> { }
}


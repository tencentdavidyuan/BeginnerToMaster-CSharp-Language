using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceReplaceDelegate {
    // 使用接口取代委托。java中没有委托的概念，但是一样可以完成委托的功能
    // 使用接口取代委托可以消除方法的耦合

    class Program {
        static void Main(string[] args) {
            PizzaFactory pizzaFactory = new PizzaFactory();
            ToyCarFactory toycarFactory = new ToyCarFactory();
            WrapFactory wrapFactory = new WrapFactory();

            // 间接调用
            Box boxA = wrapFactory.WrapBox(pizzaFactory);
            Box boxB = wrapFactory.WrapBox(toycarFactory);
            
            Console.WriteLine(boxA.Prouduct.Name);
            Console.WriteLine(boxB.Prouduct.Name);

            Console.ReadKey();
        }
    }

    public class Product {
        public string Name { get; set; }
    }

    public class Box {
        public Product Prouduct { get; set; }
    }

    public class WrapFactory {
        /// <summary>
        /// 打包固定流程；
        /// 1. 生产一个盒子。
        /// 2. 把产品放入盒子中。
        /// 3. 将盒子交付给用户。
        /// 在其中通过使用委托模板作为入参，来打包不同的产品
        /// </summary>
        /// <param name="getProduct"></param>
        /// <returns></returns>
        public Box WrapBox(IProductFactory factory) {
            Box box = new Box();
            Product product = factory.Make();
            box.Prouduct = product;
            return box;
        }
    }

    public interface IProductFactory {
        Product Make();
    }

    public class PizzaFactory : IProductFactory {
        public Product Make() {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
    }

    public class ToyCarFactory : IProductFactory {
        Product IProductFactory.Make() {
            Product product = new Product();
            product.Name = "Toy Car";

            return product;
        }
    }   
}

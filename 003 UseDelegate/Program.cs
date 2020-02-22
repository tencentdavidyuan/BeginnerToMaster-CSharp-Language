using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample {
    class Program {
        static void Main(string[] args) {
            MethodA();
            MethodB();

            Console.ReadKey();
        }

        static void MethodA() {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            // 直接调用
            Box boxA = wrapFactory.WrapBox(productFactory.MakePizza);
            Box boxB = wrapFactory.WrapBox(productFactory.MakePen);
            Box boxC = wrapFactory.WrapBox(productFactory.MakeToyCar);

            Console.WriteLine(boxA.Prouduct.Name);
            Console.WriteLine(boxB.Prouduct.Name);
            Console.WriteLine(boxC.Prouduct.Name);
        }

        static void MethodB() {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            // 间接调用
            Func<Product> makePizza = new Func<Product>(productFactory.MakePizza);
            Func<Product> makePen = new Func<Product>(productFactory.MakePen);
            Func<Product> makeToyCar = new Func<Product>(productFactory.MakeToyCar);

            Box boxA = wrapFactory.WrapBox(makePizza);
            Box boxB = wrapFactory.WrapBox(makePen);
            Box boxC = wrapFactory.WrapBox(makeToyCar);

            Console.WriteLine(boxA.Prouduct.Name);
            Console.WriteLine(boxB.Prouduct.Name);
            Console.WriteLine(boxC.Prouduct.Name);
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
        public Box WrapBox(Func<Product> getProduct) {
            Box box = new Box();
            Product product = getProduct.Invoke();
            box.Prouduct = product;
            return box;
        }

        public Box WrapBox2(Func<Product> getProduct) {
            Box box = new Box();
            box.Prouduct = getProduct.Invoke();
            return box;
        }
    }


    /// <summary>
    /// 用于生产各种产品
    /// </summary>
    public class ProductFactory {
        /// <summary>
        /// 制作Pizza
        /// </summary>
        /// <returns></returns>
        public Product MakePizza() {
            Product product = new Product();
            product.Name = "Pizza";

            return product;
        }

        /// <summary>
        /// 制作钢笔
        /// </summary>
        /// <returns></returns>
        public Product MakePen() {
            Product product = new Product();
            product.Name = "Pen";

            return product;
        }

        public Product MakeToyCar() {
            Product product = new Product();
            product.Name = "Toy Car";

            return product;
        }
    }
}

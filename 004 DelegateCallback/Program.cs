using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample {
    class Program {
        static void Main(string[] args) {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            // 间接调用
            Func<Product> makePizza = new Func<Product>(productFactory.MakePizza);
            Func<Product> makePen = new Func<Product>(productFactory.MakePen);
            Func<Product> makeToyCar = new Func<Product>(productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.Log);

            Box boxA = wrapFactory.WrapBox(makePizza, log);
            Box boxB = wrapFactory.WrapBox(makePen, log);
            Box boxC = wrapFactory.WrapBox(makeToyCar, log);

            Console.WriteLine(boxA.Prouduct.Name);
            Console.WriteLine(boxB.Prouduct.Name);
            Console.WriteLine(boxC.Prouduct.Name);

            Console.ReadKey();
        }
    }

    class Logger {
        public void Log(Product product) {
            Console.WriteLine("Produce {0} created at {1}.Price is {2}",
                product.Name, DateTime.UtcNow, product.Price);
        }
    }

    public class Product {
        public string Name { get; set; }
        public double Price { get; set; }
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
        public Box WrapBox(Func<Product> getProduct, Action<Product> logCallback) {
            Box box = new Box();
            Product product = getProduct.Invoke();
            box.Prouduct = product;

            if (product.Price >= 50) {
                logCallback(product);
            }
            
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
            product.Price = 12;

            return product;
        }

        /// <summary>
        /// 制作钢笔
        /// </summary>
        /// <returns></returns>
        public Product MakePen() {
            Product product = new Product();
            product.Name = "Pen";
            product.Price = 51;

            return product;
        }

        public Product MakeToyCar() {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;

            return product;
        }
    }
}

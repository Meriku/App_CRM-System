using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM__EntityFramework_
{
    public class Product
    {

        public int Id { get; set; }

        public int art { get; set; }

        public string type { get; set; }

        public string name { get; set; }

        public decimal cost { get; set; }

        public decimal price { get; set; }

        public float package { get; set; }

        public string unitOfMeasure { get; set; }

        public int balance { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }


        public override string ToString()
        {
            return $"Товар #{Id}:\n Артикул {art} Тип: {type} Название: {name}\n Себестоимость: {cost} Цена: {price} \n Упаковка по: {package} {unitOfMeasure}  \n Остаток: {balance} упаковок.";
        }

        public static void Add()
        {

            Console.WriteLine("Введите артикул нового товара");
            var productArt = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите тип нового товара");
            var productType = Console.ReadLine();
            Console.WriteLine("Введите название нового товара");
            var productName = Console.ReadLine();
            Console.WriteLine("Введите себестоимость нового товара");
            var productCost = decimal.Parse(Console.ReadLine());
            var productPrice = decimal.Multiply(productCost, 1.5M);
            Console.WriteLine("Введите размер упаковки нового товара");
            var productPackage = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите единицы измерения нового товара (литры, килограммы)");
            var productUnitOfMeasure = Console.ReadLine();
            Console.WriteLine("Введите количество товара на складе");
            var productBalance = int.Parse(Console.ReadLine());


            using (var context = new MyDbContext())
            {
                var product = new Product()
                {
                    art = productArt,
                    type = productType,
                    name = productName,
                    cost = productCost,
                    price = productPrice,
                    package = productPackage,
                    unitOfMeasure = productUnitOfMeasure,
                    balance = productBalance
                };

                context.Products.Add(product);
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Товар успешно добавлен!");
            }
        }

        public static void Delete()
        {

            Console.WriteLine("Введите Id товара для удаления с базы данных");
            var productId = int.Parse(Console.ReadLine());
        
            using (var context = new MyDbContext())
            {               
                context.Products.Remove(context.Products.Single(item => item.Id == productId));
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Товар успешно удален!");
            }
        }

        public static void PrintAll()
        {
            Console.Clear();
            Console.WriteLine("\nВсе товары компании:\n");

            using (var context = new MyDbContext())
            {

                foreach (var prod in context.Products)
                {
                    Console.WriteLine(prod.ToString());
                }

            }
        }

        public static void PrintNames()
        {
            Console.WriteLine("\nВсе товары компании:\n");

            using (var context = new MyDbContext())
            {

                foreach (var prod in context.Products)
                {
                    Console.WriteLine($"Товар #{prod.Id}\t{prod.type} {prod.name} \n\t\tЦена: {prod.price} Остаток: {prod.balance}");
                }

            }
        }
    }
}

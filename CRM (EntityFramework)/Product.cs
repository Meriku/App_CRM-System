using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM__EntityFramework_
{
    public class Product
    {
        public static decimal margin = 1.5M;

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
            var productArt = UserInterface.AskChoice("Введите артикул нового товара", 199999999);
            var productType = UserInterface.AskChoice("Введите тип нового товара");
            var productName = UserInterface.AskChoice("Введите название нового товара");

            var productCost = UserInterface.AskChoice("Введите себестоимость нового товара", 1000M);
            var productPrice = decimal.Multiply(productCost, margin);

            var productPackage = UserInterface.AskChoice("Введите размер упаковки нового товара", 100.0F);

            var productUnitOfMeasure = UserInterface.AskChoice("Введите единицы измерения нового товара (литры, килограммы)");
            var productBalance = UserInterface.AskChoice("Введите количество товара на складе", 10000);


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

        public static void AddBalance()
        {
            PrintNames();
            var productId = UserInterface.AskChoice("Введите Id товара", new Product());

            var productBalance = UserInterface.AskChoice("Введите количество привезенного товара", 10000);

            using (var context = new MyDbContext())
            {
                context.Products.Single(x => x.Id == productId).balance += productBalance;
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Товар успешно добавлен на склад!");
            }
        }



        public static void Delete()
        {
            PrintNames();
            var productId = UserInterface.AskChoice("Введите Id товара для удаления с базы данных", new Product());

            using (var context = new MyDbContext())
            {               
                context.Products.Remove(context.Products.Single(item => item.Id == productId));
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Товар успешно удален!");
            }
        }

        public static void PrintAll(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

            Console.WriteLine("\nВсе товары компании:\n");

            using (var context = new MyDbContext())
            {

                foreach (var prod in context.Products)
                {
                    Console.WriteLine(prod.ToString());
                }

            }
        }

        public static void PrintNames(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

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

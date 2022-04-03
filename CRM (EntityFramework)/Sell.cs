using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM__EntityFramework_
{
    public class Sell
    {
        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }

        public int Id { get; set; }

        public int clientId { get; set; }

        public int productId { get; set; }

        public int count { get; set; }

        public decimal productPrice { get; set; }

        public decimal price { get; set; }

        public override string ToString()
        {
            return $"Продажа #{Id}:\n Товар #{productId} {Product.type} {Product.name} \n Клиент #{clientId} {Client.lastName} {Client.firstName} \n Стоимость единицы: {productPrice} Количество: {count} \n Стоимость поставки: {price}";
        }

        public static void Add()
        {

            Client.PrintNames();
            var sellclientId = UserInterface.AskChoice("Введите Id клиента покупателя", new Client());
            
            Product.PrintNames();
            var sellproductId = UserInterface.AskChoice("Введите Id товара", new Product());

            var sellcount = UserInterface.AskChoice("Введите количество проданных упаковок товара", 1000);

            using (var context = new MyDbContext())
            {
                decimal sellproductPrice = context.Products.Single(item => item.Id == sellproductId).price;  // Получаем цену товара
                var sellprice = sellproductPrice * sellcount;                                                // Считаем стоимость партии товара
                
                if (context.Products.Single(item => item.Id == sellproductId).balance >= sellcount)
                {
                    var sell = new Sell()
                    {
                        clientId = context.Clients.Single(item => item.Id == sellclientId).Id,
                        productId = context.Products.Single(item => item.Id == sellproductId).Id,
                        count = sellcount,
                        productPrice = sellproductPrice,
                        price = sellprice
                    };

                    context.Sells.Add(sell);
                    context.Products.Single(item => item.Id == sellproductId).balance -= sellcount;              // Уменьшаем остаток на складе

                    context.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Продажа успешно добавлена!");
                }
                else
                {
                    Console.WriteLine("На складе нет достаточного количества товара. Пополните запасы.");
                }
    
            }
        }

        public static void Delete()
        {
            PrintNames();
            var sellId = UserInterface.AskChoice("Введите Id продажи для удаления с базы данных", new Sell());

            using (var context = new MyDbContext())
            {
                var currentsale = context.Sells.Single(item => item.Id == sellId);
                
                context.Products.Find(currentsale.productId).balance += currentsale.count;  // Возвращение товара на склад после удаление продажи 
                context.Sells.Remove(currentsale);                                          // Удаляем продажу

                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Продажа успешно удалена! Товар вернули на склад.");
            }
        }

        public static void PrintAllByClient(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

            Client.PrintNames();
            var clientId = UserInterface.AskChoice("Введите Id интересующего клиента покупателя", new Client());
            Console.Clear();

            using (var context = new MyDbContext())
            {
                var client = context.Clients.Single(item => item.Id == clientId);
                Console.WriteLine($"\nВсе продажи компании по клиенту {client.lastName} {client.firstName} {client.patronymicName}:\n");

                var selllist = context.Sells.Where(item => item.clientId == clientId);
                var sellcost = selllist.Select(item => item.price).Sum();

                foreach (Sell sell in selllist)
                {    
                     Console.WriteLine(sell.ToString());                         
                }

                Console.WriteLine($"\nОбщая сумма закупок по клиенту {client.lastName} {client.firstName} {client.patronymicName}: {sellcost}");

            }
        }

        public static void PrintAllByProduct(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

            Product.PrintNames();
            var productId = UserInterface.AskChoice("Введите Id интересующего товара", new Product());
            Console.Clear();

            using (var context = new MyDbContext())
            {
                var product = context.Products.Single(item => item.Id == productId);
                Console.WriteLine($"\nВсе продажи компании по товару {product.type} {product.name}:\n");

                var selllist = context.Sells.Where(item => item.productId == productId);
                var sellcost = selllist.Select(item => item.price).Sum();

                foreach (Sell sell in selllist)
                {
                    Console.WriteLine(sell.ToString());
                }

                Console.WriteLine($"\nОбщая сумма закупок по товару {product.type} {product.name}: {sellcost}");

            }
        }

        public static void PrintAll(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

            Console.WriteLine("\nВсе продажи компании:\n");

            using (var context = new MyDbContext())
            {

                foreach (Sell sell in context.Sells)
                {
                    Console.WriteLine(sell.ToString());
                }

            }
        }

        public static void PrintNames(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

            Console.WriteLine("\nВсе продажи компании:\n");

            using (var context = new MyDbContext())
            {

                foreach (var sell in context.Sells)
                {
                    Console.WriteLine($"Продажа #{sell.Id} Стоимость партии: {sell.price} \t{sell.Client.lastName} {sell.Client.firstName} \n\t Товар: {sell.Product.type} {sell.Product.name} Количество: {sell.count}\n");
                }

            }
        }
    }
}

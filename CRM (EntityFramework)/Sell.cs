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
            Console.Clear();
            Client.PrintNames();
            Console.WriteLine("\nВведите Id клиента покупателя");
            var sellclientId = int.Parse(Console.ReadLine());
            Console.Clear();
            Product.PrintNames();
            Console.WriteLine("\nВведите Id товара");
            var sellproductId = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество проданных упаковок товара");
            var sellcount = int.Parse(Console.ReadLine());
            


            using (var context = new MyDbContext())
            {
                decimal sellproductPrice = context.Products.Single(item => item.Id == sellproductId).price;  // Получаем цену товара
                var sellprice = sellproductPrice * sellcount;                                                // Считаем стоимость партии товара
                

                var sell = new Sell()
                {
                    clientId = context.Clients.Single(item => item.Id == sellclientId).Id,
                    productId = context.Products.Single(item => item.Id == sellproductId).Id,
                    count = sellcount,
                    productPrice = sellproductPrice,
                    price = sellprice
                };

                

                context.Sells.Add(sell);
                context.Products.Single(item => item.Id == sellproductId).balance -= sellcount;

                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Продажа успешно добавлена!");
            }
        }

        public static void Delete()
        {

            Console.WriteLine("Введите Id продажи для удаления с базы данных");
            var sellId = int.Parse(Console.ReadLine());

            using (var context = new MyDbContext())
            {
                // TODO: Возвращение товара на склад после удаление продажи 
                context.Sells.Remove(context.Sells.Single(item => item.Id == sellId));
                // Удаляем продажу
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Продажа успешно удалена! Товар вернули на склад.");
            }
        }


        public static void PrintAll()
        {
            Console.Clear();
            Console.WriteLine("\nВсе продажи компании:\n");

            using (var context = new MyDbContext())
            {

                foreach (Sell sell in context.Sells)
                {
                    Console.WriteLine(sell.ToString());
                }

            }
        }

    }
}

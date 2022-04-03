using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM__EntityFramework_
{
    public class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Вас приветствует база данных компании\nВыберите действие");

            while (true)
            {
                Console.WriteLine("\t1 - Добавить нового клиента");
                Console.WriteLine("\t2 - Добавить новый товар");
                Console.WriteLine("\t3 - Добавить новую продажу");
                Console.WriteLine("\t4 - Вывести всех клиентов");
                Console.WriteLine("\t5 - Вывести все товары");
                Console.WriteLine("\t6 - Вывести все продажи");
                Console.WriteLine("\t7 - Удалить клиента");
                Console.WriteLine("\t8 - Удалить товар");
                Console.WriteLine("\t9 - Удалить продажу");
                Console.WriteLine("\t10 - Новая поставка товара");
                Console.WriteLine("\t11 - Вывести все продажи по одному клиенту");
                Console.WriteLine("\t12 - Вывести все продажи по одному товару");
          

                switch (UserInterface.AskChoice("", 12))
                {
                    case 1:
                        Console.WriteLine("Вы выбрали добавить нового клиента");

                        Client.Add();

                        break;
                    case 2:
                        Console.WriteLine("Вы выбрали добавить новый товар");

                        Product.Add();

                        break;
                    case 3:
                        Console.WriteLine("Вы выбрали добавить новую продажу");

                        Sell.Add();

                        break;
                    case 4:
                        Console.WriteLine("Вы выбрали вывести всех клиентов");

                        Client.PrintAll();

                        break;
                    case 5:
                        Console.WriteLine("Вы выбрали вывести все товары");

                        Product.PrintAll();

                        break;
                    case 6:
                        Console.WriteLine("Вы выбрали вывести все продажи");

                        Sell.PrintAll();

                        break;
                    case 7:
                        Console.WriteLine("Вы выбрали удалить клиента");

                        Client.Delete();

                        break;
                    case 8:
                        Console.WriteLine("Вы выбрали удалить товар");

                        Product.Delete();

                        break;
                    case 9:
                        Console.WriteLine("Вы выбрали удалить продажу");

                        Sell.Delete();

                        break;
                    case 10:
                        Console.WriteLine("Новая поставка товара");

                        Product.AddBalance();

                        break;
                    case 11:
                        Console.WriteLine("Вывести все продажи по одному клиенту");

                        Sell.PrintAllByClient();

                        break;
                    case 12:
                        Console.WriteLine("Вывести все продажи по одному товару");

                        Sell.PrintAllByProduct();

                        break;
                }

                Console.WriteLine("\n");

            }
        }
       





    }
}

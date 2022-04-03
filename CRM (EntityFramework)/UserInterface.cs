using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM__EntityFramework_
{
    public class UserInterface
    {

        public static int AskChoice(string question, Client client)
        {
            var possibleIds = new List<int>();

            using (var context = new MyDbContext())
            {
                possibleIds = context.Clients.Select(c => c.Id).ToList();
            }

            Console.WriteLine("\n" + question);

            int result;
            while (!(int.TryParse(Console.ReadLine(), out result) && result >= 0 && possibleIds.Contains(result)))
            {
                Console.WriteLine($"Сделайте корректный выбор. Не существует клиента с Id {result}");
            }

            return result;
        }

        public static int AskChoice(string question, Product product)
        {
            var possibleIds = new List<int>();

            using (var context = new MyDbContext())
            {
                possibleIds = context.Products.Select(c => c.Id).ToList();
            }

            Console.WriteLine("\n" + question);

            int result;
            while (!(int.TryParse(Console.ReadLine(), out result) && result >= 0 && possibleIds.Contains(result)))
            {
                Console.WriteLine($"Сделайте корректный выбор. Не существует товара с Id {result}");
            }

            return result;
        }

        public static int AskChoice(string question, Sell sell)
        {
            var possibleIds = new List<int>();

            using (var context = new MyDbContext())
            {
                possibleIds = context.Sells.Select(c => c.Id).ToList();
            }

            Console.WriteLine("\n" + question);

            int result;
            while (!(int.TryParse(Console.ReadLine(), out result) && result >= 0 && possibleIds.Contains(result)))
            {
                Console.WriteLine($"Сделайте корректный выбор. Не существует продажи с Id {result}");
            }

            return result;
        }

        public static int AskChoice(string question, int maxvalue)
        {
            Console.WriteLine("\n" + question);

            int result;
            while (!(int.TryParse(Console.ReadLine(), out result) && result >= 0 && result <= maxvalue))
            {
                Console.WriteLine($"Сделайте корректный выбор. Значение от 0 до {maxvalue}");
            }

            return result;
        }
        public static decimal AskChoice(string question, decimal maxvalue)
        {
            Console.WriteLine("\n" + question);

            decimal result;
            while (!(decimal.TryParse(Console.ReadLine(), out result) && result >= 0 && result <= maxvalue))
            {
                Console.WriteLine($"Сделайте корректный выбор. Значение от 0 до {maxvalue}");
            }

            return result;
        }

        public static float AskChoice(string question, float maxvalue)
        {
            Console.WriteLine("\n" + question);

            float result;
            while (!(float.TryParse(Console.ReadLine(), out result) && result >= 0 && result <= maxvalue))
            {
                Console.WriteLine($"Сделайте корректный выбор. Значение от 0 до {maxvalue}");
            }

            return result;
        }

        public static DateTime? AskChoice(string question, bool isrequired)
        {        
            Console.WriteLine("\n" + question);

            while (true)
            {
                var userchoice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userchoice) && !isrequired)
                {
                    return null;
                }
                else
                {
                    if (DateTime.TryParse(userchoice, out var result) && result >= DateTime.Parse("01.01.1900") && result <= DateTime.Today) 
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"Сделайте корректный выбор. Дата от 01.01.1900");
                    }
                }
            }
        }


        public static string AskChoice(string question)
        {
            Console.WriteLine("\n" + question);

            string result = Console.ReadLine();
            result.Trim();
            result = char.ToUpper(result[0]) + result.Substring(1);

            return result;
        }
    }
}

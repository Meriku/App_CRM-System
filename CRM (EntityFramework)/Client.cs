using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM__EntityFramework_
{
    public class Client
    {      
        public int Id { get; set; }

        public string lastName { get; set; }

        public string firstName { get; set; }

        public string patronymicName { get; set; }

        public DateTime? birthDate { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return $"Клиент #{Id}:\n {lastName} {firstName} {patronymicName}\n Дата рождения: {birthDate:d} \n Телефон: {phoneNumber} \n Email: {email}";
        }

        public static void Add()
        {
            var clientfirstName = UserInterface.AskChoice("Введите имя нового клиента");
            var clientlastName = UserInterface.AskChoice("Введите фамилию нового клиента");
            var clientpatronymicName = UserInterface.AskChoice("Введите отчество нового клиента");
            var clientbirthDate = UserInterface.AskChoice("Введите дату рождения нового клиента - формат 00.00.0000 - (необязательное поле)", isrequired: false);
            var clientphoneNumber = UserInterface.AskChoice("Введите номер телефона нового клиента");
            var clientemail = UserInterface.AskChoice("Введите email нового клиента");

            using (var context = new MyDbContext())
            {
                var client = new Client()
                {
                    lastName = clientlastName,
                    firstName = clientfirstName,
                    patronymicName = clientpatronymicName,
                    birthDate = clientbirthDate,
                    phoneNumber = clientphoneNumber,
                    email = clientemail
                };

                context.Clients.Add(client);
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Клиент успешно добавлен!");
            }
        }
        public static void Delete()
        {
            PrintNames();
            var clientId = UserInterface.AskChoice("Введите Id клиента для удаления с базы данных", new Client());

            using (var context = new MyDbContext())
            {
                context.Clients.Remove(context.Clients.Single(item => item.Id == clientId));
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Клиент успешно удален!");
            }
        }

        public static void PrintAll(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

            Console.WriteLine("\nВсе клиенты компании:\n");

            using (var context = new MyDbContext())
            {
                
                foreach (var cl in context.Clients)
                {
                    Console.WriteLine(cl.ToString());
                }
               
            }
        }

        public static void PrintNames(bool ClearConsole = true)
        {
            if (ClearConsole)
            {
                Console.Clear();
            }

            Console.WriteLine("\nВсе клиенты компании:\n");

            using (var context = new MyDbContext())
            {

                foreach (var cl in context.Clients)
                {
                    Console.WriteLine($"Клиент #{cl.Id}\t{cl.lastName} {cl.firstName} {cl.patronymicName}");
                }

            }
        }



    }
}

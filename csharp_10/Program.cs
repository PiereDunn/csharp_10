namespace csharp_10
{
    class Program
    {
        static public List<Client> clients = new List<Client>();
        static string path = "emp.csv";

        static void Main(string[] args)
        {
            
            Consultant cons = new Consultant();
            Manager manager = new Manager();

            GetAllClients();

            char key;
            do
            {
                Console.WriteLine("Выберите должность: 1.Консультант. 2. Менеджер.\n");
                string pos = Console.ReadLine();

                if (int.TryParse(pos, out int number) && 0 < Convert.ToInt32(pos) && Convert.ToInt32(pos) < 3)
                {
                    //Консультант
                    if (Convert.ToInt32(pos) == 1)
                    {
                        do
                        {
                            cons.Interaction(clients);

                            Console.WriteLine("Продолжить работу в роли консультанта? д/н");
                            key = Console.ReadKey(true).KeyChar;
                        } while (char.ToLower(key) == 'д' || char.ToLower(key) == 'l');
                    }
                    //Менеджер
                    else if (Convert.ToInt32(pos) == 2)
                    {
                        do
                        {
                            manager.Interaction(clients);

                            Console.WriteLine("Продолжить работу в роли менеджера? д/н");
                            key = Console.ReadKey(true).KeyChar;
                        } while (char.ToLower(key) == 'д' || char.ToLower(key) == 'l');
                    }
                }
                else
                {
                    Console.Write("Неверный ввод\n");
                }
                
                Console.WriteLine("Продолжить работу с приложением? д/н");
                key = Console.ReadKey(true).KeyChar;
            } while (char.ToLower(key) == 'д' || char.ToLower(key) == 'l');

        }

        /// <summary>
        /// Чтение всего файла с рабочими и возврат массива данных
        /// </summary>
        /// <returns></returns>
        static List<Client> GetAllClients()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] lines = sr.ReadToEnd().Split('@');    //Массив строк

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] != string.Empty)
                        {
                            string[] words = lines[i].Split('#');       //Массив слов

                            clients.Add(new Client(
                                words[0],                      //Фамилия
                                words[1],                      //Имя
                                words[2],                      //Отчество
                                words[3],                      //Номер телефона
                                words[4]));                    //Паспорт
                        }
                    }
                }
            }
            return clients;
        }
    }
}
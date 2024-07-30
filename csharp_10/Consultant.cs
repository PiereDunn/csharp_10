namespace csharp_10
{
    interface IInterface
    {
        /// <summary>
        /// Изменение парамаетра клиента
        /// </summary>
        /// <param name="option"></param>
        /// <param name="optionNumber"></param>
        public void ChangeOption(string option, int optionNumber, Client client)
        {
            //Изменение Фамилии
            if (optionNumber == 1)
            {
                client.Fam = option;
                client.ChangeDate = DateTime.Now;
                client.ChangeOption = "Фамилия";
                if (GetType() == typeof(Manager)) client.WhoChanged = "Менеджер";
                else if (GetType() == typeof(Consultant)) client.WhoChanged = "Консультант";
            }
            //Изменение Имени
            else if (optionNumber == 2)
            {
                client.Name = option;
                client.ChangeDate = DateTime.Now;
                client.ChangeOption = "Имя";
                if (GetType() == typeof(Manager)) client.WhoChanged = "Менеджер";
                else if (GetType() == typeof(Consultant)) client.WhoChanged = "Консультант";
            }
            //Изменение Фамилии
            else if (optionNumber == 3)
            {
                client.Otch = option;
                client.ChangeDate = DateTime.Now;
                client.ChangeOption = "Отчество";
                if (GetType() == typeof(Manager)) client.WhoChanged = "Менеджер";
                else if (GetType() == typeof(Consultant)) client.WhoChanged = "Консультант";
            }
            //Изменение номера телефона
            else if (optionNumber == 4)
            {
                client.Number = option;
                client.ChangeDate = DateTime.Now;
                client.ChangeOption = "Номер";
                if (GetType() == typeof(Manager)) client.WhoChanged = "Менеджер";
                else if (GetType() == typeof(Consultant)) client.WhoChanged = "Консультант";
            }
            //Изменение серии и номера паспорта
            else if (optionNumber == 5)
            {
                client.Pass = option;
                client.ChangeDate = DateTime.Now;
                client.ChangeOption = "Серия и номер паспорта";
                if (GetType() == typeof(Manager)) client.WhoChanged = "Менеджер";
                else if (GetType() == typeof(Consultant)) client.WhoChanged = "Консультант";
            }
        }
    }

    class Consultant : IInterface
    {
        /// <summary>
        /// Текст действий для консультанта
        /// </summary>
        public virtual string actionText { get; set; } = "Укажите действие: 1.Просмотр информации. 2.Изменение параметров клиента. \n";

        public void Interaction(List<Client> clients)
        {
            Console.Write(actionText);
            //Console.Write("Укажите действие: 1.Просмотр информации. 2.Изменение параметров клиента. 3.Добавление новой записи \n");
            string action = Console.ReadLine();

            //Проверка корректности ввода
            if (int.TryParse(action, out int number) && 0 < Convert.ToInt32(action) && Convert.ToInt32(action) < 4)
            {
                //Просмотр информации о клиенте
                if (Convert.ToUInt32(action) == 1)  
                {
                    Print(clients);
                }
                //Изменение номера клиента
                else if (Convert.ToUInt32(action) == 2)  
                {
                    ChangeClient(clients);
                }
                //Добавление новой записи
                else if (Convert.ToUInt32(action) == 3)
                {
                    if(GetType() == typeof(Manager))
                    {
                        AddNewClient(clients);
                    }
                    else
                    {
                        Console.Write("Ой, а вы не менеджер \n");
                    }
                }
            }
            else
            {
                Console.Write("Неверный ввод\n");
            }
        }

        /// <summary>
        /// Добавление нового клиента в базу данных
        /// </summary>
        /// <param name="clients"></param>
        public void AddNewClient(List<Client> clients)
        {
            Console.Write("Введите Фамилию: \n");  //Фамилия
            string fam = Console.ReadLine();
            if (fam != String.Empty)
            {
                Console.Write("Введите Имя: \n");  //Имя
                string name = Console.ReadLine();
                if (name != String.Empty)
                {
                    Console.Write("Введите Отчество: \n");  //Отчество
                    string otch = Console.ReadLine();
                    if (otch != String.Empty)
                    {
                        Console.Write("Введите номер телефона: \n");  //Номер телефона
                        string number = Console.ReadLine();
                        if (int.TryParse(number, out int Number) && number != String.Empty)
                        {
                            Console.Write("Введите серию и номер паспорта: \n");  //Серия и номер паспорта
                            string pass = Console.ReadLine();
                            if (long.TryParse(pass, out long Number1) && pass != String.Empty)
                            {
                                clients.Add(new Client(fam, name, otch, number, pass));  //Добавление
                            }
                            else Console.Write("Неверный ввод");
                        }
                        else Console.Write("Неверный ввод");
                    }
                    else Console.Write("Неверный ввод");
                }
                else Console.Write("Неверный ввод");
            }
            else Console.Write("Неверный ввод");
        }


        /// <summary>
        /// Вывод информации о клиенте для консультанта
        /// </summary>
        /// <param name="clients"></param>
        public virtual void Print(List<Client> clients)
        {
            string changes = String.Empty;

            Console.Write("Введите ID клиента. \n");

            string clientID = Console.ReadLine();

            if (int.TryParse(clientID, out int nubmer) && Convert.ToInt32(clientID) > 0 && Convert.ToInt32(clientID) < clients.Count + 1)
            {
                Client client = clients[Convert.ToInt32(clientID) - 1];

                if(client.ChangeOption != String.Empty && client.WhoChanged != String.Empty)
                {
                    string changesVariant = $"Дата изменеения: {client.ChangeDate}, Параметр изменения: {client.ChangeOption}, Кто изменял : {client.WhoChanged} \n";
                    changes = changesVariant;
                }

                if (client.Number != String.Empty && client.Pass != String.Empty)
                {
                    Console.Write($"Фамилия: {client.Fam}. Имя: {client.Name}, Отчество: {client.Otch}, Номер: {"******"}, Паспорт: {"**********"}\n {changes}");
                }
                else if (client.Number == String.Empty && client.Pass != String.Empty)
                {
                    Console.Write($"Фамилия: {client.Fam}. Имя: {client.Name}, Отчество: {client.Otch}, Номер: {"отсутствует"}, Паспорт: {"**********"}\n {changes}");
                }
                else if (client.Number != String.Empty && client.Pass == String.Empty)
                {
                    Console.Write($"Фамилия: {client.Fam}. Имя: {client.Name}, Отчество: {client.Otch}, Номер: {"******"}, Паспорт: {"отсутствует"}\n {changes}");
                }
                else
                {
                    Console.Write($"Фамилия: {client.Fam}. Имя: {client.Name}, Отчество: {client.Otch}, Номер: {"отсутствует"}, Паспорт: {"отсутствует"}\n {changes}");
                }
            }
            else
            {
                Console.Write("Рабочий не найден\n");
            }
        }

        /// <summary>
        /// Изменение информации клиента консультантом
        /// </summary>
        /// <param name="clients"></param>
        public virtual void ChangeClient(List<Client> clients)
        {
            IInterface iinter = new Consultant();

            Console.Write("Введите ID клиента. \n");

            string clientID = Console.ReadLine();
            if (int.TryParse(clientID, out int nubmer) && Convert.ToInt32(clientID) > 0 && Convert.ToInt32(clientID) < clients.Count + 1)
            {
                Console.Write("Введите новый номер. \n");
                string newNumber = Console.ReadLine();
                if (int.TryParse(newNumber, out int number))
                {
                    iinter.ChangeOption(newNumber, 4, clients[Convert.ToInt32(clientID) - 1]);
                    Console.Write("Номер изменен. \n");
                }
                else
                {
                    Console.Write("Номер не изменен. \n");
                }
            }
            else
            {
                Console.Write("ID введен неверно. \n");
            }
        }
    }
}

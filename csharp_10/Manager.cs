namespace csharp_10
{
    class Manager : Consultant
    {
        /// <summary>
        /// Текст действий для менеджера
        /// </summary>
        public override string actionText { get; set; } = "Укажите действие: 1.Просмотр информации. 2.Изменение параметров клиента. 3.Добавление новой записи \n";

        /// <summary>
        /// Вывод информации о клиенте для менеджера
        /// </summary>
        /// <param name="clients"></param>
        public override void Print(List<Client> clients)
        {
            string changes = String.Empty;

            Console.Write("Введите ID клиента. \n");

            string clientID = Console.ReadLine();

            if (int.TryParse(clientID, out int nubmer) && Convert.ToInt32(clientID) > 0 && Convert.ToInt32(clientID) < clients.Count + 1)
            {
                Client client = clients[Convert.ToInt32(clientID) - 1];

                if (client.ChangeOption != String.Empty && client.WhoChanged != String.Empty)
                {
                    string changesVariant = $"Дата изменеения: {client.ChangeDate}, Параметр изменения: {client.ChangeOption}, Кто изменял : {client.WhoChanged} \n";
                    changes = changesVariant;
                }

                if (client.Number != String.Empty && client.Pass != String.Empty)
                {
                    Console.Write($"Фамилия: {client.Fam}. Имя: {client.Name}, Отчество: {client.Otch}, Номер: {client.Number}, Паспорт: {client.Pass}\n {changes}");
                }
                else if (client.Number == String.Empty && client.Pass != String.Empty)
                {
                    Console.Write($"Фамилия: {client.Fam}. Имя: {client.Name}, Отчество: {client.Otch}, Номер: {"отсутствует"}, Паспорт: {client.Pass}\n {changes}");
                }
                else if (client.Number != String.Empty && client.Pass == String.Empty)
                {
                    Console.Write($"Фамилия: {client.Fam}. Имя: {client.Name}, Отчество: {client.Otch}, Номер: {client.Number}, Паспорт: {"отсутствует"}\n {changes}");
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
        /// Изменение информации клиента менеджером
        /// </summary>
        /// <param name="clients"></param>
        public override void ChangeClient(List<Client> clients)
        {
            IInterface iinter = new Manager();

            Console.Write("Введите ID клиента. \n");

            string clientID = Console.ReadLine();

            Console.Write("Выберите параметр: 1.Фамилия 2.Имя 3.Отчество 4.Номер телефона 5.Серия и номер паспорта \n");
            string optionNumber = Console.ReadLine();
            if (int.TryParse(optionNumber, out int nubmer) && Convert.ToInt32(optionNumber) > 0 && Convert.ToInt32(optionNumber) < 6)
            {
                string option = Console.ReadLine();

                if (option != String.Empty)
                {
                    iinter.ChangeOption(option, Convert.ToInt32(optionNumber), clients[Convert.ToInt32(clientID) - 1]);
                    Console.Write("Параметр изменен. \n");
                }
                else
                {
                    Console.Write("Параметр не изменен. \n");
                }
            }
            else
            {
                Console.Write("Параметр введен неверно. \n");
            }
        }
    }
}

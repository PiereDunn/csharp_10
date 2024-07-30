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
}

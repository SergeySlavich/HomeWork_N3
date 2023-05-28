using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_N3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** HOME WORK N3 ***\n");
            Console.WriteLine("Выберите задачу из списка:\n");
            Console.WriteLine("\t1. Напишите метод, который отображает квадрат из некоторого символа.\n" +
                "Метод принимает в качестве параметра: длину стороны квадрата, символ.\n");
            Console.WriteLine("\t2. Напишите метод, который проверяет является ли переданное число «палиндромом».\n" +
                "Число передаётся в качестве параметра.\n" +
                "Если число палиндром нужно вернуть из метода true, иначе false.\n" +
                "Палиндром — число, которое читается одинаково как справа налево, так и слева направо.\n" +
                "Например:\n\t1221 — палиндром;\n\t3443 — палиндром;\n\t7854 — не палиндром.\n");
            Console.WriteLine("\t3. Напишите метод, фильтрующий массив на основании переданных параметров.\n" +
                "Метод принимает параметры:\n" +
                "\tоригинальный_массив,\n\tмассив_с_данными_для_фильтрации.\n" +
                "Метод возвращает оригинальный массив без элементов, которые есть в массиве для фильтрации." +
                "\n\tНапример:\n\t\t1 2 6 -1 88 7 6 — оригинальный массив;" +
                "\n\t\t6 88 7 — массив для фильтрации;" +
                "\n\t\t1 2 -1 — результат работы метода.\n");
            Console.WriteLine("\t4. Создайте класс «Веб-сайт».\n" +
                "Необходимо хранить в полях класса: название сайта, путь к сайту, описание сайта, ip адрес сайта.\n" +
                "Реализуйте методы класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы класса.\n");
            Console.WriteLine("\t5. Создайте класс «Журнал».\n" +
                " Необходимо хранить в полях класса: название журнала, год основания, описание журнала, контактный телефон, контактный e-mail.\n" +
                "Реализуйте методы класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы класса.\n");
            Console.WriteLine("\t6. Создайте класс «Магазин».\n" +
                " Необходимо хранить в полях класса: название магазина, адрес, описание профиля магазина, контактный телефон, контактный e-mail.\n" +
                "Реализуйте методы класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы класса.\n");
            Console.WriteLine("\t7. Выход из программы.\n");
            Console.WriteLine("Введите номер задачи (цифру и Enter):\n");
            bool exit = false;
            do
            {
                UInt32 input;// = Int32.Parse(Console.ReadLine());
                while (!UInt32.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Ошибка! Введенные данные невозможно преобразовать в положительное целое число. Попробуйте ещё раз.");
                }
                switch (input)
                {
                    case 1: Tasks.Task_1(); break;
                    case 2: Tasks.Task_2(); break;
                    case 3: Tasks.Task_3(); break;
                    case 4: Tasks.Task_4(); break;
                    case 5: Tasks.Task_5(); break;
                    case 6: Tasks.Task_6(); break;
                    case 7: exit = !exit; break;
                    default: Console.WriteLine("Такого пункта нет в списке задач, попробуйте ещё раз."); break;
                }
            } while (!exit);
        }
    }

    class Tasks
    {
        static void DrawSqware(int size, char symb)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(symb + " ");
                }
                Console.WriteLine();
            }
        }
        static bool isPalindrom(UInt32 number)
        {
            UInt32 number_out = 0;
            UInt32 number_in = number;
            while (number_in > 0)
            {
                number_out *= 10;
                number_out += number_in % 10;
                number_in /= 10;
            }
            return (number == number_out);
        }
        static double[] createArray()
        {
            Console.WriteLine("Введите размер массива:");
            UInt32 size;
            while (!UInt32.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Ошибка! Введенные данные невозможно преобразовать в положительное целое число. Попробуйте ещё раз.");
            }
            double[] arr = new double[size];

            Console.WriteLine("Введите данные массива:");
            for (int i = 0; i < arr.Length; i++)
            {
                double value;
                Console.Write(i + ": ");
                while (!Double.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Ошибка! Введенные данные невозможно преобразовать в число. Попробуйте ещё раз.");
                }
                arr[i] = value;
            }
            return arr;
        }
        static double[] filter(double[] arr, double[] filter)
        {
            bool[] result_0 = new bool[arr.Length];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                bool check = true;

                for (int j = 0; j < filter.Length; j++)
                {
                    if (arr[i] != filter[j] && check == true)
                    {
                        result_0[i] = true;
                    }
                    else
                    {
                        result_0[i] = false;
                        check = false;
                    }
                }
                if (result_0[i] == false)
                {
                    count++;
                }
            }
            double[] result = new double[arr.Length - count];
            for (int i = 0, j = 0; i < arr.Length; i++, j++)
            {
                if (result_0[i] == true)
                {
                    result[j] = arr[i];
                }
                else
                {
                    j--;
                }
            }
            return result;
        }
        public static void Task_1()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** Задание 3. Задача 1. ***\n");
            Console.WriteLine("\nНапишите метод, который отображает квадрат из некоторого символа." +
                "Метод принимает в качестве параметра: длину стороны квадрата, символ.");
            Console.Write("Введите размер квадрата (до 75 включительно): ");
            if (!UInt16.TryParse(Console.ReadLine(), out UInt16 size))
            {
                Console.WriteLine("Ошибка ввода данных! Введенные данные не могут быть преобразованы в число.");
            }
            if (size > 75)
            {
                size = 75;
                Console.WriteLine("Вы ввели число больше 75, что невозможно корректно отобразить, поэтому мы исправили ввод ;)");
            }
            if (size < 1)
            {
                size = 1;
                Console.WriteLine("Вы ввели число меньше 1, что невозможно корректно отобразить, поэтому мы исправили ввод ;)");
            }
            Console.Write("Введите символ, из которого будет нарисован квадрат: ");
            if (!Char.TryParse(Console.ReadLine(), out char symb))
            {
                Console.WriteLine("Ошибка! Введённые данные не могут быть преобразованы в символ.");
            }
            DrawSqware(size, symb);
            Console.WriteLine("Спасибо, что воспользовались нашей программой :) Для возврата в меню нажмите Enter");
            Console.ReadKey();
            Program.Menu();
        }
        public static void Task_2()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** Задание 3. Задача 2. ***\n");
            Console.WriteLine("\nНапишите метод, который проверяет является ли переданное число «палиндромом»." +
                "Число передаётся в качестве параметра." +
                "Если число палиндром нужно вернуть из метода true, иначе false." +
                "Палиндром — число, которое читается одинаково как справа налево, так и слева направо." +
                "Например:\n\t1221 — палиндром;\n\t3443 — палиндром;\n\t7854 — не палиндром.");
            Console.WriteLine("Введите число для проверки на палиндром: ");
            if (!UInt32.TryParse(Console.ReadLine(), out UInt32 input_number))
            {
                Console.WriteLine("Ошибка! Введенные данные невозможно преобразовать в число.");
            }
            else
            {
                Console.WriteLine($"Проверяем, является ли введенное число палиндромом:");
                Console.WriteLine(isPalindrom(input_number) ? "является" : "НЕ является.");
            }
            Console.WriteLine("Для возврата в меню нажмите Enter");
            Console.ReadKey();
            Program.Menu();
        }
        public static void Task_3()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** Задание 3. Задача 3. ***\n");
            Console.WriteLine("\nНапишите метод, фильтрующий массив на основании переданных параметров." +
                "Метод принимает параметры:" +
                "\tоригинальный_массив,\n\tмассив_с_данными_для_фильтрации.\n" +
                "Метод возвращает оригинальный массив без элементов, которые есть в массиве для фильтрации." +
                "\n\tНапример: 1 2 6 -1 88 7 6 — оригинальный массив;" +
                "\n\t6 88 7 — массив для фильтрации;" +
                "\n\t1 2 -1 — результат работы метода.");

            Console.WriteLine("Введите оригинальный массив:");
            double[] first = Tasks.createArray();
            Console.WriteLine("Введите фильтрующий массив:");
            double[] second = Tasks.createArray();

            Console.WriteLine("Оригинальный массив");
            for (int i = 0; i < first.Length; i++)
            {
                Console.Write(first[i]);
                Console.Write(' ');
            }
            Console.WriteLine();
            Console.WriteLine("фильтрующий массив");
            for (int i = 0; i < second.Length; i++)
            {
                Console.Write(second[i]);
                Console.Write(' ');
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            double[] result = (double[])filter(first, second);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
                Console.Write(' ');
            }

            Console.WriteLine();
            Console.WriteLine("Для возврата в меню нажмите Enter");
            Console.ReadKey();
            Program.Menu();
        }
        public static void Task_4()     //Ввод и вывод в задаче 4 и задаче 5 сделаны в разных стилях специально, чтобы посмотреть, какой лучше
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** Задание 3. Задача 4. ***\n");
            Console.WriteLine("\nСоздайте класс «Веб-сайт»." +
                "Необходимо хранить в полях класса: название сайта, путь к сайту, описание сайта, ip адрес сайта." +
                "Реализуйте методы класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы класса.");
            WebSite site = new WebSite();

            //Ввод данных

            Console.WriteLine("Введите название сайта:");
            string input_name = "Default";
            input_name = Console.ReadLine();
            while (input_name == "Default" || input_name == string.Empty)
            {
                Console.WriteLine("Ошибка! Название сайта не может быть пустым. Повторите попытку:");
                input_name = Console.ReadLine();
            }
            site.SiteName = input_name;

            Console.WriteLine("Введите путь к сайту:");
            site.SitePath = Console.ReadLine();

            Console.WriteLine("Введите описание сайта:");
            site.SiteDescription = Console.ReadLine();

            Console.WriteLine("Введите IP сайта:");
            site.SiteIp = Console.ReadLine();

            //Вывод данных

            Console.WriteLine("Данные, введенные для сайта:");
            Console.WriteLine(site.SiteName);
            Console.WriteLine(site.SitePath);
            Console.WriteLine(site.SiteDescription);
            Console.WriteLine(site.SiteIp);

            Console.WriteLine("Для возврата в меню нажмите Enter");
            Console.ReadKey();
            Program.Menu();
        }
        public static void Task_5()     //Ввод и вывод в задаче 4 и задаче 5 сделаны в разных стилях специально, чтобы посмотреть, какой лучше
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** Задание 3. Задача 5. ***\n");
            Console.WriteLine("\n Создайте класс «Журнал». \n" +
                "Необходимо хранить в полях класса: \n\tназвание журнала, \n\tгод основания, \n\tописание журнала, \n\tконтактный телефон, \n\tконтактный e-mail.\n" +
                "Реализуйте методы класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы класса.");
            Console.WriteLine("Если желаете создать журнал, введите имя журнала:");

            //Ввод данных

            string input_name_journal = string.Empty;
            while (input_name_journal == string.Empty)
            {
                input_name_journal = Console.ReadLine();
            }

            Console.WriteLine("Введите описание журнала:");
            string? input_description_journal = Console.ReadLine();

            Console.WriteLine("Введите 11-значный номер контактного телефона:");
            UInt64 input_contact_tel_number = 0;
            bool check = false;
            while (!check)
            {
                check = UInt64.TryParse(Console.ReadLine(), out input_contact_tel_number);
                if (!check)
                {
                    Console.WriteLine("Ошибка! Невозможно введенные данные преобразовать в номер телефона.");
                }
                else if (input_contact_tel_number < 10000000000 || input_contact_tel_number > 99999999999)
                {
                    Console.WriteLine("Ошибка! Количество цифр не соответствует номеру телефона. Пожалуйста, введите 11-значный номер телефона.");
                    check = false;
                }
            }

            Console.WriteLine("Введите контактный e-mail:");
            string input_contact_email = Console.ReadLine();
            while (input_contact_email == string.Empty || !input_contact_email.Contains('@'))
            {
                Console.WriteLine("Введен некорректный адрес электронной почты, пожалуйста, введите корректный адрес электронной почты:");
                input_contact_email = Console.ReadLine();
            }

            //Вывод данных

            Journal journal = new Journal(input_name_journal, input_description_journal, input_contact_tel_number, input_contact_email);

            Console.WriteLine("Название журнала: " + journal.JournalName);
            Console.WriteLine("Описание журнала: " + journal.JournalDescription);
            Console.WriteLine("Дата создания журнала: " + journal.JournalCreationDate.ToString());
            Console.WriteLine("Контактный телефон: +" + journal.ContactTelNumber.ToString());
            Console.WriteLine("Контактный E-mail: " + journal.ContactEmail);

            Console.WriteLine();
            Console.WriteLine("Для возврата в меню нажмите Enter");
            Console.ReadKey();
            Program.Menu();
        }
        public static void Task_6()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** Задание 3. Задача 6. ***\n");
            Console.WriteLine("\nСоздайте класс «Магазин»." +
                "Необходимо хранить в полях класса:" +
                "\n\t название магазина," +
                "\n\t адрес," +
                "\n\t описание профиля магазина," +
                "\n\t контактный телефон," +
                "\n\t контактный e-mail." +
                "Реализуйте методы класса для ввода данных, вывода данных," +
                "реализуйте доступ к отдельным полям через методы класса.");

            //Ввод данных

            Console.WriteLine("Для создания магазина введите его название:");
            string input_name = Console.ReadLine();

            Console.WriteLine("Введите адрес магазина");
            Console.WriteLine("город:");
            string input_sity = Console.ReadLine();
            Console.WriteLine("улицу:");
            string input_street = Console.ReadLine();
            Console.WriteLine("дом:");
            UInt16 input_house;
            while (!UInt16.TryParse(Console.ReadLine(), out input_house))
            {
                Console.WriteLine("Ошибка! Введенные данные невозможно преобразовать в номер дома.");
            }

            Console.WriteLine("Введите описание профиля магазина:");
            string input_profile = Console.ReadLine();

            Console.WriteLine("введите 11-значный номер контактного телефона:");
            UInt64 input_tel_number;
            while (!UInt64.TryParse(Console.ReadLine(), out input_tel_number))
            {
                Console.WriteLine("Ошибка! Невозможно введенные данные преобразовать в номер телефона.");
            }
            while (input_tel_number < 10000000000 || input_tel_number > 99999999999)
            {
                Console.WriteLine("Ошибка! Количество цифр не соответствует номеру телефона. Пожалуйста, введите 11-значный номер телефона.");
            }

            Console.WriteLine("Введите контактный e-mail:");
            string input_email = Console.ReadLine();
            while (input_email == string.Empty || !input_email.Contains('@') || !input_email.Contains('.'))
            {
                Console.WriteLine("Введен некорректный адрес электронной почты, пожалуйста, введите корректный адрес электронной почты:");
            }

            //Вывод данных

            Shop shop = new Shop(input_name, input_sity, input_street, input_house, input_profile, input_tel_number, input_email);

            Console.WriteLine("Был создан магазин " + shop.Name);
            Console.WriteLine("в городе " + shop.AddressSity);
            Console.WriteLine("на улице " + shop.AddressStreet);
            Console.WriteLine("в доме №" + shop.AddressHouse);
            Console.WriteLine("который продает " + shop.Profile);
            Console.WriteLine("Контактный телефон: " + shop.TelNumber);
            Console.WriteLine("Контактный E-mail: " + shop.ContactEmail);

            Console.WriteLine("Для возврата в меню нажмите Enter");
            Console.ReadKey();
            Program.Menu();
        }
    }

    class WebSite
    {
        private string _siteName;
        private string _sitePath;
        private string _siteDescription;
        private string _siteIp;
        public string SiteName
        {
            get { return _siteName; }
            set { _siteName = value; }
        }
        public string SitePath
        {
            get { return _sitePath; }
            set { _sitePath = value; }
        }
        public string SiteDescription
        {
            get { return _siteDescription; }
            set { _siteDescription = value; }
        }
        public string SiteIp
        {
            get { return _siteIp; }
            set { _siteIp = value; }
        }
        public WebSite() : this("default name site", "www.WebSites.ru/default_sites/", "Сайт. Описание по умолчанию.", "172.0.0.1") { }
        public WebSite(string siteName, string sitePath, string siteDescription, string siteIp)
        {
            this.SiteName = siteName;
            this.SitePath = sitePath;
            this.SiteDescription = siteDescription;
            this.SiteIp = siteIp;
        }
    }

    class Journal
    {
        private string _journalName;
        private readonly DateTime _journalCreationDate;
        private string _journalDescription;
        private UInt64 _contactTelNumber;
        private string _contactEmail;
        public string JournalName
        {
            get { return _journalName; }
            set { _journalName = value; }
        }
        public DateTime JournalCreationDate
        {
            get { return _journalCreationDate; }
        }
        public string JournalDescription
        {
            get { return _journalDescription; }
            set { _journalDescription = value; }
        }
        public UInt64 ContactTelNumber
        {
            get { return _contactTelNumber; }
            set 
            {
                if(value < 100000000000 || value > 9999999999)
                {
                    _contactTelNumber = value;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректный телефонный номер!");
                }
            }
        }
        public string ContactEmail
        {
            get { return _contactEmail; }
            set
            {
                if (value.Contains('@') && value.Contains('.'))
                {
                    _contactEmail = value;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введен некорректный адрес.");
                }
            }
        }
        public Journal() : this("default journal", string.Empty, 0, string.Empty) { }
        public Journal(string journalName, string journalDescription, UInt64 contactTelNumber, string contactEmail)
        {
            _journalCreationDate = DateTime.Now;
            this.JournalName = journalName;
            this.JournalDescription = journalDescription;
            this.ContactTelNumber = contactTelNumber;
            this.ContactEmail = contactEmail;
        }
    }

    class Shop
    {
        private string _name;
        private string _address_sity;
        private string _address_street;
        private UInt16 _address_house;
        private string _profile;
        private UInt64 _telNumber;
        private string _contactEmail;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string AddressSity
        {
            get { return _address_sity; }
            set { _address_sity = value; }
        }
        public string AddressStreet
        {
            get { return _address_street; }
            set { _address_street = value; }
        }
        public UInt16 AddressHouse
        {
            get { return _address_house; }
            set { _address_house = value; }
        }
        public string Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }
        public UInt64 TelNumber
        {
            get { return _telNumber; }
            set
            {
                if (value < 100000000000 || value > 9999999999)
                {
                    _telNumber = value;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректный телефонный номер!");
                }
            }
        }
        public string ContactEmail
        {
            get { return _contactEmail; }
            set
            {
                if (value.Contains('@') && value.Contains('.'))
                {
                    _contactEmail = value;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введен некорректный адрес.");
                }
            }
        }
        public Shop() : this("Магазин", "Неизвестный город", "Неизвестная улица", 0, "Неизвестно", 0, "Неизвестный адрес электронной почты") { }
        public Shop(string name, string sity, string street, UInt16 house, string profile, UInt64 tel_number, string contactEmail)
        {
            this.Name = name;
            this.AddressSity = sity;
            this.AddressStreet = street;
            this.AddressHouse = house;
            this.Profile = profile;
            this.TelNumber = tel_number;
            this.ContactEmail = contactEmail;
        }
    }
}
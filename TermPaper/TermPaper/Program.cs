using System;
using System.Collections.Generic;
using Hotels;

namespace TermPaper
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel(Constants.RoomsAmount);
            Console.WriteLine("Здравствуйте, пожалуйста, введите пароль, чтобы начать работу: ");
            string password = "";
            for (int i = 0; i < 3; i++)
            {
                password = Console.ReadLine();
                if (password == Constants.Password)
                    break;
                Console.WriteLine("Пароль неправильный. У Вас ещё осталось попыток: {0}", 2 - i);
            }
            if (password != Constants.Password)
                return;
            Console.Clear();
            Console.WriteLine("Добро пожаловать, менеджер!");
            DateTime time = new DateTime(2020, 06, 05);
            while (true)
            {
                Console.WriteLine("Сегодня {0:D}", time);
                Console.WriteLine("Что Вы хотите сделать?");
                switch (Console.ReadLine())
                {
                    case "0": return;

                    case "1":
                        Console.WriteLine("Пожалуйста, введите фамилию и имя клиента:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Также введите его возраст:");
                        try
                        {
                            Tourist tourist = new Tourist(name, Convert.ToInt32(Console.ReadLine()));
                            tourist.Notify += DisplayMessage;
                            string category;
                            int[] rooms;
                            while (true)
                            {
                                Console.WriteLine("Номер какой категории нужно забронировать?");
                                category = Console.ReadLine();
                                if (category == "Стандарт")
                                {
                                    rooms = Constants.StandartRooms;
                                    break;
                                }
                                else if (category == "Полулюкс")
                                {
                                    rooms = Constants.HalfLuxRooms;
                                    break;
                                }
                                else if (category == "Люкс")
                                {
                                    rooms = Constants.LuxRooms;
                                    break;
                                }
                                else
                                    Console.WriteLine("Категория номера указана неправильно. В отеле есть номера категорий Люкс, Полулюкс и Стандарт.");
                            }
                            Console.WriteLine("До какого числа нужно забронировать номер? Введите два числа через пробел в формате 'чч мм':");
                            string[] date;
                            while (true)
                            {
                                try
                                {
                                    date = Console.ReadLine().Split();
                                    break;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("Указаны недопустимые значения. Попробуйте ещё раз.");
                                    continue;
                                }
                            }
                            int y = 2020;
                            if (time.Month > Convert.ToInt32(date[1]))
                                y++;
                            DateTime deadline = new DateTime(y, Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
                            foreach (int r in rooms)
                                if (tourist.Book(Convert.ToInt32(deadline.Subtract(time).TotalDays), hotel[r], deadline))
                                {
                                    Tourists.WhoBooked.Add(r, tourist);
                                    break;
                                }
                            if (tourist.roomnumber == -1)
                                Console.WriteLine("К сожалению, сейчас в отеле нет номеров данной категории, которые можно забронировать.");
                        }
                        catch (HotelException ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message + "\n");
                            continue;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Пожалуйста, введите фамилию и имя клиента:");
                        string name1 = Console.ReadLine();
                        try
                        {
                            Tourist tourist = null;
                            int[] rooms;
                            foreach (KeyValuePair<int, Tourist> Pair in Tourists.WhoBooked)
                            {
                                if (Pair.Value.name == name1)
                                {
                                    Console.WriteLine("У вас забронирован номер №{0}.", Pair.Key);
                                    tourist = Pair.Value;
                                    Console.WriteLine("На сколько дней нужно снять номер?");
                                    int days2 = Convert.ToInt32(Console.ReadLine());
                                    DateTime date1 = time.AddDays(days2);
                                    int topay1 = days2 * hotel[Pair.Key].price;
                                    Console.WriteLine("К оплате: {0}.", topay1);
                                    int paid1;
                                    while (true)
                                    {
                                        paid1 = Convert.ToInt32(Console.ReadLine());
                                        if (paid1 < topay1)
                                            Console.WriteLine("Недостаточно средств. К оплате: {0}.", topay1);
                                        else
                                            break;
                                    }
                                    tourist.Lease(days2, hotel[Pair.Key], date1);
                                    Tourists.WhoBooked.Remove(Pair.Key);
                                    break;
                                }
                            }
                            if (tourist == null)
                            {
                                Console.WriteLine("Также введите его возраст:");
                                tourist = new Tourist(name1, Convert.ToInt32(Console.ReadLine()));
                                tourist.Notify += DisplayMessage;
                                string category;
                                while (true)
                                {
                                    Console.WriteLine("Номер какой категории нужно снять?");
                                    category = Console.ReadLine();
                                    if (category == "Стандарт")
                                    {
                                        rooms = Constants.StandartRooms;
                                        break;
                                    }
                                    else if (category == "Полулюкс")
                                    {
                                        rooms = Constants.HalfLuxRooms;
                                        break;
                                    }
                                    else if (category == "Люкс")
                                    {
                                        rooms = Constants.LuxRooms;
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Категория номера указана неправильно. В отеле есть номера категорий Люкс, Полулюкс и Стандарт.");
                                }
                                Console.WriteLine("На сколько дней нужно снять номер?");
                                int days1 = Convert.ToInt32(Console.ReadLine());
                                DateTime date = time.AddDays(days1);
                                int topay = days1 * hotel[rooms[0]].price;
                                Console.WriteLine("К оплате: {0}.", topay);
                                int paid;
                                while (true)
                                {
                                    paid = Convert.ToInt32(Console.ReadLine());
                                    if (paid < topay)
                                        Console.WriteLine("Недостаточно средств. К оплате: {0}.", topay);
                                    else
                                        break;
                                }
                                if (paid > topay)
                                    Console.WriteLine($"Примечание: Оплачено за {days1} целых дней. Возвращен остаток, равный {paid - topay}.\n");
                                foreach (int r in rooms)
                                    if (tourist.Lease(days1, hotel[r], date))
                                    {
                                        Tourists.WhoLeased.Add(r, tourist);
                                        break;
                                    }
                                if (tourist.roomnumber == -1)
                                    Console.WriteLine("К сожалению, сейчас в отеле нет свободных номеров данной категории.");
                            }
                        }
                        catch (HotelException ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message + "\n");
                            continue;
                        }
                        break;

                    case "3":
                        Console.WriteLine("О каком номере Вы хотите получить информацию?");
                        int n = Convert.ToInt32(Console.ReadLine());
                        hotel[n - 1].Info();
                        break;

                    case "готово":
                        time = time.AddDays(1);
                        foreach (Room r in hotel)
                        {
                            r.daysofbooking--;
                            r.daysofleasing--;
                        }
                        break;

                    case "помощь":
                        Console.WriteLine("Список доступных комманд:");
                        Console.WriteLine("1 - Забронировать номер.");
                        Console.WriteLine("2 - Снять номер.");
                        Console.WriteLine("3 - Получить информацию о номере.");
                        Console.WriteLine("0 - Выход.");
                        Console.WriteLine("готово - Закончить день.");
                        Console.WriteLine("помощь - Список доступных комманд.");
                        break;

                    default:
                        Console.WriteLine("Неизвестная комманда. Попробуйте ввести 'помощь', что увидеть список доступных комманд.");
                        break;

                }
            }
        }

        private static void DisplayMessage(object sender, HotelEvent e) => Console.WriteLine(e.Message);
    }
}
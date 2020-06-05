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
            Console.WriteLine("������������, ����������, ������� ������, ����� ������ ������: ");
            string password = "";
            for (int i = 0; i < 3; i++)
            {
                password = Console.ReadLine();
                if (password == Constants.Password)
                    break;
                Console.WriteLine("������ ������������. � ��� ��� �������� �������: {0}", 2 - i);
            }
            if (password != Constants.Password)
                return;
            Console.Clear();
            Console.WriteLine("����� ����������, ��������!");
            DateTime time = new DateTime(2020, 06, 05);
            while (true)
            {
                Console.WriteLine("������� {0:D}", time);
                Console.WriteLine("��� �� ������ �������?");
                switch (Console.ReadLine())
                {
                    case "0": return;

                    case "1":
                        Console.WriteLine("����������, ������� ������� � ��� �������:");
                        string name = Console.ReadLine();
                        Console.WriteLine("����� ������� ��� �������:");
                        try
                        {
                            Tourist tourist = new Tourist(name, Convert.ToInt32(Console.ReadLine()));
                            tourist.Notify += DisplayMessage;
                            string category;
                            int[] rooms;
                            while (true)
                            {
                                Console.WriteLine("����� ����� ��������� ����� �������������?");
                                category = Console.ReadLine();
                                if (category == "��������")
                                {
                                    rooms = Constants.StandartRooms;
                                    break;
                                }
                                else if (category == "��������")
                                {
                                    rooms = Constants.HalfLuxRooms;
                                    break;
                                }
                                else if (category == "����")
                                {
                                    rooms = Constants.LuxRooms;
                                    break;
                                }
                                else
                                    Console.WriteLine("��������� ������ ������� �����������. � ����� ���� ������ ��������� ����, �������� � ��������.");
                            }
                            Console.WriteLine("�� ������ ����� ����� ������������� �����? ������� ��� ����� ����� ������ � ������� '�� ��':");
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
                                    Console.WriteLine("������� ������������ ��������. ���������� ��� ���.");
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
                                Console.WriteLine("� ���������, ������ � ����� ��� ������� ������ ���������, ������� ����� �������������.");
                        }
                        catch (HotelException ex)
                        {
                            Console.WriteLine("������: " + ex.Message + "\n");
                            continue;
                        }
                        break;

                    case "2":
                        Console.WriteLine("����������, ������� ������� � ��� �������:");
                        string name1 = Console.ReadLine();
                        try
                        {
                            Tourist tourist = null;
                            int[] rooms;
                            foreach (KeyValuePair<int, Tourist> Pair in Tourists.WhoBooked)
                            {
                                if (Pair.Value.name == name1)
                                {
                                    Console.WriteLine("� ��� ������������ ����� �{0}.", Pair.Key);
                                    tourist = Pair.Value;
                                    Console.WriteLine("�� ������� ���� ����� ����� �����?");
                                    int days2 = Convert.ToInt32(Console.ReadLine());
                                    DateTime date1 = time.AddDays(days2);
                                    int topay1 = days2 * hotel[Pair.Key].price;
                                    Console.WriteLine("� ������: {0}.", topay1);
                                    int paid1;
                                    while (true)
                                    {
                                        paid1 = Convert.ToInt32(Console.ReadLine());
                                        if (paid1 < topay1)
                                            Console.WriteLine("������������ �������. � ������: {0}.", topay1);
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
                                Console.WriteLine("����� ������� ��� �������:");
                                tourist = new Tourist(name1, Convert.ToInt32(Console.ReadLine()));
                                tourist.Notify += DisplayMessage;
                                string category;
                                while (true)
                                {
                                    Console.WriteLine("����� ����� ��������� ����� �����?");
                                    category = Console.ReadLine();
                                    if (category == "��������")
                                    {
                                        rooms = Constants.StandartRooms;
                                        break;
                                    }
                                    else if (category == "��������")
                                    {
                                        rooms = Constants.HalfLuxRooms;
                                        break;
                                    }
                                    else if (category == "����")
                                    {
                                        rooms = Constants.LuxRooms;
                                        break;
                                    }
                                    else
                                        Console.WriteLine("��������� ������ ������� �����������. � ����� ���� ������ ��������� ����, �������� � ��������.");
                                }
                                Console.WriteLine("�� ������� ���� ����� ����� �����?");
                                int days1 = Convert.ToInt32(Console.ReadLine());
                                DateTime date = time.AddDays(days1);
                                int topay = days1 * hotel[rooms[0]].price;
                                Console.WriteLine("� ������: {0}.", topay);
                                int paid;
                                while (true)
                                {
                                    paid = Convert.ToInt32(Console.ReadLine());
                                    if (paid < topay)
                                        Console.WriteLine("������������ �������. � ������: {0}.", topay);
                                    else
                                        break;
                                }
                                if (paid > topay)
                                    Console.WriteLine($"����������: �������� �� {days1} ����� ����. ��������� �������, ������ {paid - topay}.\n");
                                foreach (int r in rooms)
                                    if (tourist.Lease(days1, hotel[r], date))
                                    {
                                        Tourists.WhoLeased.Add(r, tourist);
                                        break;
                                    }
                                if (tourist.roomnumber == -1)
                                    Console.WriteLine("� ���������, ������ � ����� ��� ��������� ������� ������ ���������.");
                            }
                        }
                        catch (HotelException ex)
                        {
                            Console.WriteLine("������: " + ex.Message + "\n");
                            continue;
                        }
                        break;

                    case "3":
                        Console.WriteLine("� ����� ������ �� ������ �������� ����������?");
                        int n = Convert.ToInt32(Console.ReadLine());
                        hotel[n - 1].Info();
                        break;

                    case "������":
                        time = time.AddDays(1);
                        foreach (Room r in hotel)
                        {
                            r.daysofbooking--;
                            r.daysofleasing--;
                        }
                        break;

                    case "������":
                        Console.WriteLine("������ ��������� �������:");
                        Console.WriteLine("1 - ������������� �����.");
                        Console.WriteLine("2 - ����� �����.");
                        Console.WriteLine("3 - �������� ���������� � ������.");
                        Console.WriteLine("0 - �����.");
                        Console.WriteLine("������ - ��������� ����.");
                        Console.WriteLine("������ - ������ ��������� �������.");
                        break;

                    default:
                        Console.WriteLine("����������� ��������. ���������� ������ '������', ��� ������� ������ ��������� �������.");
                        break;

                }
            }
        }

        private static void DisplayMessage(object sender, HotelEvent e) => Console.WriteLine(e.Message);
    }
}
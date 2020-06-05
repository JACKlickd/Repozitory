using System;

namespace Hotels
{
    public class Room
    {
        internal int number;
        public int price, daysofleasing = 0, daysofbooking = 0;

        internal Room(int number, string category)
        {
            this.number = number;
            if (category == "Люкс")
                this.price = 1100;
            else if (category == "Полулюкс")
                this.price = 900;
            else
                this.price = 500;
        }

        private bool IsBooked()
        {
            return daysofbooking > 0;
        }

        private bool IsLeased()
        {
            return daysofleasing > 0;
        }

        internal void Book(int days)
        {
            if (IsBooked())
                throw new HotelException("Номер забронирован.");
            else if (IsLeased() && daysofleasing > days)
                throw new HotelException("Номер занят.");
            daysofbooking = days;
        }

        internal void Lease(int days)
        {
            if (IsLeased())
                throw new HotelException("Номер занят.");
            else if (IsBooked() && days > daysofbooking)
                throw new HotelException("Номер забронирован.");
            daysofleasing = days;
        }

        public void Info()
        {
            Console.WriteLine("Номер №{0}.", number);
            if (price == 1100)
                Console.WriteLine($"Категория: Люкс.\nЦена: {price}. ");
            else if (price == 900)
                Console.WriteLine($"Категория: Полулюкс.\nЦена: {price}. ");
            else
                Console.WriteLine($"Категория: Стандарт.\nЦена: {price}. ");
            if (IsLeased())
            {
                Console.Write($"Номер будет сдаваться человеку по имени {Tourists.WhoLeased[number].name} ещё на протяжении {daysofleasing} ");
                if (daysofleasing % 10 == 1)
                    Console.WriteLine("дня.");
                else
                    Console.WriteLine("дней.");
            }
            if (IsBooked())
            {
                Console.Write($"Номер будет забронирован ещё на протяжении {daysofbooking} ");
                if (daysofbooking % 10 == 1)
                    Console.WriteLine("дня на имя {0}.", Tourists.WhoBooked[number].name);
                else
                    Console.WriteLine("дней на имя {0}.", Tourists.WhoBooked[number].name);
            }
            Console.WriteLine();
        }
    }
}

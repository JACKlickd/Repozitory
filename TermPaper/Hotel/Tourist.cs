using System;

namespace Hotels
{
    public class Tourist
    {
        public delegate void EventHandler(object sender, HotelEvent e);
        public event EventHandler Notify;

        public string name;
        private int age;
        public int roomnumber = -1;

        public Tourist(string name, int age)
        {
            if (age < 18)
                throw new HotelException("Отель не предоставляет услуги лицам младше 18 лет.");
            this.name = name;
            this.age = age;
        }

        public bool Book(int days, Room room, DateTime date)
        {
            try
            {
                room.Book(days);
                roomnumber = room.number;
                Notify?.Invoke(this, new HotelEvent($"Номер №{roomnumber + 1} забронирован на имя {name} до {date:D}\n"));
                return true;
            }
            catch(HotelException)
            {
                return false;
            }
        }

        public bool Lease(int days, Room room, DateTime date)
        {
            try
            {
                room.Lease(days);
                roomnumber = room.number;
                Notify?.Invoke(this, new HotelEvent($"Номер №{roomnumber + 1} сдаётся человеку по имени {name} до {date:D}\n"));
                return true;
            }
            catch (HotelException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message + "\n");
                return false;
            }
        }
    }
}

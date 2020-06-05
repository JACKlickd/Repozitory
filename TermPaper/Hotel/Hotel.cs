using System;
using System.Collections;

namespace Hotels
{
    public class Hotel : IEnumerable
    {

        private Room[] hotel = new Room[Constants.RoomsAmount];

        public Hotel(int RoomsAmount)
        {
            foreach (int i in Constants.StandartRooms)
                hotel[i] = new Room(i, "Стандарт");
            foreach (int i in Constants.HalfLuxRooms)
                hotel[i] = new Room(i, "Полулюкс");
            foreach (int i in Constants.LuxRooms)
                hotel[i] = new Room(i, "Люкс");
        }

        public Room this[int index]
        {
            get
            {
                if (index < 0 || index > hotel.GetUpperBound(0))
                    throw new IndexOutOfRangeException();
                return hotel[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return hotel.GetEnumerator();
        }
    }
}

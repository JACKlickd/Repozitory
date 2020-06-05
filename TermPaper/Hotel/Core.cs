using System;
using System.Collections.Generic;

namespace Hotels
{
    public class Constants
    {
        public static readonly string Password = "admin";
        public static readonly int RoomsAmount = 15;
        public static readonly int[] StandartRooms = { 0, 1, 2, 3, 4, 5, 6 };
        public static readonly int[] HalfLuxRooms = { 7, 8, 9, 10, 11 };
        public static readonly int[] LuxRooms = { 12, 13, 14 };
    }

    public class Tourists
    {
        public static Dictionary<int, Tourist> WhoBooked = new Dictionary<int, Tourist>(Constants.RoomsAmount);
        public static Dictionary<int, Tourist> WhoLeased = new Dictionary<int, Tourist>(Constants.RoomsAmount);
    }

    public class HotelException : Exception
    {
        internal HotelException(string message)
            : base(message)
        { }
    }

    public class HotelEvent
    {
        public string Message { get; }

        public HotelEvent(string mes)
        {
            Message = mes;
        }
    }
}

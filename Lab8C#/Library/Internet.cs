using System;

namespace Library
{
    public class Internet
    {
        public delegate void TrafficExcess(string message);
        public event TrafficExcess Notify;

        byte t;
        bool access = false;
        int sum = 0, trafficnorm;

        public Internet()
        {
            Console.WriteLine("Choose your tariff model: press '1', if you want tariff 'Standart' or press '2', if you want tariff 'VIP':");
            while (t != 1 && t != 2)
            {
                try
                {
                    try
                    {
                        t = Convert.ToByte(Console.ReadLine());
                        if (t == 1)
                            trafficnorm = t;
                        else if (t == 2)
                            trafficnorm = t;
                        else
                            throw new InternetException("Wrong number. Try again.");
                    }
                    catch (InternetException ie)
                    {
                        Console.WriteLine(ie.Message);
                    }
                    catch (Exception)
                    {
                        throw new InternetException("Wrong number. Try again.");
                    }
                }
                catch (InternetException ie)
                {
                    Console.WriteLine(ie.Message);
                }
            }
            Notify += DisplayMessage;
        }

        public void GetAccess()
        {
            access = true;
        }

        public void Refill(int sum)
        {
            try
            {
                if (access)
                {
                    this.sum += sum;
                    Notify?.Invoke($"The account is refilled by {sum}.");
                }
                else
                    throw new InternetException("Access denied.");
            }
            catch(InternetException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        public void Traffic(int traffic)
        {
            if (traffic >= sum * trafficnorm)
                Notify?.Invoke("Traffic excessed.");
            else
                Notify?.Invoke("Traffic not excessed.");
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    class InternetException : Exception
    {
        public InternetException(string message)
            : base(message)
        { }
    }
}

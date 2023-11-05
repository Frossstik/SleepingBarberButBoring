using System.Runtime.CompilerServices;

namespace SleepingBarberButBoring
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BarberShop barberShop = new BarberShop();
            Random rand = new Random();
            //Thread barber = new Thread(barberShop.WorkingProcess);
            //barber.Start();
            Console.WriteLine("Парикхмахер спит!");
            while (true)
            {
                Thread.Sleep(rand.Next(500, 5000));
                Thread thread = new Thread(barberShop.AddClient);
                thread.Start();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingBarberButBoring
{
    public class BarberShop
    {
        //Флаф

        Random random = new Random();

        Mutex mutex = new Mutex();

        Semaphore barberChair = new Semaphore(1, 1);

        //Объекты

        List<Client> clients = new List<Client>();

        Barber barber = new Barber();

        public int maxChairs { get; set; } = 3;

        //Методы

        public void AddClient()
        {
            barberChair.WaitOne();
            Client client = new Client();
            clients.Add(client);
            Console.WriteLine($"Клиент {client.id} пришел!");
            if (clients.Count > maxChairs)
            {
                Console.WriteLine($"Увидев, что свободные места отсутствуют, клиент {client.id} уходит!");
                clients.Remove(client);
            }
            if (barber.isWorking == false)
            {
                barber.isWorking = true;
                Thread workingBarber = new Thread(WorkingProcess);
                workingBarber.Start();
            }

            barberChair.Release();
        }

        private void WorkingProcess()
        {
            mutex.WaitOne();
            while (clients.Count > 0)
            {
                int tempId = clients.First().id;
                Console.WriteLine($"Клиент {tempId} стрижется!");
                clients.Remove(clients.First());
                Thread.Sleep(random.Next(1000, 3000));
                Console.WriteLine($"Клиент {tempId} подстригся и ушел довольный!");
                barber.isWorking = false;
            }
            Console.WriteLine("Парикхмахер спит!");
            mutex.ReleaseMutex();
        }
    }
}

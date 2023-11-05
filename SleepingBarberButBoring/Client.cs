using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingBarberButBoring
{
    public class Client
    {
        public Client()
        {
            idCount++;
            this.id = idCount;
        }

        private static int idCount = 0;

        public int id { get; private set; }
    }
}

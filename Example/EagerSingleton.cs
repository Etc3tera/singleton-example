using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public sealed class EagerSingleton
    {
        private int counter = 0;
        private static EagerSingleton instance = new EagerSingleton();

        private EagerSingleton() { }
        public static EagerSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void Add()
        {
            counter++;
        }

        public int Hora()
        {
            return counter;
        }
    }
}

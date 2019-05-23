using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public sealed class LazySingleton
    {
        private int counter = 0;
        public static int InitCounter = 0;
        private static LazySingleton instance;

        private LazySingleton()
        {
            InitCounter++;
        }

        public static LazySingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new LazySingleton();
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

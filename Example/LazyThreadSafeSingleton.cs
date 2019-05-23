using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public sealed class LazyThreadSafeSingleton
    {
        private int counter = 0;
        public static int InitCounter = 0;
        private static Lazy<LazyThreadSafeSingleton> instance = new Lazy<LazyThreadSafeSingleton>(() => new LazyThreadSafeSingleton());

        private LazyThreadSafeSingleton()
        {
            InitCounter++;
        }

        public static LazyThreadSafeSingleton Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public void Add()
        {
            instance.Value.counter++;
        }

        public int Hora()
        {
            return instance.Value.counter;
        }
    }
}

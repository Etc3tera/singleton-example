using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex.1
            EagerSingleton.Instance.Add();
            Console.WriteLine($"value = {EagerSingleton.Instance.Hora()}");

            // Ex.2
            LazySingleton.Instance.Add();
            LazySingleton.Instance.Add();
            Console.WriteLine($"value = {LazySingleton.Instance.Hora()}");

            // Ex.3
            LazyThreadSafeSingleton.Instance.Add();
            LazyThreadSafeSingleton.Instance.Add();
            Console.WriteLine($"value = {LazyThreadSafeSingleton.Instance.Hora()}");
        }
    }
}

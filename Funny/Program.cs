using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = new FunnyRepository().GetSmallestOne();
            Console.WriteLine(JsonConvert.SerializeObject(post));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryChop
{
    class Program
    {
        static void Main(string[] args)
        {

            var algorithm1 = new BinaryChopAlgorithm1();
            int result = algorithm1.Chop(1, new[] { 1, 2, 3, 4, 5, 6, 7});

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

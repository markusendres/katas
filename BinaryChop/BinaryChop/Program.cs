﻿using System;
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
            int result = algorithm1.FindPositionOfValueInSortedNumberArray(6, new[] { 1, 2, 5, 6, 7, 8, 9}) - 1;
            int result2 = Array.IndexOf(new int[] {1, 2, 5, 6, 7, 8, 9 }, 6);

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadLine();
        }
    }
}

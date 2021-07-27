using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomList<int> list = new CustomList<int>();

            list.Add(5);
            list.Add(6);
            list.Add(7);

            list.Remove(5);

            list.Remove(7);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }

       
}

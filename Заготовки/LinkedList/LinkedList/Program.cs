using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LList<double> list = new LList<double>();

            list.Push(-11.5);
            list.Enqueue(1);
            list.Enqueue(5);
            list.Enqueue(-2);
            list.Push(55.8);
            list.Enqueue(0);
            list.Enqueue(10);
            list.Push(12);

            Console.WriteLine(list.ToString());
        }
    }
}

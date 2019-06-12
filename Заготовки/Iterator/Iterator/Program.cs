using System;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksCollection books = new BooksCollection();

            books.AddBook("Гарри Поттер");
            books.AddBook("Собачье сердце");
            books.AddBook("Война и Мир");

            var enumerator = books.GetEnumerator();

            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MovePrev();
            Console.WriteLine(enumerator.Current);
        }
    }
}

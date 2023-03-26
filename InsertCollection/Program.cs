using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace InsertCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            const double ITERATION = 100;

            string text = File.ReadAllText("Text1.txt");

            var words = text.Split(' ');

            var listCount = InsertOnCollection(words, ITERATION, true);
            var linkedListCount = InsertOnCollection(words, ITERATION, false);

            Console.WriteLine($"Среднее время добавления объектов в List за {ITERATION} попыток = {listCount}");
            Console.WriteLine($"Среднее время добавления объектов в LinkedList за {ITERATION} попыток = {linkedListCount}");
        }

        static double InsertOnCollection(string[] stringArray, double iteration, bool isList)
        {
            List<string> wordsList = new List<string>();
            LinkedList<string> wordsLinkedList = new LinkedList<string>();

            long time = 0;

            Stopwatch stopwatch = new Stopwatch();

            var count = 0;

            while (count != iteration)
            {
                wordsList.Clear();
                wordsLinkedList.Clear();

                stopwatch.Reset();
                stopwatch.Start();

                foreach (var item in stringArray)
                {
                    if (isList)
                    {
                        wordsList.Add(item);
                    }
                    else
                    {
                        wordsLinkedList.AddFirst(item);
                    }   
                }

                stopwatch.Stop();

                count += 1;
                time += stopwatch.ElapsedMilliseconds;
            }

            return time / iteration;
        }
    }
}

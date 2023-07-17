using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Claims;

namespace Task2
{
    internal class Program
    {
        static object locker = new object();
        static void PrintLine(object left)
        {
            Random rand = new Random();

            int consoleTop = 0;
            int consoleLeft = (int)left;
            int lettersLenght = rand.Next(1, 10);

            string setOfSymbols = "abcdefghigklmnopqrstuvwxyz";
            string[] letters = new string[lettersLenght];

            ConsoleColor color = ConsoleColor.Gray;
            

            while (true)
            {
                for (int y = 0; y < lettersLenght; y++)
                {
                    letters[y] = setOfSymbols[rand.Next(setOfSymbols.Length)].ToString();
                }

                if (consoleTop >= lettersLenght)
                {
                    if (consoleTop >= Console.WindowHeight + lettersLenght)
                        PrintLetter(consoleLeft, consoleTop - consoleTop, " ", color);

                    else
                        PrintLetter(consoleLeft, consoleTop - lettersLenght, " ", color);

                    consoleTop = (consoleTop - lettersLenght) + 1;
                }

                for (int j = 0; j < lettersLenght; j++)
                {
                    color = GetColor(j, lettersLenght);

                    if (consoleTop >= Console.WindowHeight + lettersLenght)
                    {
                        consoleTop = lettersLenght;
                    }

                    if (consoleTop >= Console.WindowHeight)
                    {
                        PrintLetter(consoleLeft, consoleTop++ - Console.WindowHeight, letters[j], color);
                        continue;
                    }
                    PrintLetter(consoleLeft, consoleTop, letters[j], color);
                    consoleTop++;
                }

                Thread.Sleep(100);
            }
        }

        static ConsoleColor GetColor(int letterNumber, int lettersLenght)
        {
            ConsoleColor color;

            if (letterNumber == lettersLenght - 1)
                return color = ConsoleColor.White;

            else if (letterNumber == lettersLenght - 2 )
                return color = ConsoleColor.Green;

            else
                return color = ConsoleColor.DarkGreen;
        }
        static void PrintLetter(int curSorLeft, int cursorTop, string letter, ConsoleColor color)
        {
            lock (locker)
            {
                Console.SetCursorPosition(curSorLeft, cursorTop);
                Console.ForegroundColor = color;
                Console.WriteLine(letter);
            }
        }
        static void Main(string[] args)
        {
            List<Thread> threadList = new List<Thread>();
            Random rand = new Random();
            //for(int i = 0; i < 1; i++)
            for (int i = 0; i < 50; i++)
            {
                threadList.Add(new Thread(PrintLine));
            }
            int a = Console.WindowWidth;
            for (int i = 0; i < threadList.Count; i++)
            {
                threadList[i].Start(rand.Next(Console.WindowWidth));
            }
            Thread.Sleep(1000);
        }
    }
}
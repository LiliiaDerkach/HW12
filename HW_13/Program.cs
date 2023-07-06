// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

namespace HW_13
{
    internal class Program
    {
        static object locker = new object();

        static void Stroka()
        {
            //lock (locker)
            //{
            Random random = new Random();
            string letters = "abcdefghigklmnopqrstuvwxyz";
            int lengthOfLine = 0;
            int widthOfWindow = Console.WindowWidth;
            int heightOfWindow = Console.WindowHeight;
            int numberOfColoumn = random.Next(0, widthOfWindow);
            lengthOfLine = random.Next(0, 10);
            string line = null;
            int numberOfLine = 0;

            //for (int i = 0; i < lengthOfLine; i++)
            //{
            //    line += letters[random.Next(letters.Length)].ToString();
            //    Console.WriteLine(line);
            //    Thread.Sleep(1000);
            //}
            for (int i = 0; i < heightOfWindow; i++)
            {
                Console.Clear();
                if (i < lengthOfLine)
                {
                    line = null;
                    for (int a = 0; a < i; a++)
                    {
                        Console.SetCursorPosition(numberOfColoumn, a);
                        line += letters[random.Next(letters.Length)].ToString();
                        Console.WriteLine(line);
                        Thread.Sleep(500);
                    }
                }
                if (i >= lengthOfLine)
                {
                    line = null;
                    for (int a = 0; a < lengthOfLine; a++)
                    {
                        if (numberOfLine < heightOfWindow)
                        {
                            Console.SetCursorPosition(numberOfColoumn, numberOfLine);
                            numberOfLine += 1;
                            line += letters[random.Next(letters.Length)].ToString();
                            Console.WriteLine(line);
                            Thread.Sleep(500);
                        }
                    }
                }

            }

            //for (int i = 0; i < heightOfWindow; i++)
            //{
            //    Console.Clear();
            //    Console.SetCursorPosition(numberOfColoumn, i);
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine(letters[random.Next(letters.Length)]);
            //    Console.SetCursorPosition(numberOfColoumn, i + 1);
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.WriteLine(letters[random.Next(letters.Length)]);
            //    Console.SetCursorPosition(numberOfColoumn, i + 2);
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine(letters[random.Next(letters.Length)]);
            //    Console.SetCursorPosition(numberOfColoumn, i + 3);
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.WriteLine(letters[random.Next(letters.Length)]);
            //    Thread.Sleep(1000);
            //}
            //}
        }
        static void Main(string[] args)
        {
            Thread line1 = new Thread(Stroka);
            Thread line2 = new Thread(Stroka);
            Thread line3 = new Thread(Stroka);
            line1.Start();
            //line2.Start();
            //line3.Start();

            Console.ReadKey();
        }
    }
}
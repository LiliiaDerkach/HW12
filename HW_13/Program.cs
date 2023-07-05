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
            int numberOfLine = random.Next(0, widthOfWindow);
            lengthOfLine = random.Next(0, 10);
            string line = null;

            //for (int i = 0; i < lengthOfLine; i++)
            //{
            //    Console.SetCursorPosition(numberOfLine, i);
            //    Console.ForegroundColor = ConsoleColor.DarkGreen;
            //    if (i == lengthOfLine - 1)
            //        Console.ForegroundColor = ConsoleColor.White;
            //    if (i == lengthOfLine - 2)
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //    line = letters[random.Next(letters.Length)].ToString();
            //    Console.WriteLine(line);
            //    Thread.Sleep(1000);
            //}
            for (int i = 0; i < heightOfWindow; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(numberOfLine, i);
                Console.WriteLine("o");
                Thread.Sleep(1000);
            }
            //}
        }
        static void Main(string[] args)
        {
            Thread line1 = new Thread(Stroka);
            Thread line2 = new Thread(Stroka);
            Thread line3 = new Thread(Stroka);
            line1.Start();

            Console.ReadKey();
        }
    }
}
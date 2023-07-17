// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

namespace HW_13
{
    internal class Program
    {
        static object locker = new object();

        static void Stroka()
        {

            Random random = new Random();
            string letters = "abcdefghigklmnopqrstuvwxyz";
            int widthOfWindow = Console.WindowWidth;
            int heightOfWindow = Console.WindowHeight;
            int numberOfColoumn = random.Next(0, widthOfWindow);
            int lengthOfLine = random.Next(10, 20);
            string line;
            int numberOfLine;
            int counter = 0;
            object locker = new object();
            lock (locker)
            {
                for (int i = 0; i < heightOfWindow; i++)
                {

                    Console.Clear();
                    line = null;
                    if (i < lengthOfLine)
                    {
                        for (int a = 0; a <= i; a++)
                        {
                            if (a == i)
                                Console.ForegroundColor = ConsoleColor.White;
                            else if (a == i - 1)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else
                                Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(numberOfColoumn, a);
                            line = letters[random.Next(letters.Length)].ToString();
                            Console.WriteLine(line);
                            Thread.Sleep(100);
                        }
                    }

                    if (i >= lengthOfLine)
                    {

                        numberOfLine = counter;
                        counter += 1;
                        line = null;
                        for (int a = 0; a <= lengthOfLine; a++)
                        {
                            if (numberOfLine < heightOfWindow)
                            {

                                if (a == lengthOfLine)
                                    Console.ForegroundColor = ConsoleColor.White;
                                else if (a == lengthOfLine - 1)
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                else
                                    Console.ForegroundColor = ConsoleColor.Green;

                                Console.SetCursorPosition(numberOfColoumn, numberOfLine);
                                line = letters[random.Next(letters.Length)].ToString();
                                Console.WriteLine(line);
                                Thread.Sleep(100);
                                numberOfLine += 1;
                            }
                        }
                    }
                }
            }
            Console.Clear();
        }


        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);
            for (int i = 0; i < 3; i++)
            {
                new Thread(Stroka).Start();
            }
            Console.ReadLine();
        }
    }
}
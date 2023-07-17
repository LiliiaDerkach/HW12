using System.Diagnostics.Metrics;

namespace ThreadsMatrix
{
    internal class Program
    {
        private const int CONSOLE_HEIGHT = 1080;
        private const int CONSOLE_WIDTH = 1920;


        private static object lockObj = new object();
        static void Main(string[] args)
        {
            var threadList = new List<Thread>(Console.WindowWidth);

            //Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGHT);

            //for (int i = 0; i < 1; i++)
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                threadList.Add(new Thread(PrintChain));
            }

            var columnNumber = 0;
            foreach (var thread in threadList)
            {
                thread.Start(columnNumber++);
            }
        }

        private static void PrintChain(object? obj)
        {
            var columnNumber = (int)obj;
            var chain = "qwerty".ToCharArray();
            var consoleTop = 0;

            while (true)
            {
                if (consoleTop >= chain.Length)
                {
                    if (consoleTop == Console.WindowHeight + chain.Length)
                        PrintLetter(columnNumber, consoleTop - consoleTop, ' ');

                    else
                        PrintLetter(columnNumber, consoleTop - chain.Length, ' ');

                    consoleTop = consoleTop - chain.Length + 1;
                }

                foreach (var letter in chain)
                {

                    if (consoleTop >= Console.WindowHeight + chain.Length)
                    {
                        consoleTop = chain.Length;
                    }

                    if (consoleTop >= Console.WindowHeight)
                    {
                        PrintLetter(columnNumber, consoleTop++ - Console.WindowHeight, letter);
                        continue;
                    }

                    PrintLetter(columnNumber, consoleTop++, letter);
                }

                Thread.Sleep(100);
            }
        }

        private static void PrintLetter(int cursorLeft, int cursorTop, char letter)
        {
            lock (lockObj)
            {
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write(letter);
            }
        }
    }
}
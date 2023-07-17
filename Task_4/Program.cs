namespace Task_4
{
    internal class Program
    {

        static void Recursion()
        {
            Thread thread = new Thread(Recursion);
            Console.WriteLine(thread.GetHashCode());
            thread.Start();
        }
        static void Main(string[] args)
        {

            Thread thread = new Thread(Recursion);
            thread.Start();

            Console.ReadLine();

        }
    }
}
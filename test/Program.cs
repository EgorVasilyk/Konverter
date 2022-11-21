



using Newtonsoft.Json;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Указать путь: ");
            Figure read = new Figure();
            read.Read();
        }
    }
}
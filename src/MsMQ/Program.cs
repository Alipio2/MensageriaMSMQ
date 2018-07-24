using System;
using MsMQ.Queue;

namespace MsMQ
{
    class Program
    {
        private static EmailQueue EmailQueue { get; set; }

        static void Main(string[] args)
        {
            EmailQueue = new EmailQueue();
            Addfila();
            Console.ReadLine();
            Processar();
        }

        public static void Addfila()
        {
            EmailQueue.Add(new User() { Name = "Alipio Ferro", Email = "alipioTeste@gmail.com" });
        }

        public static void Processar()
        {
            EmailQueue.Process();
        }
    }
}

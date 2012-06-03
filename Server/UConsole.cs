using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class UConsole
    {
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        public static int GetInt(string question)
        {
            Console.WriteLine(question);
            int i = 0;
            while (!int.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Input invalid. Please try again");
                Console.WriteLine(question);
            }
            return i;
        }
        public static bool GetBool(string question)
        {
            Console.WriteLine(question + " (y/n)");
            while (true) {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Y)
                { return true; }
                if (i.Key == ConsoleKey.N)
                { return false; }
            }
        }
        public static void Log(string output)
        {
            Console.WriteLine("<" + DateTime.Now.ToString() + "> " + output);
        }
        public static void Log(string output, object obj1)
        {
            Console.WriteLine("<" + DateTime.Now.ToString() + "> " + output.Replace("{0}", obj1.ToString()));
        }
        public static void Log(string output, object obj1, object obj2)
        {
            Console.WriteLine("<" + DateTime.Now.ToString() + "> " + output.Replace("{0}", obj1.ToString()).Replace("{1}", obj2.ToString()));
        }
        public static void Log(string output, object obj1, object obj2, object obj3)
        {
            Console.WriteLine("<" + DateTime.Now.ToString() + "> " + output.Replace("{0}", obj1.ToString()).Replace("{1}", obj2.ToString()).Replace("{2}", obj3.ToString()));
        }
    }
}

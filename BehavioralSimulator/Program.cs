using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BehavioralSimulator
{
    class Program
    {
        List<Instruction> instructions = new List<Instruction>();
        static void Main(string[] args)
        {
            Input(args);
            Process();
            Output();
        }

        private static void Output()
        {
            
        }

        private static void Process()
        {
            
        }

        private static void Input(string[] args)
        {
            string[] textsFromFile = ReadFromFile(args);
            foreach (string text in textsFromFile)
            {
                SplitText(DecToBin(text));
                Console.WriteLine(DecToBin(text));
            }
        }

        private static string DecToBin(string text)
        {
            int value = Int32.Parse(text);
            if (value >= 0)
            {
                string result = Convert.ToString(value, 2).PadLeft(25, '0');
                return result;
            }
            else
            {
                string result = Convert.ToString(value, 2);
                result = result.Substring(Math.Max(result.Length - 25, 0)).PadLeft(25, '0');
                return result;
            }
        }
        

        private static void SplitText(string text)
        {
            
        }

        private static string[] ReadFromFile(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@args[0]);
            //TextReader input = Console.In;
            //if (args.Any())
            //{
            //    var path = args[0];
            //    if (File.Exists(path))
            //    {
            //        input = File.OpenText(path);

            //    }
            //    for (string line; (line = input.ReadLine()) != null;)
            //    {
            //        SplitText(line);
            //    }
            //}
            return lines;
            
        }
    }
}

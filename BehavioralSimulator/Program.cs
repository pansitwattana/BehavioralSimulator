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
        public static List<Instruction> instructions = new List<Instruction>();
        public static List<int> register = new List<int>();
        public static int counter = 0;
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
            for (int i = 0; i < register.Count; i++)
            {
                register[i] = 0;
            }

            while (instructions[counter].isNotHalt())
            {
                instructions[counter].Execute();
            }
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
            string Opcode = text.Substring(0,3);
            string RegA = text.Substring(3, 3);
            string RegB = text.Substring(6, 3);
            string Empty = text.Substring(9, 13);
            string RegDest = text.Substring(22, 3);
            instructions.Add(new Instruction(Opcode, RegA, RegB, Empty, RegDest));
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

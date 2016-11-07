using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralSimulator
{
    class Program
    {
        public static List<Instruction> instructions = new List<Instruction>();
        public static List<int> register = new List<int>();
        public static int counter = 0;
        static void Main(string[] args)
        {
            Input();
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

        private static void Input()
        {
            string[] textsFromFile = ReadFromFile();
            foreach (string text in textsFromFile)
            {
                SplitText(DecToBin(text));
            }
        }

        private static string DecToBin(string text)
        {
            throw new NotImplementedException();
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

        private static string[] ReadFromFile()
        {
            string[] textFromFile = new string[2] { "8454151", "9043971" };
            return textFromFile;
        }
    }
}

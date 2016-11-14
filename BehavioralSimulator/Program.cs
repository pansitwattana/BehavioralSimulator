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

        private static int counter;

        public static int Counter
        {
            get { return counter; }
            set
            {
                if(value >= 0)
                    counter = value;
                Console.WriteLine("Error address is less than zero");
            }
        }


        static void Main(string[] args)
        {
            Input(args);
            Process();
        }
        
        private static void Process()
        {
            Counter = 0;
            Register.Current.Initial();
            Register.Current.Print();

            while (instructions[Counter].isNotHalt())
            {
                instructions[Counter].Execute();
                Register.Current.Print();
            }
        }

        private static void Input(string[] args)
        {
            string[] textsFromFile = ReadFromFile(args);
            int count = 0;
            foreach (string text in textsFromFile)
            {
                count++;
                SplitText(DecToBin(text));
                Console.WriteLine(DecToBin(text));
                if (text == Instruction.HALTFULL)
                    break;
            }

            for (int i = count; i < textsFromFile.Length; i++)
            {
                int value = BinToDec(textsFromFile[i]);
            }
            
        }

        private static int BinToDec(string text)
        {
            string dec = Convert.ToInt32(text, 2).ToString();
            int value = Int32.Parse(dec);
            return value;
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
            return lines;   
        }

        public static void End(int exitCode)
        {
            //search how to exd program while run
        }
    }
}

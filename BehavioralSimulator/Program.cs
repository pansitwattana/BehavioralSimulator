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

        public static List<int> memory = new List<int>();

        public static int instuctionTotal = 0;

        private static int counter;

        public static int Counter
        {
            get { return counter; }
            set
            {
                if(value >= 0 && value <= instructions.Count)
                    counter = value;
                else
                {
                    Console.WriteLine("Error address is not in range(0-"+instructions.Count+")");
                    Environment.Exit(1);
                }
                    
            }
        }

        public static void SetMemory(int addr, int value)
        {
            if(addr >= memory.Count)
            {
                int arrcount = memory.Count;
                for (int i = 0; i <= addr - arrcount; i++)
                {
                    memory.Add(0);
                }
            }
            memory[addr] = value;
        }

        public static int GetMemory(int addr)
        {
            return memory[addr];
        }

        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("error: usage");
                Environment.Exit(1);
            }
            if(args == null)
            {
                Console.WriteLine("error: can't open file");
                Environment.Exit(1);
            }
            Input(args);
            Process();
        }
        
        private static void Process()
        {
            Counter = 0;
            PrintMemory();
            Register.Current.Initial();
            Register.Current.Print();

            while (GetInstructions(Counter).isNotHalt())
            {
                instructions[Counter].Execute();
                Register.Current.Print();
            }

            Console.WriteLine("machine halted");
            Console.WriteLine("total of " + (instuctionTotal + 1) + " instuctions executed");
            Console.WriteLine("final state of machine");
            Program.counter++;
            Register.Current.Print();
        }

        private static void PrintMemory()
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                Console.WriteLine("memory[" + i + "] = " + BinToDec(instructions[i].InstSet));
            }
            for (int i = instructions.Count; i < memory.Count; i++)
            {
                Console.WriteLine("memory[" + i + "] = " + memory[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static Instruction GetInstructions(int counter)
        {
            if (counter < 0)
            {
                Console.WriteLine("Error branch to invalid address");
                Environment.Exit(1);
            }

            if(counter < instructions.Count)
                return instructions[counter];
            else
            {
                Console.WriteLine("Error branch to invalid address");
                Environment.Exit(1);
                return null;
            }
        }

        private static void Input(string[] args)
        {
            string[] textsFromFile = ReadFromFile(args);
            int count = 0;
            foreach (string text in textsFromFile)
            {
                
                if (int.Parse(text) < 32767)
                    break;
                count++;
                string binaryInput = DecToBin(text);
                SplitText(binaryInput);
                memory.Add(0);
            }

            for (int i = count; i < textsFromFile.Length; i++)
            {
                int value = int.Parse(textsFromFile[i]);
                memory.Add(value);
            }
        }

        public static int BinToDec(string text)
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
            string Opcode = text.Substring(0, 3);
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

        //check overflow
        public static bool CheckInt32(int input)
        {
            if (input > 32767 || input < -32768)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

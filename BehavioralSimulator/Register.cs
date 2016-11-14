using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralSimulator
{
    class Register
    {
        public static Register Current = new Register();
        List<int> registers = new List<int>();

        public int Count()
        {
            return registers.Count;
        }

        public void Set(int address, int value)
        {
            if (address == 0)
            {
                Console.WriteLine("Error you can't set to register 0");
                return;
            }

            if (address > 7)
            {
                Console.WriteLine("Error there are only 8 registers");
                return;
            }

            //maybe check overflow here
            registers[address] = value;
        }

        public int Get(int index)
        {
            return registers[index];
        }

        public void Print()
        {
            Console.WriteLine("PC" + Program.Counter);
            Console.WriteLine("  " + "memory:");
            for (int i = 0; i < Program.instructions.Count; i++)
            {
         
                Console.WriteLine("        " + "mem[" + i + "]" + Program.BinToDec(Program.instructions[i].InstSet));
            }
            //registers[i] instructions[i]
            Console.WriteLine("  "+"registor:");
            for (int i = 0; i < 8; i++)
            {
          
                Console.WriteLine("        "+"reg[" + i + "]" + registers[i]);
            }
        }

        public void Initial()
        {
            for (int i = 0; i < 8; i++)
            {
                registers.Add(0);
            }
        }
    }
}

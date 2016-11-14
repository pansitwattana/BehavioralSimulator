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
            if(address == 0)
            {
                Console.WriteLine("Error you can't set to register 0");
                return;
            }

            if(address > 7)
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

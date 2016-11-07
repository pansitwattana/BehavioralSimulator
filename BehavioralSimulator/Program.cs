using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralSimulator
{
    class Program
    {
        List<Instruction> instructions = new List<Instruction>();
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
            throw new NotImplementedException();
        }

        private static string[] ReadFromFile()
        {
            string[] textFromFile = new string[2] { "8454151", "9043971" };
            return textFromFile;
        }
    }
}

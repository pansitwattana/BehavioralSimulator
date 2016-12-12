using System;

namespace BehavioralSimulator
{
    public class Instruction
    {
        #region Property

        public const string ADD = "000";
        public const string NAND = "001";
        public const string LW = "010";
        public const string SW = "011";
        public const string BEQ = "100";
        public const string JALR = "101";
        public const string HALT = "110";
        public const string NOOP = "111";
        public const string HALTFULL = "1100000000000000000000000";

        private int Jalr_Addr = -10;
        private int Jalr_Count = 0;

        public Instruction(string opcode, string regA, string regB, string offset, string regDest)
        {
            this.field1 = opcode;
            this.field2 = regA;
            this.field3 = regB;
            this.field4 = offset;
            this.field5 = regDest;
        }

        private string field1 { get; set; }
        private string field2 { get; set; }
        private string field3 { get; set; }
        private string field4 { get; set; }
        private string field5 { get; set; }
        public string OpCode
        {
            get
            {
                return field1;
            }
        }

        public int RegA
        {
            get
            {
                return BinToDec(field2);
            }
        }

        public int RegB
        {
            get
            {
                return BinToDec(field3);
            }
        }

        public int DestRsg
        {
            get
            {
                return BinToDec(field5);
            }
        }

        public int OffsetField
        {
            get
            {
                return BinToDecNegative(field4 + field5);
            }
        }

        public string InstSet
        {
            get
            {
                return field1 + field2 + field3 + field4 + field5;
            }
        }
        #endregion

        public void Execute()
        { 
            switch (OpCode)
            {
                case ADD:
                   
                    if(CheckInt32(Register.Current.Get(RegA) + Register.Current.Get(RegB)))
                    {
                        Console.WriteLine("Overflow");
                        Environment.Exit(1);
                    }
                    else
                    {
                        Register.Current.Set(DestRsg, Register.Current.Get(RegA) + Register.Current.Get(RegB));
                    }
                    Program.Counter++;
                    break;
                case NAND:
                    Register.Current.Set(DestRsg, ~(Register.Current.Get(RegA) & Register.Current.Get(RegB)));
                    Program.Counter++;
                    break;
                case LW:
                    Register.Current.Set(RegB, Program.memory[Register.Current.Get(RegA) + OffsetField]);
                    Program.Counter++;
                    break;
                case SW:
                    Program.SetMemory(Register.Current.Get(RegA) + OffsetField, Register.Current.Get(RegB));
                    Program.Counter++;
                    break;
                case BEQ:
                    if (Register.Current.Get(RegA) == Register.Current.Get(RegB))
                    {
                        Program.Counter = Program.Counter + OffsetField + 1;
                    }
                    else
                    {
                        Program.Counter++;
                    }
                    break;
                case JALR:
                    if(Jalr_Addr != Register.Current.Get(RegA))
                    {
                        Jalr_Addr = Register.Current.Get(RegA);
                        Jalr_Count = 0;
                    }else
                    {
                        Jalr_Count++;
                    }

                    if (Jalr_Count >= 150)
                    {

                        Console.WriteLine("infinity Loop");
                        Environment.Exit(1);
                    }

                    int NextLabel = Program.Counter + 1;
                    if(Register.Current.Get(RegA) == Register.Current.Get(RegB))
                    {
                        Register.Current.Set(RegB, NextLabel);
                        Program.Counter = NextLabel;
                    }
                    else
                    {
                        Register.Current.Set(RegB, NextLabel);
                        Program.Counter = Register.Current.Get(RegA);
                    }
                    break;
                case NOOP:
                    Program.Counter ++;
                    break;
            }
            Program.instuctionTotal++;
        }

        public static int BinToDec(string text)
        {
            string dec = Convert.ToInt32(text, 2).ToString();
            int value = Int32.Parse(dec);
            return value;
        }

        public static int BinToDecNegative(string text)
        {
            if (text[0] == '0')
            {
                string dec = Convert.ToInt32(text, 2).ToString();
                int value = Int32.Parse(dec);
                return value;
            }
            else
            {
                string text1 = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '0')
                    {
                        text1 += '1';

                    }
                    else
                    {
                        text1 += '0';
                    }

                }
                string dec = Convert.ToInt32(text1, 2).ToString();
                int value1 = Int32.Parse(dec);
                return -(value1 + 1);


            }

        }
        public bool isNotHalt()
        {
            return InstSet != HALTFULL;
        }

        public override string ToString()
        {
            return InstSet;
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
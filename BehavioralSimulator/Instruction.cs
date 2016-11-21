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
                return BinToDec(field4);
            }
        }

        public int OffsetField
        {
            get
            {
                return BinToDec(field4 + field5);
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
            
            //How to Set:
            //Register.Current.Set(regAddr, value);

            int RegDest = Register.Current.Get(DestRsg);
            int RB = Register.Current.Get(RegB);
            int RA = Register.Current.Get(RegA);
            int OffsetF = Register.Current.Get(OffsetField);
            Program.Counter++;

            switch (OpCode)
            {
                case ADD:
                    Register.Current.Set(RegDest, RA + RB);
                    break;
                case NAND:
                    Register.Current.Set(RegDest, ~(RA & RB));
                    //RegDest = ~(RA & RB);

                    break;
                case LW:
                    //Register.Current.Set(RegDest, value);
                    int value = Program.memory[8];
                    break;
                case SW:
                    //Register.Current.Set(regAddr, value);

                    break;
                case BEQ:
                    if (RA == RB)
                    {
                        Program.Counter = Program.Counter + OffsetF + 1;
                    }

                    break;
                case JALR:

                    break;
                case NOOP:

                    break;
            }
            

        }

        public int BinToDec(string binary)
        {         
            string dec = Convert.ToInt32(binary, 2).ToString();
            int value = Int32.Parse(dec);
            return value;
        }

       
        public bool isNotHalt()
        {
            return InstSet != HALTFULL;
        }
    }
}
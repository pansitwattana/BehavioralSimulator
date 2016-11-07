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

        public string RegA
        {
            get
            {
                return field2;
            }
        }

        public string RegB
        {
            get
            {
                return field3;
            }
        }

        public string DestRsg
        {
            get
            {
                return field4;
            }
        }

        public string OffsetField
        {
            get
            {
                return field4 + field5;
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

                    break;
                case NAND:

                    break;
                case LW:

                    break;
                case SW:

                    break;
                case BEQ:

                    break;
                case JALR:

                    break;
                case NOOP:

                    break;
            }
        }

        public int BinToDec(string binary)
        {
            return 0;
        }

        public bool isNotHalt()
        {
            return InstSet != "1100000000000000000000000";
        }
    }
}
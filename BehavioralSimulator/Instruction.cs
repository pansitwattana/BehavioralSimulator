namespace BehavioralSimulator
{
    public class Instruction
    {
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public string field4 { get; set; }
        public string field5 { get; set; }

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
    }
}
namespace Execution
{
    /// <summary>
    /// Class <c>Registers</c> models the registers set of the SM83 processor.
    /// </summary>
    public class Registers
    {
        private Register _af;
        private Register _bc;
        private Register _de;
        private Register _hl;
        private Register _sp;
        private Register _pc;

        /// <summary>
        /// Property <c>AF</c> is the AF register.
        /// </summary>
        public ushort AF
        {
            get { return _af.Value; }
            set { _af.Value = value; }
        }

        /// <summary>
        /// Property <c>BC</c> is the BC register.
        /// </summary>
        public ushort BC
        {
            get { return _bc.Value; }
            set { _bc.Value = value; }
        }

        /// <summary>
        /// Property <c>DE</c> is the DE register.
        /// </summary>
        public ushort DE
        {
            get { return _de.Value; }
            set { _de.Value = value; }
        }

        /// <summary>
        /// Property <c>HL</c> is the HL register.
        /// </summary>
        public ushort HL
        {
            get { return _hl.Value; }
            set { _hl.Value = value; }
        }

        /// <summary>
        /// Property <c>SP</c> is the SP register.
        /// </summary>
        public ushort SP
        {
            get { return _sp.Value; }
            set { _sp.Value = value; }
        }

        /// <summary>
        /// Property <c>PC</c> is the PC register.
        /// </summary>
        public ushort PC
        {
            get { return _pc.Value; }
            set { _pc.Value = value; }
        }

        /// <summary>
        /// Property <c>A</c> is the low part of the AF register.
        /// </summary>
        public byte A
        {
            get { return _af.Hi; }
            set { _af.Hi = value; }
        }

        /// <summary>
        /// Property <c>B</c> is the low part of the BC register.
        /// </summary>
        public byte B
        {
            get { return _bc.Hi; }
            set { _bc.Hi = value; }
        }

        /// <summary>
        /// Property <c>C</c> is the low part of the BC register.
        /// </summary>
        public byte C
        {
            get { return _bc.Lo; }
            set { _bc.Lo = value; }
        }

        /// <summary>
        /// Property <c>D</c> is the low part of the DE register.
        /// </summary>
        public byte D
        {
            get { return _de.Hi; }
            set { _de.Hi = value; }
        }

        /// <summary>
        /// Property <c>E</c> is the low part of the DE register.
        /// </summary>
        public byte E
        {
            get { return _de.Lo; }
            set { _de.Lo = value; }
        }

        /// <summary>
        /// Property <c>H</c> is the low part of the HL register.
        /// </summary>
        public byte H
        {
            get { return _hl.Hi; }
            set { _hl.Hi = value; }
        }

        /// <summary>
        /// Property <c>L</c> is the low part of the HL register.
        /// </summary>
        public byte L
        {
            get { return _hl.Lo; }
            set { _hl.Lo = value; }
        }

        /// <summary>
        /// Property <c>FZ</c> is the Zero flag.
        /// </summary>
        public byte FZ
        {
            get { return (byte)(_af.Lo >> 7); }
            set { _af.Lo = (byte)(_af.Lo ^ (value << 7)); }
        }

        /// <summary>
        /// Property <c>FN</c> is the Subtraction flag.
        /// </summary>
        public byte FN
        {
            get { return (byte)((_af.Lo & 0b_0100_0000) >> 6); }
            set { _af.Lo = (byte)(_af.Lo ^ (value << 6)); }
        }

        /// <summary>
        /// Property <c>FH</c> is the Half Carry flag.
        /// </summary>
        public byte FH
        {
            get { return (byte)((_af.Lo & 0b_0010_0000) >> 5); }
            set { _af.Lo = (byte)(_af.Lo ^ (value << 5)); }
        }

        /// <summary>
        /// Property <c>FC</c> is the Carry flag.
        /// </summary>
        public byte FC
        {
            get { return (byte)((_af.Lo & 0b_0001_0000) >> 4); }
            set { _af.Lo = (byte)(_af.Lo ^ (value << 4)); }
        }

        private static Registers? _instance;
        private static readonly object _lock = new object();

        private Registers()
        {
            _af = new Register();
            _bc = new Register();
            _de = new Register();
            _hl = new Register();
            _sp = new Register();
            _pc = new Register();
        }

        /// <summary>
        /// Method <c>getInstance</c> creates a single instance of the Registers Class.
        /// </summary>
        /// <returns>
        /// The instance of the Registers Class.
        /// </returns>
        public static Registers getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Registers();
                    }
                }
            }
            return _instance;
        }

    }
}
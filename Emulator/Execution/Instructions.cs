namespace Execution
{
    /// <summary>
    /// Class <c>Instructions</c> contains all the instructions from the SM83 processor instruction set.
    /// </summary>
    public class Instructions
    {

        private Registers _regs = Registers.getInstance();

        private void IncrementPC(ushort value) { _regs.PC += value; }

        private static bool IsOverflowingFrom(int value, int bit) => value >= bit;

        /// <summary>
        /// Method <c>ADC</c> adds the input value plus the carry flag to A.
        /// </summary>
        public void ADC(byte value, int cycles, ushort bytesNb)
        {
            ushort whole = (ushort)(_regs.A + value + _regs.FC);
            byte truncated = (byte)whole;
            _regs.A = truncated;

            if (truncated == 0) { _regs.FZ = 1; }
            _regs.FN = 0;
            if (IsOverflowingFrom(whole, 0b_1111)) { _regs.FH = 1; }
            if (IsOverflowingFrom(whole, 0b_1111_1111)) { _regs.FC = 1; }

            //Synchro(cycles);
            IncrementPC(bytesNb);
        }

        /// <summary>
        /// Method <c>ADD8</c> adds the input value to A.
        /// </summary>
        public void ADD8(byte value, int cycles, ushort bytesNb)
        {
            ushort whole = (ushort)(_regs.A + value);
            byte truncated = (byte)whole;
            _regs.A = truncated;

            if (truncated == 0) { _regs.FZ = 1; }
            _regs.FN = 0;
            if (IsOverflowingFrom(whole, 0b_1111)) { _regs.FH = 1; }
            if (IsOverflowingFrom(whole, 0b_1111_1111)) { _regs.FC = 1; }

            //Synchro(cycles);
            IncrementPC(bytesNb);
        }

        /// <summary>
        /// Method <c>ADD16</c> adds the input value to HL.
        /// </summary>
        public void ADD16(ushort value, int cycles, ushort bytesNb)
        {
            int whole = (int)(_regs.HL + value);
            _regs.HL = (ushort)whole;

            _regs.FN = 0;
            if (IsOverflowingFrom(whole, 0b_1111_1111_1111)) { _regs.FH = 1; }
            if (IsOverflowingFrom(whole, 0b_1111_1111_1111_1111)) { _regs.FC = 1; }

            //Synchro(cycles);
            IncrementPC(bytesNb);
        }

        /// <summary>
        /// Method <c>ADDSP</c> adds the signed value to SP.
        /// </summary>
        public void ADDSP(byte value, int cycles, ushort bytesNb)
        {
            ushort whole = (ushort)(_regs.SP + value);
            _regs.SP = whole;

            _regs.FZ = 0;
            _regs.FN = 0;
            if (IsOverflowingFrom(whole, 0b_1111)) { _regs.FH = 1; }
            if (IsOverflowingFrom(whole, 0b_1111_1111)) { _regs.FC = 1; }

            //Synchro(cycles);
            IncrementPC(bytesNb);
        }

    }
}


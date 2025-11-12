namespace Cpu
{
    public static class Decoder
    {
        private const Dictionary<byte, (int length, int cycles, int cyclesCond)> INSTRUCTION_LENGTHS_CYCLES = new Dictionary<byte, (int length, int cycles, int cyclesCond)>()
        {
            {0x00, (1, 4, 0)},
            {0x01, (3, 12, 8)}
        };

        private const Dictionary<byte, (int length, int cycles, int cyclesCond)> PREFIXED_INSTRUCTION_LENGTHS_CYCLES = new Dictionary<byte, (int length, int cycles, int cyclesCond)>()
        {
            {0x00, (2, 8, 0)},
            {0x01, (2, 8, 0)}
        };
        
        public static void Decode()
        {
            //TODO :
            // - Boucle infinie
            //      - Lecture de l'instruction
            //      - Execution de l'instruction
            //      bool? = opcode switch{...}
            //      - Mise à jour du registre PC
            //      - Coller à la clock
        }
    }
}
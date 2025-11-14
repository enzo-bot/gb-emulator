namespace Emulator.Memory;

public class Mbc1RomDevice : IMemoryDevice
{
    private readonly byte[] _rom; // données ROM complètes
    private readonly int _romBanks;
    private int _currentBank = 1; // bank 1 par défaut pour la zone switchable (0x4000-0x7FFF)
    private bool _ramEnabled = false;
    private readonly ushort _baseFixed;   // 0x0000
    private readonly ushort _baseSwitch;  // 0x4000

    public Mbc1RomDevice(byte[] rom)
    {
        _rom = rom;
        _romBanks = Math.Max(1, rom.Length / 0x4000);
        _baseFixed = 0x0000;
        _baseSwitch = 0x4000;
    }

    public byte Read(ushort addr)
    {
        if (addr >= 0x0000 && addr <= 0x3FFF)
        {
            // bank 0 (fixed)
            int index = addr; // 0..0x3FFF
            if (index < _rom.Length) return _rom[index];
            return 0xFF;
        }
        else if (addr >= 0x4000 && addr <= 0x7FFF)
        {
            int offset = addr - 0x4000;
            int bank = _currentBank % _romBanks;
            int index = bank * 0x4000 + offset;
            if (index < _rom.Length) return _rom[index];
            return 0xFF;
        }
        else
        {
            // Cette device s'attend à être mappée uniquement 0x0000..0x7FFF.
            throw new InvalidOperationException($"ROM read out of range {addr:X4}");
        }
    }

    public void Write(ushort addr, byte value)
    {
        // Écrire dans 0x2000..0x3FFF change le numéro de banque bas (simplifié)
        if (addr >= 0x2000 && addr <= 0x3FFF)
        {
            int newBank = value & 0x1F; // 5 bits
            if (newBank == 0) newBank = 1; // 0 -> 1
            _currentBank = (_currentBank & ~0x1F) | newBank;
        }
        else if (addr >= 0x0000 && addr <= 0x1FFF)
        {
            // activer/désactiver RAM externe (simple)
            _ramEnabled = (value & 0x0A) == 0x0A;
        }
        else if (addr >= 0x4000 && addr <= 0x5FFF)
        {
            // upper bits en mode complet MBC1 (mode simplifié)
            int hi = value & 0x03;
            _currentBank = (_currentBank & 0x1F) | (hi << 5);
            if ((_currentBank & 0x1F) == 0) _currentBank |= 1;
        }
        // autres registres (mode select 0x6000..0x7FFF) ignorés ici
    }
}
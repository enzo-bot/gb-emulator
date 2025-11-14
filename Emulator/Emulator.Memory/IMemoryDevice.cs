namespace Emulator.Memory;

public interface IMemoryDevice
{
    byte Read(ushort addr);
    void Write(ushort addr, byte value);
}
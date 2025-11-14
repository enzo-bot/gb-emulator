namespace Emulator.Memory;

public class FlatMemoryDevice : IMemoryDevice
{
    private readonly byte[] _data;
    private readonly ushort _baseAddress;

    public FlatMemoryDevice(int size, ushort baseAddress = 0)
    {
        _data = new byte[size];
        _baseAddress = baseAddress;
    }

    public FlatMemoryDevice(byte[] initial, ushort baseAddress = 0)
    {
        _data = new byte[initial.Length];
        Array.Copy(initial, _data, initial.Length);
        _baseAddress = baseAddress;
    }

    public byte Read(ushort addr) => _data[addr - _baseAddress];

    public void Write(ushort addr, byte value) => _data[addr - _baseAddress] = value;
}
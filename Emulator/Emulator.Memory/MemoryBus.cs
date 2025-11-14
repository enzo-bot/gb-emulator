namespace Emulator.Memory;

public class MemoryBus
{
    // Mapping d'une plage vers un device
    public class Region
    {
        public ushort Start { get; }
        public ushort End { get; }
        public IMemoryDevice Device { get; }

        public Region(ushort start, ushort end, IMemoryDevice device)
        {
            Start = start;
            End = end;
            Device = device;
        }

        /// <summary>
        /// Method <c>Contains</c> checks if an address is included in the Region instance.
        /// </summary>
        /// <returns>
        /// True if the Region contains the address
        /// </returns>
        public bool Contains(ushort addr) => addr >= Start && addr <= End;
    }

    private readonly List<Region> _regions = new List<Region>();

    /// <summary>
    /// Method <c>Map</c> registers a device mapped to an address range [start..end].
    /// </summary>
    public void Map(ushort start, ushort end, IMemoryDevice device)
    {
        if (end < start) throw new ArgumentException("end < start");
        _regions.Add(new Region(start, end, device));
    }

    /// <summary>
    /// Method <c>FindRegion</c> looks for the first Region containing the address.
    /// </summary>
    /// <returns>
    /// The first Region containing the address
    /// </returns>
    private Region FindRegion(ushort addr)
    {
        foreach (Region r in _regions)
            if (r.Contains(addr)) return r;
        return null;
    }

    /// <summary>
    /// Method <c>ReadByte</c> finds the value located at the address specified.
    /// </summary>
    /// <returns>
    /// A byte value located at addr
    /// </returns>
    public byte ReadByte(ushort addr)
    {
        var r = FindRegion(addr) ?? throw new InvalidOperationException($"No device mapped at {addr:X4}");
        return r.Device.Read(addr);
    }

    /// <summary>
    /// Method <c>WriteByte</c> writes the byte value at the address specified.
    /// </summary>
    public void WriteByte(ushort addr, byte value)
    {
        var r = FindRegion(addr) ?? throw new InvalidOperationException($"No device mapped at {addr:X4}");
        r.Device.Write(addr, value);
    }

    // Lecture 16-bit little-endian (attention wrap-around d'adresse)
    public ushort ReadWord(ushort addr)
    {
        byte lo = ReadByte(addr);
        // addition modulo 65536
        ushort next = (ushort)(addr + 1);
        byte hi = ReadByte(next);
        return (ushort)(lo | (hi << 8));
    }
}

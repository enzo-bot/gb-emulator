public class Registers
{
    private Register _af;
    private Register _bc;
    private Register _de;
    private Register _hl;
    private Register _sp;
    private Register _pc;

    public ushort AF
    { 
        get { return _af.RegisterValue; } 
        set { _af.RegisterValue = value; }
    }
    public ushort BC
    { 
        get { return _bc.RegisterValue; } 
        set { _bc.RegisterValue = value; }
    }
    public ushort DE
    { 
        get { return _de.RegisterValue; } 
        set { _de.RegisterValue = value; }
    }
    public ushort HL
    { 
        get { return _hl.RegisterValue; } 
        set { _hl.RegisterValue = value; }
    }
    public ushort SP
    { 
        get { return _sp.RegisterValue; } 
        set { _sp.RegisterValue = value; }
    }
    public ushort PC
    { 
        get { return _pc.RegisterValue; } 
        set { _pc.RegisterValue = value; }
    }

    public ushort A
    {
        get{ return _af.Hi; }
        set{ _af.Hi = value; }
    }
    public ushort B
    {
        get{ return _bc.Hi; }
        set{ _bc.Hi = value; }
    }
    public ushort C
    {
        get{ return _bc.Lo; }
        set{ _bc.Lo = value; }
    }
    public ushort D
    {
        get{ return _de.Hi; }
        set{ _de.Hi = value; }
    }
    public ushort E
    {
        get{ return _de.Lo; }
        set{ _de.Lo = value; }
    }
    public ushort H
    {
        get{ return _hl.Hi; }
        set{ _hl.Hi = value; }
    }
    public ushort L
    {
        get{ return _hl.Lo; }
        set{ _hl.Lo = value; }
    }

    public ushort FZ
    {
        get{ return (ushort)(_af.Lo >> 7); }
        set{ _af.Lo = (ushort)(_af.Lo ^ (value << 7)); }
    }
    public ushort FN
    {
        get{ return (ushort)((_af.Lo & 0b_0000_0000_0100_0000) >> 6); }
        set{ _af.Lo = (ushort)(_af.Lo ^ (value << 6)); }
    }
    public ushort FH
    {
        get{ return (ushort)((_af.Lo & 0b_0000_0000_0010_0000) >> 5); }
        set{ _af.Lo = (ushort)(_af.Lo ^ (value << 5)); }
    }
    public ushort FC
    {
        get{ return (ushort)((_af.Lo & 0b_0000_0000_0001_0000) >> 4); }
        set{ _af.Lo = (ushort)(_af.Lo ^ (value << 4)); }
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
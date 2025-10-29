public class Register
{
    public ushort RegisterValue { get; set; }

    public ushort Hi
    {
        get { return (ushort)(RegisterValue & 0b_1111_1111_0000_0000); }
        set { RegisterValue = (ushort)((value << 8) ^ Lo); }
    }

    public ushort Lo
    {
        get { return (ushort)(RegisterValue & 0b_0000_0000_1111_1111); }
        set { RegisterValue = (ushort)(Hi ^ value); }
    }
}
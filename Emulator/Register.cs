/// <summary>
/// Class <c>Register</c> models a 16-bits register from the SM83 processor.
/// </summary>
public class Register
{
    private (byte hi, byte lo) _value;

    /// <summary>
    /// Property <c>Value</c> is the 16-bits value of the register.
    /// </summary>
    public ushort Value
    {
        get
        {
            ushort tmp = (ushort)(((ushort)_value.hi) << 8);
            tmp += (ushort)_value.lo;
            return tmp;
        }
        set
        {
            _value.lo = (byte)value;
            _value.hi = (byte)(value >> 8);
        }
    }

    /// <summary>
    /// Property <c>Lo</c> is the 8-bits low value of the register.
    /// </summary>
    public byte Lo
    {
        get { return _value.lo; }
        set { _value.lo = value; }
    }

    /// <summary>
    /// Property <c>Hi</c> is the 8-bits high value of the register.
    /// </summary>
    public byte Hi
    {
        get { return _value.hi; }
        set { _value.hi = value; }
    }
}
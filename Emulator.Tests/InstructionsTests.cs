using Execution;

namespace Emulator.Tests;

public class InstructionsTests
{
    private Registers _regs;
    private Instructions _inst;

    [SetUp]
    public void Setup()
    {
        _regs = Registers.getInstance();
        _inst = new Instructions();
    }

    [TearDown]
    public void Cleanup()
    {
        _regs.AF = 0;
        _regs.BC = 0;
        _regs.DE = 0;
        _regs.HL = 0;
        _regs.SP = 0;
        _regs.PC = 0;
    }

    ///
    /// ADC TESTS
    ///
    [Test]
    public void ADCr8Test()
    {
        _regs.B = 28;
        _inst.ADC(_regs.B, 1, 1);
        Assert.That(_regs.A, Is.EqualTo(28));
    }

    [Test]
    public void ADCmemHLTest()
    {
        Assert.Ignore("This test is not yet implemented.");
    }

    [Test]
    public void ADCn8Test()
    {
        _inst.ADC(28, 1, 1);
        Assert.That(_regs.A, Is.EqualTo(28));
    }

    [Test]
    public void ADCWithCarryTest()
    {
        _regs.FC = 1;
        _inst.ADC(28, 1, 1);
        Assert.That(_regs.A, Is.EqualTo(29));
    }

    [Test]
    public void ADCFlagsUpdateTest()
    {
        _regs.A = 0b_1111_1110;
        _inst.ADC(0b_0000_0010, 1, 1);
        Assert.Multiple(() =>
        {
            Assert.That(_regs.A, Is.EqualTo(0b_0000_0000));
            Assert.That(_regs.FZ, Is.EqualTo(1));
            Assert.That(_regs.FN, Is.EqualTo(0));
            Assert.That(_regs.FH, Is.EqualTo(1));
            Assert.That(_regs.FC, Is.EqualTo(1));
        });
    }

    [Test]
    public void ADCSynchronyzeClockTest()
    {
        Assert.Ignore("This test is not yet implemented.");
    }

    [Test]
    public void ADCIncrementPCTest()
    {
        ushort tmp = _regs.PC;
        _inst.ADC(1, 1, 1);
        Assert.That(_regs.PC, Is.EqualTo(tmp + 1));
    }

    ///
    /// ADD8 TESTS
    ///
    [Test]
    public void ADD8r8Test()
    {
        _regs.B = 28;
        _inst.ADD8(_regs.B, 1, 1);
        Assert.That(_regs.A, Is.EqualTo(28));
    }

    [Test]
    public void ADD8memHLTest()
    {
        Assert.Ignore("This test is not yet implemented.");
    }

    [Test]
    public void ADD8n8Test()
    {
        _inst.ADD8(28, 1, 1);
        Assert.That(_regs.A, Is.EqualTo(28));
    }

    [Test]
    public void ADD8WithCarryTest()
    {
        _regs.FC = 1;
        _inst.ADD8(28, 1, 1);
        Assert.That(_regs.A, Is.EqualTo(28));
    }

    [Test]
    public void ADD8FlagsUpdateTest()
    {
        _regs.A = 0b_1111_1110;
        _inst.ADD8(0b_0000_0010, 1, 1);
        Assert.Multiple(() =>
        {
            Assert.That(_regs.A, Is.EqualTo(0b_0000_0000));
            Assert.That(_regs.FZ, Is.EqualTo(1));
            Assert.That(_regs.FN, Is.EqualTo(0));
            Assert.That(_regs.FH, Is.EqualTo(1));
            Assert.That(_regs.FC, Is.EqualTo(1));
        });
    }

    [Test]
    public void ADD8SynchronyzeClockTest()
    {
        Assert.Ignore("This test is not yet implemented.");
    }

    [Test]
    public void ADD8IncrementPCTest()
    {
        ushort tmp = _regs.PC;
        _inst.ADD8(1, 1, 1);
        Assert.That(_regs.PC, Is.EqualTo(tmp + 1));
    }

    ///
    /// ADD16 TESTS
    ///
    [Test]
    public void ADD16r16Test()
    {
        _regs.BC = 42000;
        _inst.ADD16(_regs.BC, 1, 1);
        Assert.That(_regs.HL, Is.EqualTo(42000));
    }

    [Test]
    public void ADD16SPTest()
    {
        _regs.SP = 42000;
        _inst.ADD16(_regs.SP, 1, 1);
        Assert.That(_regs.HL, Is.EqualTo(42000));
    }

    [Test]
    public void ADD16WithCarryTest()
    {
        _regs.FC = 1;
        _inst.ADD16(28, 1, 1);
        Assert.That(_regs.HL, Is.EqualTo(28));
    }

    [Test]
    public void ADD16FlagsUpdateTest()
    {
        _regs.HL = 0b_1111_1111_1111_1110;
        _inst.ADD16(0b_0000_0000_0000_0010, 1, 1);
        Assert.Multiple(() =>
        {
            Assert.That(_regs.HL, Is.EqualTo(0b_0000_0000_0000_0000));
            Assert.That(_regs.FN, Is.EqualTo(0));
            Assert.That(_regs.FH, Is.EqualTo(1));
            Assert.That(_regs.FC, Is.EqualTo(1));
        });
    }

    [Test]
    public void ADD16SynchronyzeClockTest()
    {
        Assert.Ignore("This test is not yet implemented.");
    }

    [Test]
    public void ADD16IncrementPCTest()
    {
        ushort tmp = _regs.PC;
        _inst.ADD16(1, 1, 1);
        Assert.That(_regs.PC, Is.EqualTo(tmp + 1));
    }

    ///
    /// ADDSP TESTS
    ///
    [Test]
    public void ADDSPe8Test()
    {
        _inst.ADDSP(28, 1, 1);
        Assert.That(_regs.SP, Is.EqualTo(28));
    }

    [Test]
    public void ADDSPWithCarryTest()
    {
        _regs.FC = 1;
        _inst.ADDSP(28, 1, 1);
        Assert.That(_regs.SP, Is.EqualTo(28));
    }

    [Test]
    public void ADDSPFlagsUpdateTest()
    {
        _regs.SP = 0b_1111_1110;
        _inst.ADDSP(0b_0000_0010, 1, 1);
        Assert.Multiple(() =>
        {
            Assert.That(_regs.SP, Is.EqualTo(0b_0001_0000_0000));
            Assert.That(_regs.FZ, Is.EqualTo(0));
            Assert.That(_regs.FN, Is.EqualTo(0));
            Assert.That(_regs.FH, Is.EqualTo(1));
            Assert.That(_regs.FC, Is.EqualTo(1));
        });
    }

    [Test]
    public void ADDSPSynchronyzeClockTest()
    {
        Assert.Ignore("This test is not yet implemented.");
    }

    [Test]
    public void ADDSPIncrementPCTest()
    {
        ushort tmp = _regs.PC;
        _inst.ADDSP(1, 1, 2);
        Assert.That(_regs.PC, Is.EqualTo(tmp + 2));
    }
}
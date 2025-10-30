namespace Emulator.Tests;

public class RegistersTests
{
    private Registers _regs;

    [SetUp]
    public void Setup()
    {
        _regs = Registers.getInstance();
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

    [Test]
    public void GetRegistersUniqueInstanceTest()
    {
        Registers secondregs = Registers.getInstance();
        Assert.That(secondregs, Is.SameAs(_regs));
    }

    [Test]
    public void UpdateRegisterValueTest()
    {
        _regs.BC = 0b_0000_0000_0000_1001;
        Assert.That(_regs.BC, Is.EqualTo(9));
    }

    [Test]
    public void UpdateRegisterHighValueTest()
    {
        _regs.BC = 0b_0000_0010_0000_0001;
        _regs.B = 0b_0000_0001;
        Assert.That(_regs.BC, Is.EqualTo(257));
    }

    [Test]
    public void UpdateRegisterLowValueTest()
    {
        _regs.BC = 0b_0000_0000_0000_0010;
        _regs.C = 0b_0000_0001;
        Assert.That(_regs.BC, Is.EqualTo(1));
    }

    [Test]
    public void UpdateZFlagValueTest()
    {
        _regs.FZ = 1;
        Assert.That(_regs.FZ, Is.EqualTo(1));
        Assert.That(_regs.AF, Is.EqualTo(128));
    }

    [Test]
    public void UpdateNFlagValueTest()
    {
        _regs.FN = 1;
        Assert.That(_regs.FN, Is.EqualTo(1));
        Assert.That(_regs.AF, Is.EqualTo(64));
    }

    [Test]
    public void UpdateHFlagValueTest()
    {
        _regs.FH = 1;
        Assert.That(_regs.FH, Is.EqualTo(1));
        Assert.That(_regs.AF, Is.EqualTo(32));
    }

    [Test]
    public void UpdateCFlagValueTest()
    {
        _regs.FC = 1;
        Assert.That(_regs.FC, Is.EqualTo(1));
        Assert.That(_regs.AF, Is.EqualTo(16));
    }
}

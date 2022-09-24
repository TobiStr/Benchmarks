namespace Benchmarks.Allocations.Model;

public struct TestStruct
{
    public int Value { get; set; }

    public TestStruct(int value)
    {
        Value = value;
    }
}

public class TestClass
{
    public int Value { get; set; }

    public TestClass(int value)
    {
        Value = value;
    }
}

public readonly record struct TestRecordStruct(int Value);
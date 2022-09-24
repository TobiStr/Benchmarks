namespace Benchmarks.Allocations.StructsClasses.Initialize;

[MemoryDiagnoser]
public class InitializeBenchmarks
{
    [Benchmark]
    public void InitializeStruct()
    {
        _ = new TestStruct(1);
    }

    [Benchmark]
    public void InitializeClass()
    {
        _ = new TestClass(1);
    }

    [Benchmark]
    public void InitializeRecordStruct()
    {
        _ = new TestRecordStruct(1);
    }
}
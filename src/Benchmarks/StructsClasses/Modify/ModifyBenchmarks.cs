namespace Benchmarks.Allocations.StructsClasses.Modify;

public class ModifyBenchmarks
{
    [Params(10, 100, 1000)]
    public int ModifyCount { get; set; }

    [Benchmark]
    public void ModifyClass()
    {
        var x = new TestClass(1);

        for (int i = 0; i < ModifyCount; i++)
        {
            x.Value = i;
        }
    }

    [Benchmark]
    public void ModifyStruct()
    {
        var x = new TestStruct(1);

        for (int i = 0; i < ModifyCount; i++)
        {
            x.Value = i;
        }
    }

    [Benchmark]
    public void ModifyRecordStruct()
    {
        var x = new TestRecordStruct(1);

        for (int i = 0; i < ModifyCount; i++)
        {
            _ = x with { Value = i };
        }
    }
}
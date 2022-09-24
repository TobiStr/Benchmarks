namespace Benchmarks.Allocations.StructsClasses.Pass;

[MemoryDiagnoser]
public class PassBenchmarks
{
    [Params(10, 100, 1000)]
    public int PassCount { get; set; }

    [Benchmark]
    public void PassClasses()
    {
        var x = new TestClass(1);
        _ = PassClassesInternal(x, 0);
    }

    [Benchmark]
    public void PassStructs()
    {
        var x = new TestStruct(1);
        _ = PassStructsInternal(x, 0);
    }

    private int PassClassesInternal(TestClass testClass, int count)
    {
        if (count >= PassCount) return count;
        return PassClassesInternal(testClass, count + 1);
    }

    private int PassStructsInternal(TestStruct testStruct, int count)
    {
        if (count >= PassCount) return count;
        return PassStructsInternal(testStruct, count + 1);
    }
}
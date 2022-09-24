namespace Benchmarks.Allocations.Closures;

[MemoryDiagnoser]
public class ClosuresBenchmarks
{
    [Benchmark]
    public void Closure()
    {
        int x = 1;

        _ = Enumerable.Range(0, 1000000)
            .Select(i => i + x)
            .ToArray();
    }

    [Benchmark]
    public void NonClosure()
    {
        const int length = 1000000;

        var results = new int[length];

        for (int i = 0; i < length; i++)
        {
            results[i] = i + 1;
        }
    }
}
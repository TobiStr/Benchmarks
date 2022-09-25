namespace Benchmarks.Allocations.Enumerables.Linq;

[MemoryDiagnoser]
public class LinqBenchmarks
{
    [Params(1000)]
    public int IterationCount { get; set; }

    private List<int> list;

    [GlobalSetup]
    public void GlobalSetup()
    {
        list = Enumerable.Range(0, IterationCount).ToList();
    }

    [Benchmark]
    public void EnumearateOnce()
    {
        var x = IterationCount / 2;
        _ = list
            .Where(i => i > x)
            .Select(i => i * 2)
            .ToArray();
    }

    [Benchmark]
    public void EnumerateTwice()
    {
        var x = IterationCount / 2;
        var half = list
            .Where(i => i > x)
            .ToArray();

        _ = half
            .Select(i => i * 2)
            .ToArray();
    }

    [Benchmark]
    public void Any()
    {
        _ = list.Any(_ => true);
    }

    [Benchmark]
    public void CountBiggerZero()
    {
        _ = list.Count(_ => true) > 0;
    }

    [Benchmark]
    public void WhereBeforeSelect()
    {
        var x = IterationCount / 2;
        _ = list
            .Where(i => i > x)
            .Select(i => i * 2)
            .ToArray();
    }

    [Benchmark]
    public void WhereAfterSelect()
    {
        var x = IterationCount / 4;
        _ = list
            .Select(i => i * 2)
            .Where(i => i > x)
            .ToArray();
    }

    [Benchmark]
    public void CountBetween()
    {
        var x = IterationCount / 2;
        var half = list
            .Where(i => i > x);

        var count = half.Count();

        _ = half
            .Select(i => i * 2)
            .ToArray();
    }
}
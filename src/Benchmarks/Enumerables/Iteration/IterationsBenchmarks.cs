using System.Runtime.InteropServices;

namespace Benchmarks.Allocations.Enumerables.Iteration;

[MemoryDiagnoser]
public class IterationsBenchmarks
{
    [Params(100, 10_000, 10_000_000)]
    public int IterationCount { get; set; }

    private List<int> list;

    [GlobalSetup]
    public void GlobalSetup()
    {
        list = Enumerable.Range(0, IterationCount).ToList();
    }

    [Benchmark]
    public void ForLoop()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            Operation(list[i]);
        }
    }

    [Benchmark]
    public void ForEachLoop()
    {
        foreach (var item in list)
        {
            Operation(item);
        }
    }

    [Benchmark]
    public void LinqForEach()
    {
        list.ForEach(item => Operation(item));
    }

    [Benchmark]
    public void ParallelForEach()
    {
        Parallel.ForEach(list, item => Operation(item));
    }

    [Benchmark]
    public void LinqParallelForEach()
    {
        list.AsParallel().ForAll(item => Operation(item));
    }

    [Benchmark]
    public void SpanFor()
    {
        var span = CollectionsMarshal.AsSpan(list);
        for (int i = 0; i < span.Length; i++)
        {
            Operation(span[i]);
        }
    }

    [Benchmark]
    public void SpanForEach()
    {
        foreach (var item in CollectionsMarshal.AsSpan(list))
        {
            Operation(item);
        }
    }

    private void Operation(int i)
    {
        _ = i;
    }
}
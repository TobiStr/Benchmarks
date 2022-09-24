using System.Runtime.InteropServices;

namespace Benchmarks.Allocations.Enumerables.Iteration;

[MemoryDiagnoser]
public class ComplexIterationsBenchmarks
{
    [Params(100)]
    public int IterationCount { get; set; }

    private List<int> list;

    [GlobalSetup]
    public void GlobalSetup()
    {
        list = Enumerable.Range(0, IterationCount).ToList();
    }

    [Benchmark]
    public async Task ForEachLoop()
    {
        foreach (var item in list)
        {
            await OperationAsync(item);
        }
    }

    [Benchmark]
    public async Task ParallelForEach()
    {
        await Parallel.ForEachAsync(list, async (item, ct) => await OperationAsync(item));
    }

    [Benchmark]
    public void SpanForEach()
    {
        foreach (var item in CollectionsMarshal.AsSpan(list))
        {
            OperationAsync(item).Wait();
        }
    }

    private async Task OperationAsync(int i)
    {
        await Task.Delay(10);
    }
}
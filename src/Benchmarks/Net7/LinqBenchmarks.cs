using BenchmarkDotNet.Jobs;

namespace Benchmarks.Net7;

[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class LinqBenchmarks
{
    [Params(10000)]
    public int IterationCount { get; set; }

    private List<int> list;

    [GlobalSetup]
    public void GlobalSetup()
    {
        list = Enumerable.Range(0, IterationCount).ToList();
    }

    [Benchmark]
    public void SelectTest()
    {
        list.Select(i => i * 2).ToArray();
    }
}
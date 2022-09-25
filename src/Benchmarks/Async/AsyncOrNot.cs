namespace Benchmarks.Allocations.Async;

[MemoryDiagnoser]
public class AsyncOrNot
{
    [Benchmark]
    public void GetNumbers()
    {
        for (int i = 0; i < 1000; i++)
            _ = Enumerable.Range(0, 10).ToArray();
    }

    [Benchmark]
    public async Task GetNumbersAsync()
    {
        for (int i = 0; i < 1000; i++)
            _ = await Task.Run(() => Enumerable.Range(0, 10).ToArray());
    }
}
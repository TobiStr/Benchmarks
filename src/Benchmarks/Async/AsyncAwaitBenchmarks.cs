namespace Benchmarks.Allocations.Async;

[MemoryDiagnoser]
public class AsyncAwaitBenchmarks
{
    [Benchmark]
    public async Task WithAwait()
    {
        await WithAwaitInternal();
    }

    [Benchmark]
    public async Task WithOutAwait()
    {
        await WithOutAwaitInternal();
    }

    private async Task WithAwaitInternal()
    {
        await InternalTask();
    }

    private Task WithOutAwaitInternal()
    {
        return InternalTask();
    }

    private async Task InternalTask()
    {
        await Task.Delay(10);
    }
}
namespace Benchmarks.Allocations.Exceptions;

[MemoryDiagnoser]
public class ThrowBenchmarks
{
    [Benchmark]
    public void NoTryCatch()
    {
        Operation();
    }

    [Benchmark]
    public void TryCatchWithoutThrow()
    {
        TryCatchWithoutThrowInternal();
    }

    [Benchmark]
    public void NoTryCatch1000()
    {
        for (int i = 0; i < 1000; i++)
            Operation();
    }

    [Benchmark]
    public void TryCatchWithoutThrow1000()
    {
        for (int i = 0; i < 1000; i++)
            TryCatchWithoutThrowInternal();
    }

    [Benchmark]
    public void TryCatchWithThrow()
    {
        TryCatchWithThrowInternal();
    }

    private void TryCatchWithoutThrowInternal()
    {
        try
        {
            Operation();
        }
        catch (Exception ex)
        {
            //Ignore
        }
    }

    private void TryCatchWithThrowInternal()
    {
        try
        {
            Operation();
            throw new InvalidOperationException();
        }
        catch (Exception ex)
        {
            //Ignore
        }
    }

    private void Operation()
    {
        _ = Enumerable.Range(0, 100).ToArray();
    }
}
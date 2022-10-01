namespace Benchmarks.StructsClasses.Scenario;

[MemoryDiagnoser]
public class RealLifeScenario
{
    [Params(10, 1000, 1_000_000, 10_000_000)]
    public int ItemCount { get; set; }

    [Benchmark(Baseline = true)]
    public void MapDataStruct()
    {
        _ = FetchStructData()
            .Select(m => new OutputModelStruct($"{m.ForeName} {m.LastName}"))
            .ToArray();
    }

    [Benchmark]
    public void MapDataClass()
    {
        _ = FetchClassData()
            .Select(m => new OutputModelClass($"{m.ForeName} {m.LastName}"))
            .ToArray();
    }

    private IEnumerable<DatabaseModelStruct> FetchStructData()
    {
        return Enumerable
            .Range(0, ItemCount)
            .Select(_ => new DatabaseModelStruct(DateTime.MinValue, "Test", "Test", "TestStreet 123", Guid.NewGuid()));
    }

    private IEnumerable<DatabaseModelClass> FetchClassData()
    {
        return Enumerable
            .Range(0, ItemCount)
            .Select(_ => new DatabaseModelClass(DateTime.MinValue, "Test", "Test", "TestStreet 123", Guid.NewGuid()));
    }

    private readonly record struct DatabaseModelStruct(
        DateTime BirthDay,
        string ForeName,
        string LastName,
        string Address,
        Guid CustomerId
    );

    private readonly record struct OutputModelStruct(
        string FullName
    );

    private sealed record DatabaseModelClass(
        DateTime BirthDay,
        string ForeName,
        string LastName,
        string Address,
        Guid CustomerId
    );

    private sealed record OutputModelClass(
        string FullName
    );
}
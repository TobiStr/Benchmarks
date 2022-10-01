using System.Runtime.InteropServices;

namespace Benchmarks.StructsClasses.Collections;

[MemoryDiagnoser]
public class CollectionsBenchmarks
{
    [Params(100, 1000, 10000, 1_000_000, 10_000_000)]
    public int ItemsCount { get; set; }

    private List<TestStruct> structList;

    private List<TestClass> classList;

    private TestStruct[] structArray;

    private TestClass[] classArray;

    [GlobalSetup]
    public void GlobalSetup()
    {
        structList = Enumerable
            .Range(0, ItemsCount)
            .Select(i => new TestStruct(i))
            .ToList();

        classList = Enumerable
            .Range(0, ItemsCount)
            .Select(i => new TestClass(i))
            .ToList();

        var arr1 = new TestStruct[ItemsCount];
        var arr2 = new TestClass[ItemsCount];

        for (int i = 0; i < ItemsCount; i++)
        {
            arr1[i] = new TestStruct(i);
            arr2[i] = new TestClass(i);
        }
    }

    [Benchmark]
    public void InitializeStructArray()
    {
        _ = Enumerable
            .Range(0, ItemsCount)
            .Select(i => new TestStruct(i))
            .ToArray();
    }

    [Benchmark]
    public void InitializeClassArray()
    {
        _ = Enumerable
            .Range(0, ItemsCount)
            .Select(i => new TestClass(i))
            .ToArray();
    }

    [Benchmark]
    public void TransformStructArray()
    {
        _ = structList
            .Select(i => i.Value)
            .ToArray();
    }

    [Benchmark]
    public void TransformClassArray()
    {
        _ = classList
            .Select(i => i.Value)
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public void AccessStructSpan()
    {
        var span = CollectionsMarshal.AsSpan(structList);

        foreach (var item in span)
        {
            _ = item.Value;
        }
    }

    [Benchmark]
    public void AccessClassSpan()
    {
        var span = CollectionsMarshal.AsSpan(classList);

        foreach (var item in span)
        {
            _ = item.Value;
        }
    }

    [Benchmark(Baseline = true)]
    public void AccessStructArray()
    {
        foreach (var item in structArray)
        {
            _ = item.Value;
        }
    }

    [Benchmark]
    public void AccessClassArray()
    {
        foreach (var item in classArray)
        {
            _ = item.Value;
        }
    }
}
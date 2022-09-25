using Microsoft.Extensions.Logging;

namespace Benchmarks.Allocations.Logging;

[MemoryDiagnoser]
public class LoggingBenchmarks
{
    private ILogger logger;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
            builder.AddConsole().SetMinimumLevel(LogLevel.Warning)
        );
        logger = loggerFactory.CreateLogger<LoggingBenchmarks>();
    }

    [Benchmark]
    public void LogString()
    {
        for (int i = 0; i < 1000; i++)
            logger.LogInformation(Random.Shared.Next().ToString());
    }

    [Benchmark]
    public void LogStringInterpolation()
    {
        for (int i = 0; i < 1000; i++)
            logger.LogInformation($"A{Random.Shared.Next()}");
    }

    [Benchmark]
    public void LogStringTemplate()
    {
        const string template = "A{Test}";

        for (int i = 0; i < 1000; i++)
            logger.LogInformation(template, Random.Shared.Next());
    }
}
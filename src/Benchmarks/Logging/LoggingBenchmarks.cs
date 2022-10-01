using Benchmarks.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Benchmarks.Allocations.Logging;

[MemoryDiagnoser]
public class LoggingBenchmarks
{
    [Params(1000)]
    public int Count { get; set; }

    private Microsoft.Extensions.Logging.ILogger microsoftLogger;

    private Serilog.ILogger seriLogger;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
            builder.AddConsole().SetMinimumLevel(LogLevel.Warning)
        );
        microsoftLogger = loggerFactory.CreateLogger<LoggingBenchmarks>();

        seriLogger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.Console()
            .CreateLogger();
    }

    [Benchmark]
    public void LogStringMicrosoft()
    {
        for (int i = 0; i < Count; i++)
            microsoftLogger.LogInformation(Random.Shared.Next().ToString());
    }

    [Benchmark]
    public void LogStringInterpolationMicrosoft()
    {
        for (int i = 0; i < Count; i++)
            microsoftLogger.LogInformation($"A{Random.Shared.Next()}");
    }

    [Benchmark]
    public void LogStringTemplateMicrosoft()
    {
        const string template = "A{Test}";

        for (int i = 0; i < Count; i++)
            microsoftLogger.LogInformation(template, Random.Shared.Next());
    }

    [Benchmark]
    public void LogStringTemplateExtension()
    {
        const string template = "A{Test}";

        for (int i = 0; i < Count; i++)
            microsoftLogger.Information(template, Random.Shared.Next());
    }

    [Benchmark]
    public void LogStringSerilog()
    {
        for (int i = 0; i < Count; i++)
            seriLogger.Information(Random.Shared.Next().ToString());
    }

    [Benchmark]
    public void LogStringInterpolationSerilog()
    {
        for (int i = 0; i < Count; i++)
            seriLogger.Information($"A{Random.Shared.Next()}");
    }

    [Benchmark]
    public void LogStringTemplateSerilog()
    {
        const string template = "A{Test}";

        for (int i = 0; i < Count; i++)
            seriLogger.Information(template, Random.Shared.Next());
    }
}
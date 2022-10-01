using Microsoft.Extensions.Logging;

namespace Benchmarks.Extensions;

public static class LoggerExtensions
{
    public static void Information(this ILogger logger, string messageTemplate)
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation(messageTemplate);
    }

    public static void Information<T>(this ILogger logger, string messageTemplate, T arg)
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation(messageTemplate, arg);
    }

    public static void Information<T0, T1>(this ILogger logger, string messageTemplate, T0 arg0, T1 arg1)
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation(messageTemplate, arg0, arg1);
    }
}
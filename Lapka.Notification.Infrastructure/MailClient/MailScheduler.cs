using Lapka.Notification.Application.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lapka.Notification.Infrastructure.MailClient;

public class MailScheduler : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<MailScheduler> _logger;

    public MailScheduler(IServiceScopeFactory ssf, ILogger<MailScheduler> logger)
    {
        _serviceScopeFactory = ssf;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var task = scope.ServiceProvider.GetRequiredService<RetrySendMailsJob>();

                var quantity = await task.Execute();
                _logger.Log(LogLevel.Information, $"Sended {quantity} mails.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed deleting expired tokens.");
            }

            await Task.Delay(TimeSpan.FromHours(2), cancellationToken: stoppingToken);
        }
    }
}
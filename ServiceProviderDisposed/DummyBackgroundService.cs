namespace ServiceProviderDisposed
{
    public class DummyBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public DummyBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);

            using var scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<HelloWorldService>();
        }
    }
}

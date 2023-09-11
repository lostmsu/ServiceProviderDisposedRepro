namespace ServiceProviderDisposed
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<HelloWorldService>();
            builder.Services.AddHostedService<DummyBackgroundService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapGet("/hello", () => "Hello");

            app.MapControllers();

            app.Run();
        }

    }
}
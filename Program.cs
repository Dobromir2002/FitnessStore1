internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add MongoDB services
        builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            var settings = MongoClientSettings.FromConnectionString("your_connection_string");
            return new MongoClient(settings);
        });
        builder.Services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase("your_database_name");
        });

        // Add other services to the container.
        builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductValidator>());
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();

        // Register the connection string
        builder.Services.AddSingleton(sp => "your_connection_string");

        // Register the repository with the connection string
        builder.Services.AddScoped(typeof(IRepository<>), sp =>
        {
            var connectionString = sp.GetRequiredService<string>();
            var repositoryType = typeof(Repository<>).MakeGenericType(typeof(Product));
            return Activator.CreateInstance(repositoryType, connectionString);
        });

        builder.Services.AddScoped<IProductService, ProductService>();

        WebApplication app = builder.Build();
    }

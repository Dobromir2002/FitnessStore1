public class Repository<T> : IRepository<T> where T : class
{
    private readonly string _connectionString;

    public Repository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Implement IRepository methods here
}

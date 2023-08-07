namespace Infraestructure.Configuration
{
    public record DataBaseConnectionSettings
    {
        public string ConnectionString { get; private set;}

        public DataBaseConnectionSettings() { }

        public void SetConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) 
            { 
                throw new ArgumentNullException(); 
            }

            ConnectionString = connectionString;
        }
    }
}

namespace CicekSepetiAPI.Helpers
{
    public interface IDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }

    public class MongoDbSettings : IDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}

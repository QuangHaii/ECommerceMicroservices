using MongoDB.Driver;

namespace ECommerceMicroservices.Data
{
	public class MongoDbService
	{
		private readonly IConfiguration _configuration;
		private readonly IMongoDatabase? _database;

		public MongoDbService(IConfiguration configuration)
		{
			_configuration = configuration;
			var settings = MongoClientSettings.FromConnectionString(_configuration.GetConnectionString("DbConnection"));
			// Set the ServerApi field of the settings object to set the version of the Stable API on the client
			settings.ServerApi = new ServerApi(ServerApiVersion.V1);
			// Create a new client and connect to the server
			var client = new MongoClient(settings);
			// Send a ping to confirm a successful connection
			try
			{
				_database = client.GetDatabase("ECommerceDatabase");
				Console.WriteLine("You successfully connected to MongoDB!");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		public IMongoDatabase? Database => _database;
	}
}

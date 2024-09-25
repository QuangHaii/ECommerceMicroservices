using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceMicroservices.Models
{
	[Serializable, BsonIgnoreExtraElements]
	public class Product
	{
		[BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
		public string productId { get; set; }
		[BsonElement("name"), BsonRepresentation(BsonType.String)]
		public string name { get; set; }
		[BsonElement("description"), BsonRepresentation(BsonType.String)]
		public string description { get; set; }
		[BsonElement("category"), BsonRepresentation(BsonType.String)]
		public string category { get; set; }
		[BsonElement("price"), BsonRepresentation(BsonType.Decimal128)]
		public decimal price { get; set; }
		[BsonElement("imageUrl"), BsonRepresentation(BsonType.String)]
		public string imageUrl { get; set; }
		[BsonElement("timestamp"), BsonRepresentation(BsonType.DateTime)]
		public DateTime timestamp { get; set; }
	}
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherAppApi.Models
{
    public class WeatherAppUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string username { get; set; }

        public string password { get; set; }

    }
}
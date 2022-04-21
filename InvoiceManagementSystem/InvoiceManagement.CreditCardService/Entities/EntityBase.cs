using MongoDB.Bson.Serialization.Attributes;

namespace InvoiceManagement.CreditCardService.Entities
{
    public abstract class EntityBase
    {
        [BsonId]
        public string Id { get; set; }
    }
}
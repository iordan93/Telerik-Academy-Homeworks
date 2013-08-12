namespace _1.DictionaryMongoDb
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class DictionaryEntry
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Word { get; set; }

        public string Translation { get; set; }
    }
}

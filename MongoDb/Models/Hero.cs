using System;
using MongoDB.Bson;

namespace MongoDB.Models
{
    public class Hero
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public int Power { get; set; }
    }
}
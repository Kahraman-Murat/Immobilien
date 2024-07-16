using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Entity.Entities
{
    public class BaseEntity
    {       
        public ObjectId Id { get; set; }
    }
}

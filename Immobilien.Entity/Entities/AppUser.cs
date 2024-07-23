using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Entity.Entities
{
    public class AppUser : IdentityUser<ObjectId>
    {
        public string NameSurname { get; set; }
    }
}

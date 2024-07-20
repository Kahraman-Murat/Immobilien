﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Entity.Entities
{
    public class Banner : BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

    }
}

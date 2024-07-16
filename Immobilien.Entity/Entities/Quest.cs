using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Entity.Entities
{
    public class Quest : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}

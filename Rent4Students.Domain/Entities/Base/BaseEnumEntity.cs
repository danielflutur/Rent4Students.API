using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent4Students.Domain.Entities.Base
{
    public record BaseEnumEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}

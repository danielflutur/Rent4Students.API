using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent4Students.Application.DTOs
{
    public class ResponseUserDTO
    {
        public Guid Id { get; set; }
        public string Role {  get; set; }
    }
}

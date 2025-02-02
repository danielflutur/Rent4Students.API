using Rent4Students.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseUserDTO> LoginByEmail(string email);
    }
}

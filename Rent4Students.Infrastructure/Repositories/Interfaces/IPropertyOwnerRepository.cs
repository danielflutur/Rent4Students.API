﻿using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces.Base;

namespace Rent4Students.Infrastructure.Repositories.Interfaces
{
    public interface IPropertyOwnerRepository : IBaseRepository<PropertyOwner>
    {
        Task<PropertyOwner> GetByEmail(string email);
    }
}

﻿using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces.Base;

namespace Rent4Students.Infrastructure.Repositories.Interfaces
{
    public interface IListingRepository : IBaseRepository<Listing>
    {
        Task<List<Listing>> GetAllNotRented();
    }
}

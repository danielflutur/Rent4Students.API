using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class PropertyOwnerRepository : BaseRepository<PropertyOwner>, IPropertyOwnerRepository
    {
        public PropertyOwnerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<PropertyOwner> GetById(Guid id)
        {
            return await _dbSet
                .Where(listing => listing.Id == id)
                .Include(listing => listing.Address)
                .Include(listing => listing.ProfilePhoto)
                .Include(listing => listing.Listings)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<PropertyOwner>> GetAll()
        {
            return await _dbSet
                .Where(listing => listing.IsDeleted == false)
                .Include(listing => listing.Address)
                .Include(listing => listing.ProfilePhoto)
                .Include(listing => listing.Listings)
                .ToListAsync();
        }
    }
}

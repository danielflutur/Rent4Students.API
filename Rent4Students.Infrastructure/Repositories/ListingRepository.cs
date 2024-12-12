using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class ListingRepository : BaseRepository<Listing>, IListingRepository
    {
        public ListingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<Listing> GetById(Guid id)
        {
            return await _dbSet
                .Where(listing => listing.Id == id)
                .Include(listing => listing.Address)
                .Include(listing => listing.Photos)
                .Include(listing => listing.Amenities)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Listing>> GetAll()
        {
            return await _dbSet
                .Include(listing => listing.Address)
                .Include(listing => listing.Photos)
                .Include(listing => listing.Amenities)
                .ToListAsync();
        }
    }
}

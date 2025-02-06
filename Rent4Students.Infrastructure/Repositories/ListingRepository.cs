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
            return await _context.Listing
                .Where(listing => listing.Id == id)
                .Include(listing => listing.Address)
                .Include(listing => listing.Photos)
                .Include(listing => listing.Amenities)
                .Include(listing => listing.RentHistory)
                    .ThenInclude(history => history.Student)
                        .ThenInclude(history => history.Roommates)
                .Include(listing => listing.RentHistory)
                    .ThenInclude(history => history.AttatchedPhoto)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Listing>> GetAll()
        {
            return await _context.Listing
                .Where(listing => listing.IsDeleted == false)
                .Include(listing => listing.Address)
                .Include(listing => listing.Photos)
                .Include(listing => listing.Amenities)
                .Include(listing => listing.RentHistory)
                    .ThenInclude(history => history.Student)
                        .ThenInclude(history => history.Roommates)
                .Include(listing => listing.RentHistory)
                    .ThenInclude(history => history.AttatchedPhoto)
                .ToListAsync();
        }

        public async Task<List<Listing>> GetAllNotRented()
        {
            return await _context.Listing
                .Where(listing => listing.IsDeleted == false && listing.IsRented == false)
                .Include(listing => listing.Address)
                .Include(listing => listing.Photos)
                .Include(listing => listing.Amenities)
                .Include(listing => listing.RentHistory)
                    .ThenInclude(history => history.Student)
                        .ThenInclude(history => history.Roommates)
                .Include(listing => listing.RentHistory)
                    .ThenInclude(history => history.AttatchedPhoto)
                .ToListAsync();
        }
    }
}

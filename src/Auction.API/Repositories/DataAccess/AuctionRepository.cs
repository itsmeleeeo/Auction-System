using Auction.API.Contracts;
using Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _dbContext;
        public AuctionRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

        public AuctionStd? GetCurrent()
        {
            var today = DateTime.Now;

            return _dbContext.Auctions.Include(a => a.Items).FirstOrDefault(a => today >= a.Starts && today <= a.Ends);
        }
    }
}

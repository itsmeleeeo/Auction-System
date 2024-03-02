using Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Entities.AuctionStd> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}

using Auction.API.Entities;

namespace Auction.API.Contracts
{
    public interface IAuctionRepository
    {
        AuctionStd? GetCurrent();
    }
}

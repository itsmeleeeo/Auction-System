using Auction.API.Contracts;
using Auction.API.Entities;
using Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.UseCase.Auctions.GetCurrent
{
    public class GetCurrentAuctionsUseCase
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentAuctionsUseCase(IAuctionRepository repository) => _repository = repository;
        public AuctionStd? Execute() => _repository.GetCurrent();
    }
}

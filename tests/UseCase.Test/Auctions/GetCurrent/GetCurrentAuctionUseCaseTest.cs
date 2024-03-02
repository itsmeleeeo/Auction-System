using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Auction.API.UseCase.Auctions.GetCurrent;
using FluentAssertions;
using Moq;
using Auction.API.Contracts;
using Auction.API.Entities;
using Bogus;
using Auction.API.Enum;

namespace UseCase.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Success()
        {
            var entity = new Faker<AuctionStd>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1, 700))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
                {
                    new Item
                    {
                        Id = f.Random.Number(1, 700),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(500, 1000),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(entity);

            var useCase = new GetCurrentAuctionsUseCase(mock.Object);

            var auction = useCase.Execute();

            auction.Should().NotBeNull();
            auction.Id.Should().Be(entity.Id);
        }
    }
}

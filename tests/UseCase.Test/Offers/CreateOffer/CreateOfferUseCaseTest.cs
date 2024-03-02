using Auction.API.Communication.Request;
using Auction.API.Contracts;
using Auction.API.Entities;
using Auction.API.Services;
using Auction.API.UseCase.Auctions.GetCurrent;
using Auction.API.UseCase.Auctions.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCase.Test.Offers.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

            var offerRepository = new Mock<IOfferRepository>();
            var loggedUser = new Mock<ILoggedUser>();
            loggedUser.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(loggedUser.Object,offerRepository.Object);

            var act = () => useCase.Execute(itemId, request);

            act.Should().NotThrow();

        }
    }
}

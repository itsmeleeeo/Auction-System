using Auction.API.Communication.Request;
using Auction.API.Filters;
using Auction.API.UseCase.Auctions.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : AuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody]RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}

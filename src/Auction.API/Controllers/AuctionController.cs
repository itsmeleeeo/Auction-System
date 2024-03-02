using Auction.API.UseCase.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    public class AuctionController : AuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Entities.AuctionStd),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionsUseCase useCase)
        {
            var result = useCase.Execute();

            if(result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}

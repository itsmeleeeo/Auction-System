namespace Auction.API.Entities
{
    public class AuctionStd
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}

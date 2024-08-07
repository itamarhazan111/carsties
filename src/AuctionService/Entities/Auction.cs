using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionService.Entities
{
    public class Auction
    {
        public Guid Id { get; set; }
        public int ReservePrice { get; set; }=0;
        public string Seller { get; set; }
        public string Winner { get; set; }
        public int? SoldAmount { get; set; } // Nullable int for sold amount
        public int? CurrentHighBid { get; set; } // Nullable int for current bid
        public DateTime CreatedAt { get; set; }=DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }=DateTime.UtcNow;
        public DateTime AuctionEnd { get; set; }
        public Status Status { get; set; }
        public Item Item { get; set; }

        public bool HasReservePrice()=> this.ReservePrice > 0;
    }
}
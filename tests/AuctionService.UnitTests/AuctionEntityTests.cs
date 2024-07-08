using System.Data.Common;
using AuctionService.Entities;
namespace AuctionService.UnitTests;

public class AuctionEntityTests
{
    [Fact]
    public void HasReservePrice_GtZero_True()
    {
        var Auction = new Auction { Id=Guid.NewGuid(), ReservePrice=10};
        var result = Auction.HasReservePrice();
        Assert.True(result);
    }
    [Fact]
    public void HasReservePrice_IsZero_False()
    {
        var Auction = new Auction { Id=Guid.NewGuid(), ReservePrice=0};
        var result = Auction.HasReservePrice();
        Assert.False(result);
    }
}
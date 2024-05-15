using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.Data.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _context;
        private readonly IMapper _mapper;

        public AuctionRepository(AuctionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionDto> GetAuctionByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Auction> GetAuctionEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuctionDto>> GetAuctionsAsync(string date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
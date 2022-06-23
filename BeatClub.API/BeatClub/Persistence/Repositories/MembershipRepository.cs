using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.BeatClub.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.BeatClub.Persistence.Repositories
{
    public class MembershipRepository : BaseRepository, IMembershipRepository
    {
        public MembershipRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Membership>> ListAsync()
        {
            return await _context.Memberships.ToListAsync();
        }

        public async Task AddAsync(Membership membership)
        {
            await _context.Memberships.AddAsync(membership);
        }

        public async Task<Membership> FindByIdAsync(int membershipId)
        {
            return await _context.Memberships.FindAsync(membershipId);
        }

        public void Update(Membership membership)
        {
            _context.Memberships.Update(membership);
        }

        public void Remove(Membership membership)
        {
            _context.Memberships.Update(membership);
        }
    }
}
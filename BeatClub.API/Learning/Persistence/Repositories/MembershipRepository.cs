using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
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
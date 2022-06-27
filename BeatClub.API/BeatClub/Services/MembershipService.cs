using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Domain.Services.Communication;
using BeatClub.API.Shared.Domain.Repositories;

namespace BeatClub.API.BeatClub.Services
{
    public class MembershipService : IMembershipService
    {

        private readonly IMembershipRepository _membershipRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MembershipService(IMembershipRepository membershipRepository, IUnitOfWork unitOfWork)
        {
            _membershipRepository = membershipRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Membership>> ListAsync()
        {
            return await _membershipRepository.ListAsync();
        }

        public async Task<MembershipResponse> SaveAsync(Membership membership)
        {
            try
            {
                await _membershipRepository.AddAsync(membership);
                await _unitOfWork.CompleteAsync();

                return new MembershipResponse(membership);
            }
            catch (Exception e)
            {
                return new MembershipResponse($"An error occurred while saving the membership: {e.Message}");
            }
        }

        public async Task<MembershipResponse> UpdateAsync(int id, Membership membership)
        {
            var existingMembership = await _membershipRepository.FindByIdAsync(id);

            if (existingMembership == null)
                return new MembershipResponse("Membership not found.");

            existingMembership.Title = membership.Title;
            existingMembership.Price = membership.Price;
            existingMembership.Feature = membership.Feature;
            existingMembership.Description = membership.Description;
            existingMembership.UrlToImage = membership.UrlToImage;
            

            try
            {
                _membershipRepository.Update(existingMembership);
                await _unitOfWork.CompleteAsync();

                return new MembershipResponse(existingMembership);
            }
            catch (Exception e)
            {
                return new MembershipResponse($"An error occurred while update the membership: {e.Message}");
            }

        }

        public async Task<MembershipResponse> DeleteAsync(int id)
        {
            var existingMembership = await _membershipRepository.FindByIdAsync(id);

            if (existingMembership == null)
                return new MembershipResponse("Membership not found.");

            try
            {
                _membershipRepository.Remove(existingMembership);
                await _unitOfWork.CompleteAsync();

                return new MembershipResponse(existingMembership);
            }
            catch (Exception e)
            {
                return new MembershipResponse($"An error occurred while deleting the membership: {e.Message}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        
        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<IEnumerable<Publication>> ListByUserIdAsync(int publicationId)
        {
            return await _publicationRepository.FindByUserIdAsync(publicationId);
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(publication.UserId);

            if (existingUser == null)
                return new PublicationResponse("Invalid User");
            
            // Valid Content

            var existingPublicationWithName = await _publicationRepository.FindByTitleAsync(publication.Title);

            if (existingPublicationWithName != null)
                return new PublicationResponse("Publication Title already exists.");

            try
            {
                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(publication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occurred while saving the publication: {e.Message}");
            }

        }

        public async Task<PublicationResponse> UpdateAsync(int publicationId, Publication publication)
        {
            var existingPublication = await _publicationRepository.FindByIdAsync(publicationId);
            
            // Validate SongList Id

            if (existingPublication == null)
                return new PublicationResponse("Publication not found.");
            
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(publication.UserId);

            if (existingUser == null)
                return new PublicationResponse("Invalid User");
            
            // Valid Name

            var existingPublicationWithTitle = await _publicationRepository.FindByTitleAsync(publication.Title);

            if (existingPublicationWithTitle != null && existingPublicationWithTitle.Id != existingPublication.Id)
                return new PublicationResponse("Publication Title already exists.");

            existingPublication.Title = publication.Title;
            existingPublication.Description = publication.Description;
            //existingMessage.CreatAt = message.CreatAt;
            existingPublication.UserId = publication.UserId;

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);

            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occurred while update the publication: {e.Message}");
            }
        }

        public async Task<PublicationResponse> DeleteAsync(int publicationId)
        {
            var existingPublication = await _publicationRepository.FindByIdAsync(publicationId);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found.");

            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occurred while deleting the publication: {e.Message}");
            }
        }
    }
}
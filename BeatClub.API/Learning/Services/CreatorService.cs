using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly ICreatorRepository _creatorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatorService(ICreatorRepository creatorRepository, IUnitOfWork unitOfWork)
        {
            _creatorRepository = creatorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Creator>> ListAsync()
        {
            return await _creatorRepository.ListAsync();
        }

        public async Task<CreatorResponse> SaveAsync(Creator creator)
        {
            try
            {
                await _creatorRepository.AddAsync(creator);
                await _unitOfWork.CompleteAsync();

                return new CreatorResponse(creator);
            }
            catch (Exception e)
            {
                return new CreatorResponse($"An error occurred while saving the creator: {e.Message}");
            }
        }

        public async Task<CreatorResponse> UpdateAsync(int id, Creator creator)
        {
            var existingCreator = await _creatorRepository.FindByIdAsync(id);

            if (existingCreator == null)
                return new CreatorResponse("User not found.");

            existingCreator.Name = creator.Name;
           

            try
            {
                _creatorRepository.Update(existingCreator);
                await _unitOfWork.CompleteAsync();

                return new CreatorResponse(existingCreator);
            }
            catch (Exception e)
            {
                return new CreatorResponse($"An error occurred while update the creator: {e.Message}");
            }

        }

        public async Task<CreatorResponse> DeleteAsync(int id)
        {
            var existingCreator = await _creatorRepository.FindByIdAsync(id);

            if (existingCreator == null)
                return new CreatorResponse("Creator not found.");

            try
            {
                _creatorRepository.Remove(existingCreator);
                await _unitOfWork.CompleteAsync();

                return new CreatorResponse(existingCreator);
            }
            catch (Exception e)
            {
                return new CreatorResponse($"An error occurred while deleting the creator: {e.Message}");
            }
        }
    } 
}


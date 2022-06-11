using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreatorRepository _creatorRepository;

        public TrackService(ITrackRepository trackRepository, IUnitOfWork unitOfWork, ICreatorRepository creatorRepository)
        {
            _trackRepository = trackRepository;
            _unitOfWork = unitOfWork;
            _creatorRepository = creatorRepository;
        }

        public async Task<IEnumerable<Track>> ListAsync()
            {
                return await _trackRepository.ListAsync();
            }

            public  async Task<IEnumerable<Track>> ListByCreatorIdAsync(int creatorId)
            {
                return await _trackRepository.FindByCreatorIdAsync(creatorId);
            }

            public async Task<TrackResponse> SaveAsync(Track track)
            {
                // Validate User Id

                var existingCreator = _creatorRepository.FindByIdAsync(track.CreatorId);

                if (existingCreator == null)
                    return new TrackResponse("Invalid Creator");
                
                // Valid Content

                var existingTrackWithContent = await _trackRepository.FindByContentAsync(track.Description);

                if (existingTrackWithContent != null)
                    return new TrackResponse("Message Content already exists.");

                try
                {
                    await _trackRepository.AddAsync(track);
                    await _unitOfWork.CompleteAsync();

                    return new TrackResponse(track);
                }
                catch (Exception e)
                {
                    return new TrackResponse($"An error occurred while saving the track: {e.Message}");
                }

            }

            public async Task<TrackResponse> UpdateAsync(int trackId, Track track)
            {
                var existingTrack = await _trackRepository.FindByIdAsync(trackId);
                
                // Validate Message Id

                if (existingTrack == null)
                    return new TrackResponse("Message not found.");
                
                // Validate User Id

                var existingCreator = _creatorRepository.FindByIdAsync(track.CreatorId);

                if (existingCreator == null)
                    return new TrackResponse("Invalid User");
                
                // Valid Content

                var existingTrackWithContent = await _trackRepository.FindByContentAsync(track.Description);

                if (existingTrackWithContent != null && existingTrackWithContent.Id != existingTrack.Id)
                    return new TrackResponse("Track Content already exists.");

                existingTrack.Description = track.Description;
                //existingMessage.CreatAt = message.CreatAt;
                existingTrack.CreatorId = track.CreatorId;

                try
                {
                    _trackRepository.Update(existingTrack);
                    await _unitOfWork.CompleteAsync();

                    return new TrackResponse(existingTrack);

                }
                catch (Exception e)
                {
                    return new TrackResponse($"An error occurred while update the track: {e.Message}");
                }

            }

            public async Task<TrackResponse> DeleteAsync(int trackId)
            {
                var existingTrack = await _trackRepository.FindByIdAsync(trackId);

                if (existingTrack == null)
                    return new TrackResponse("Track not found.");

                try
                {
                    _trackRepository.Remove(existingTrack);
                    await _unitOfWork.CompleteAsync();

                    return new TrackResponse(existingTrack);
                }
                catch (Exception e)
                {
                    return new TrackResponse($"An error occurred while deleting the track: {e.Message}");
                }
                
            }
    }
}


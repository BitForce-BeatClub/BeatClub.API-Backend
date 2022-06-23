using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Services
{
    public class TrackService: ITrackService
    {

        private readonly ITrackRepository _trackRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public TrackService(IUnitOfWork unitOfWork, IUserRepository userRepository, ITrackRepository trackRepository )
        {
            _trackRepository = trackRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }


        public async Task<IEnumerable<Track>> ListAsync()
        {
            return await _trackRepository.ListAsync();
        }

        public async Task<IEnumerable<Track>> ListByUserIdAsync(int userId)
        {
            return await _trackRepository.FindByUserIdAsync(userId);
        }

        public async Task<TrackResponse> SaveAsync(Track track)
        {
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(track.UserId);

            if (existingUser == null)
                return new TrackResponse("Invalid User");
            
            // Valid Title

            var existingTrackWithTitle = await _trackRepository.FindByTitleAsync(track.Title);

            if (existingTrackWithTitle != null)
                return new TrackResponse("Track Title already exists.");

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
            var existingtrack = await _trackRepository.FindByIdAsync(trackId);
            
            // Validate Message Id

            if (existingtrack == null)
                return new TrackResponse("Track not found.");
            
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(track.UserId);

            if (existingUser == null)
                return new TrackResponse("Invalid User");
            
            // Valid Content

            var existingTrackWithTitle = await _trackRepository.FindByTitleAsync(track.Title);

            if (existingTrackWithTitle != null && existingTrackWithTitle.Id != existingtrack.Id)
                return new TrackResponse("Track Title already exists.");

            existingtrack.Title = track.Title;
            existingtrack.Privacy = track.Privacy;
            existingtrack.Artist = track.Artist;
            existingtrack.Cover = track.Cover;
            existingtrack.Source = track.Source;
            existingtrack.UserId = track.UserId;

            try
            {
                _trackRepository.Update(existingtrack);
                await _unitOfWork.CompleteAsync();

                return new TrackResponse(existingtrack);

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
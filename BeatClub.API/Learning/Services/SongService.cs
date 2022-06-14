using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Services
{
    public class SongService: ISongService
    {

        private readonly ISongRepository _songRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public SongService(ISongRepository songRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _songRepository = songRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }


        public async Task<IEnumerable<Song>> ListAsync()
        {
            return await _songRepository.ListAsync();
        }

        public async Task<IEnumerable<Song>> ListByUserIdAsync(int userId)
        {
            return await _songRepository.FindByUserIdAsync(userId);
        }

        public async Task<SongResponse> SaveAsync(Song song)
        {
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(song.UserId);

            if (existingUser == null)
                return new SongResponse("Invalid User");
            
            // Valid Title

            var existingSongWithTitle = await _songRepository.FindByTitleAsync(song.Title);

            if (existingSongWithTitle != null)
                return new SongResponse("Song Title already exists.");

            try
            {
                await _songRepository.AddAsync(song);
                await _unitOfWork.CompleteAsync();

                return new SongResponse(song);
            }
            catch (Exception e)
            {
                return new SongResponse($"An error occurred while saving the song: {e.Message}");
            }
        }

        public async Task<SongResponse> UpdateAsync(int songId, Song song)
        {
            var existingSong = await _songRepository.FindByIdAsync(songId);
            
            // Validate Message Id

            if (existingSong == null)
                return new SongResponse("Song not found.");
            
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(song.UserId);

            if (existingUser == null)
                return new SongResponse("Invalid User");
            
            // Valid Content

            var existingSongWithTitle = await _songRepository.FindByTitleAsync(song.Title);

            if (existingSongWithTitle != null && existingSongWithTitle.Id != existingSong.Id)
                return new SongResponse("Song Title already exists.");

            existingSong.Title = song.Title;
            existingSong.Description = song.Description;
            existingSong.UrlToImage = song.UrlToImage;
            existingSong.UserId = song.UserId;

            try
            {
                _songRepository.Update(existingSong);
                await _unitOfWork.CompleteAsync();

                return new SongResponse(existingSong);

            }
            catch (Exception e)
            {
                return new SongResponse($"An error occurred while update the song: {e.Message}");
            }
        }

        public async Task<SongResponse> DeleteAsync(int songId)
        {
            var existingSong = await _songRepository.FindByIdAsync(songId);

            if (existingSong == null)
                return new SongResponse("Song not found.");

            try
            {
                _songRepository.Remove(existingSong);
                await _unitOfWork.CompleteAsync();

                return new SongResponse(existingSong);
            }
            catch (Exception e)
            {
                return new SongResponse($"An error occurred while deleting the song: {e.Message}");
            }
        }
    }
}
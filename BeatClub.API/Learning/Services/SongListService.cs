using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Domain.Services.Communication;
using BeatClub.API.Learning.Persistence.Repositories;

namespace BeatClub.API.Learning.Services
{
    public class SongListService : ISongListService
    {

        private readonly ISongListRepository _songListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public SongListService(ISongListRepository songListRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _songListRepository = songListRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<SongList>> ListAsync()
        {
            return await _songListRepository.ListAsync();
        }

        public async Task<IEnumerable<SongList>> ListByUserIdAsync(int userId)
        {
            return await _songListRepository.FindByUserIdAsync(userId);
        }

        public async Task<SongListResponse> SaveAsync(SongList songList)
        {
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(songList.UserId);

            if (existingUser == null)
                return new SongListResponse("Invalid User");
            
            // Valid Content

            var existingSongListWithName = await _songListRepository.FindByNameAsync(songList.Name);

            if (existingSongListWithName != null)
                return new SongListResponse("SongList Name already exists.");

            try
            {
                await _songListRepository.AddAsync(songList);
                await _unitOfWork.CompleteAsync();

                return new SongListResponse(songList);
            }
            catch (Exception e)
            {
                return new SongListResponse($"An error occurred while saving the songList: {e.Message}");
            }

        }

        public async Task<SongListResponse> UpdateAsync(int sonListId, SongList songList)
        {
            var existingSongList = await _songListRepository.FindByIdAsync(sonListId);
            
            // Validate SongList Id

            if (existingSongList == null)
                return new SongListResponse("SongList not found.");
            
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(songList.UserId);

            if (existingUser == null)
                return new SongListResponse("Invalid User");
            
            // Valid Name

            var existingSongListWithName = await _songListRepository.FindByNameAsync(songList.Name);

            if (existingSongListWithName != null && existingSongListWithName.Id != existingSongList.Id)
                return new SongListResponse("SongList Name already exists.");

            existingSongList.Name = songList.Name;
            existingSongList.Description = songList.Description;
            //existingMessage.CreatAt = message.CreatAt;
            existingSongList.UserId = songList.UserId;

            try
            {
                _songListRepository.Update(existingSongList);
                await _unitOfWork.CompleteAsync();

                return new SongListResponse(existingSongList);

            }
            catch (Exception e)
            {
                return new SongListResponse($"An error occurred while update the songList: {e.Message}");
            }
        }

        public async Task<SongListResponse> DeleteAsync(int sonListId)
        {
            var existingSongList = await _songListRepository.FindByIdAsync(sonListId);

            if (existingSongList == null)
                return new SongListResponse("SongList not found.");

            try
            {
                _songListRepository.Remove(existingSongList);
                await _unitOfWork.CompleteAsync();

                return new SongListResponse(existingSongList);
            }
            catch (Exception e)
            {
                return new SongListResponse($"An error occurred while deleting the songList: {e.Message}");
            }

        }
    }
}
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
        private readonly ISongListRepository _songListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SongService(ISongRepository songRepository, ISongListRepository songListRepository, IUnitOfWork unitOfWork)
        {
            _songRepository = songRepository;
            _songListRepository = songListRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Song>> ListAsync()
        {
            return await _songRepository.ListAsync();
        }

        public async Task<IEnumerable<Song>> ListBySongListIdAsync(int songListId)
        {
            return await _songRepository.FindBySongListIdAsync(songListId);
        }

        public async Task<SongResponse> SaveAsync(Song song)
        {
            // Validate User Id

            var existingSongList = _songListRepository.FindByIdAsync(song.SongListId);

            if (existingSongList == null)
                return new SongResponse("Invalid SongList");
            
            // Valid Content

            var existingSongWithName = await _songRepository.FindByNameAsync(song.Name);

            if (existingSongWithName != null)
                return new SongResponse("Song Name already exists.");

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

            var existingSongList = _songListRepository.FindByIdAsync(song.SongListId);

            if (existingSongList == null)
                return new SongResponse("Invalid SongList");
            
            // Valid Content

            var existingSongWithName = await _songRepository.FindByNameAsync(song.Name);

            if (existingSongWithName != null && existingSongWithName.Id != existingSong.Id)
                return new SongResponse("Song Name already exists.");

            existingSong.Name = song.Name;
            existingSong.Gender = song.Gender;
            existingSong.Description = song.Description;
            existingSong.SongListId = song.SongListId;

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
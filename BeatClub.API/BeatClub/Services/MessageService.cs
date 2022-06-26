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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _messageRepository.ListAsync();
        }

        public async Task<IEnumerable<Message>> ListByUserProducerIdAsync(string userProId)
        {
            return await _messageRepository.FindByUserProducerIdAsync(userProId);
        }

        public async Task<IEnumerable<Message>> ListByUserArtistIdAsync(string userArtId)
        {
            return await _messageRepository.FindByUserArtistIdAsync(userArtId);
        }

        public async Task<MessageResponse> SaveAsync(Message message)
        {
            // Validate User Id

            var existingUserArtist = _userRepository.FindByIdAsync(message.UserArtistId);

            if (existingUserArtist == null)
                return new MessageResponse("Invalid UserArtist");
            
            // Validate User Id

            var existingUserProducer = _userRepository.FindByIdAsync(message.UserProducerId);

            if (existingUserProducer == null)
                return new MessageResponse("Invalid UserProducer");
            
            // Valid Content

            var existingMessageWithContent = await _messageRepository.FindByContentAsync(message.Content);

            if (existingMessageWithContent != null)
                return new MessageResponse("Message Content already exists.");

            try
            {
                await _messageRepository.AddAsync(message);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(message);
            }
            catch (Exception e)
            {
                return new MessageResponse($"An error occurred while saving the message: {e.Message}");
            }

        }

        public async Task<MessageResponse> UpdateAsync(int messageId, Message message)
        {
            var existingMessage = await _messageRepository.FindByIdAsync(messageId);
            
            // Validate Message Id

            if (existingMessage == null)
                return new MessageResponse("Message not found.");
            
            // Validate User Id

            var existingUserArtist = _userRepository.FindByIdAsync(message.UserArtistId);

            if (existingUserArtist == null)
                return new MessageResponse("Invalid UserArtist");
            
            // Validate User Id

            var existingUserProducer = _userRepository.FindByIdAsync(message.UserProducerId);

            if (existingUserProducer == null)
                return new MessageResponse("Invalid UserProducer");
            
            // Valid Content

            var existingMessageWithContent = await _messageRepository.FindByContentAsync(message.Content);

            if (existingMessageWithContent != null && existingMessageWithContent.Id != existingMessage.Id)
                return new MessageResponse("Message Content already exists.");

            existingMessage.Content = message.Content;
            //existingMessage.CreatAt = message.CreatAt;
            existingMessage.UserArtistId = message.UserArtistId;
            existingMessage.UserProducerId = message.UserProducerId;
            existingMessage.CreateAt = message.CreateAt;

            try
            {
                _messageRepository.Update(existingMessage);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(existingMessage);

            }
            catch (Exception e)
            {
                return new MessageResponse($"An error occurred while update the message: {e.Message}");
            }

        }

        public async Task<MessageResponse> DeleteAsync(int messageId)
        {
            var existingMessage = await _messageRepository.FindByIdAsync(messageId);

            if (existingMessage == null)
                return new MessageResponse("Message not found.");

            try
            {
                _messageRepository.Remove(existingMessage);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(existingMessage);
            }
            catch (Exception e)
            {
                return new MessageResponse($"An error occurred while deleting the message: {e.Message}");
            }
            
        }
    }
}
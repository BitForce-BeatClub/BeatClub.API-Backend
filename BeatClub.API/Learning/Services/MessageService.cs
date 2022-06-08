using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Services
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

        public  async Task<IEnumerable<Message>> ListByUserIdAsync(int userId)
        {
            return await _messageRepository.FindByUserIdAsync(userId);
        }

        public async Task<MessageResponse> SaveAsync(Message message)
        {
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(message.UserId);

            if (existingUser == null)
                return new MessageResponse("Invalid User");
            
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

            var existingUser = _userRepository.FindByIdAsync(message.UserId);

            if (existingUser == null)
                return new MessageResponse("Invalid User");
            
            // Valid Content

            var existingMessageWithContent = await _messageRepository.FindByContentAsync(message.Content);

            if (existingMessageWithContent != null && existingMessageWithContent.Id != existingMessage.Id)
                return new MessageResponse("Message Content already exists.");

            existingMessage.Content = message.Content;
            //existingMessage.CreatAt = message.CreatAt;
            existingMessage.UserId = message.UserId;

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
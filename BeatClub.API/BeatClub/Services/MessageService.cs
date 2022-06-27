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

        public async Task<IEnumerable<Message>> ListByUserIdFromAsync(string userIdFrom)
        {
            return await _messageRepository.FindByUserIdFromAsync(userIdFrom);
        }

        public async Task<IEnumerable<Message>> ListByUserIdToAsync(string userIdTo)
        {
            return await _messageRepository.FindByUserIdToAsync(userIdTo);
        }

        public async Task<MessageResponse> SaveAsync(Message message)
        {
            // Validate User Id

            var existingUserIdFrom = _userRepository.FindByIdAsync(message.userIdFrom);

            if (existingUserIdFrom == null)
                return new MessageResponse("Invalid UserIdFrom");
            
            // Validate User Id

            var existingUserIdTo = _userRepository.FindByIdAsync(message.userIdTo);

            if (existingUserIdTo == null)
                return new MessageResponse("Invalid UserIdTo");
            
            // Valid Content

            var existingMessageWithContent = await _messageRepository.FindByContentAsync(message.content);

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

            var existingUserIdFrom = _userRepository.FindByIdAsync(message.userIdFrom);

            if (existingUserIdFrom == null)
                return new MessageResponse("Invalid UserIdFrom");
            
            // Validate User Id

            var existingUserIdTo = _userRepository.FindByIdAsync(message.userIdTo);

            if (existingUserIdTo == null)
                return new MessageResponse("Invalid UserIdTo");
            
            // Valid Content

            var existingMessageWithContent = await _messageRepository.FindByContentAsync(message.content);

            if (existingMessageWithContent != null && existingMessageWithContent.id != existingMessage.id)
                return new MessageResponse("Message Content already exists.");

            existingMessage.content = message.content;
            existingMessage.userIdTo = message.userIdTo;
            existingMessage.userIdFrom = message.userIdFrom;
            existingMessage.messageDate = message.messageDate;

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
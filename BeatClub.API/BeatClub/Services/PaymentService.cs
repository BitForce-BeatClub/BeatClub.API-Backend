using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        
        public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _paymentRepository.ListAsync();
        }

        public async Task<IEnumerable<Payment>> ListByUserIdAsync(int userId)
        {
            return await _paymentRepository.FindByUserIdAsync(userId);
        }

        public async Task<PaymentResponse> SaveAsync(Payment payment)
        {
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(payment.UserId);

            if (existingUser == null)
                return new PaymentResponse("Invalid User");
            

            try
            {
                await _paymentRepository.AddAsync(payment);
                await _unitOfWork.CompleteAsync();

                return new PaymentResponse(payment);
            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error occurred while saving the payment: {e.Message}");
            }
        }

        public async Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment)
        {
            var existingPayment = await _paymentRepository.FindByIdAsync(paymentId);
            
            // Validate SongList Id

            if (existingPayment == null)
                return new PaymentResponse("Publication not found.");
            
            // Validate User Id

            var existingUser = _userRepository.FindByIdAsync(payment.UserId);

            if (existingUser == null)
                return new PaymentResponse("Invalid User");
            
            // Valid Name

            existingPayment.Amount = payment.Amount;
            existingPayment.Description = payment.Description;
            //existingMessage.CreatAt = message.CreatAt;
            existingPayment.PayMethod = payment.PayMethod;
            existingPayment.UserId = payment.UserId;

            try
            {
                _paymentRepository.Update(existingPayment);
                await _unitOfWork.CompleteAsync();

                return new PaymentResponse(existingPayment);

            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error occurred while update the payment: {e.Message}");
            }
        }

        public async Task<PaymentResponse> DeleteAsync(int paymentId)
        {
            var existingPayment = await _paymentRepository.FindByIdAsync(paymentId);

            if (existingPayment == null)
                return new PaymentResponse("Publication not found.");

            try
            {
                _paymentRepository.Remove(existingPayment);
                await _unitOfWork.CompleteAsync();

                return new PaymentResponse(existingPayment);
            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error occurred while deleting the payment: {e.Message}");
            }
        }
    }
}
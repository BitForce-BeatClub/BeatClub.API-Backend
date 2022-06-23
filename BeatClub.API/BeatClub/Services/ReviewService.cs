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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IUserRepository userRepository, IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _reviewRepository.ListAsync();
        }

        public async Task<IEnumerable<Review>> ListByUserProducerIdAsync(int userProId)
        {
            return await _reviewRepository.FindByUserProducerIdAsync(userProId);
        }

        public async Task<IEnumerable<Review>> ListByUserArtistIdAsync(int userArtId)
        {
            return await _reviewRepository.FindByUserArtistIdAsync(userArtId);
        }

        public async Task<ReviewResponse> SaveAsync(Review review)
        {
            // Validate User Id

            var existingUserArtist = _userRepository.FindByIdAsync(review.UserArtistId);

            if (existingUserArtist == null)
                return new ReviewResponse("Invalid UserArtist");
            
            // Validate User Id

            var existingUserProducer = _userRepository.FindByIdAsync(review.UserProducerId);

            if (existingUserProducer == null)
                return new ReviewResponse("Invalid UserProducer");

            try
            {
                await _reviewRepository.AddAsync(review);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(review);
            }
            catch (Exception e)
            {
                return new ReviewResponse($"An error occurred while saving the review: {e.Message}");
            }
        }

        public async Task<ReviewResponse> UpdateAsync(int reviewId, Review review)
        {
            var existingReview = await _reviewRepository.FindByIdAsync(reviewId);

            if (existingReview == null)
                return new ReviewResponse("Review not found.");
            
            // Validate User Id

            var existingUserArtist = _userRepository.FindByIdAsync(review.UserArtistId);

            if (existingUserArtist == null)
                return new ReviewResponse("Invalid UserArtist");
            
            // Validate User Id

            var existingUserProducer = _userRepository.FindByIdAsync(review.UserProducerId);

            if (existingUserProducer == null)
                return new ReviewResponse("Invalid UserProducer");
            
            

            existingReview.Qualification = review.Qualification;
            existingReview.Description = review.Description;
            existingReview.UserArtistId = review.UserArtistId;
            existingReview.UserProducerId = review.UserProducerId;
            existingReview.CreateAt = review.CreateAt;
            
            try
            {
                _reviewRepository.Update(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);

            }
            catch (Exception e)
            {
                return new ReviewResponse($"An error occurred while update the review: {e.Message}");
            }
        }

        public async Task<ReviewResponse> DeleteAsync(int reviewId)
        {
            var existingReview = await _reviewRepository.FindByIdAsync(reviewId);

            if (existingReview == null)
                return new ReviewResponse("Review not found.");

            try
            {
                _reviewRepository.Remove(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception e)
            {
                return new ReviewResponse($"An error occurred while deleting the review: {e.Message}");
            }
        }
    }
}
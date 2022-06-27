﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Services.Communication;
using BeatClub.API.Security.Authorization.Handlers.Interfaces;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Domain.Repositories;
using BeatClub.API.Security.Domain.Services;
using BeatClub.API.Security.Domain.Services.Communication;
using BeatClub.API.Security.Exceptions;
using BeatClub.API.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using BCryptNet=BCrypt.Net.BCrypt;

namespace BeatClub.API.Security.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IJwtHandler _jwtHandler;
        
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }
        
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.FindByNicknameAsync(request.Nickname);
            Console.WriteLine($"Request: {request.Nickname},{request.Password}");
            Console.WriteLine($"User: {user.Id},{user.Firstname},{user.Lastname},{user.Nickname},{user.Email},{user.Usertype},{user.Location},{user.UrlToImage},{user.Description},{user.PasswordHash}");
            
            // Perform validation
            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
            {
                Console.WriteLine("Authentication Error");
                throw new AppException("Nickname or password is incorrect");
            }
            
            Console.WriteLine("Authorization successful. About to generate token");
            
            //Authorization is successful

            var response = _mapper.Map<AuthenticateResponse>(user);
            
            //Token is generated
            Console.WriteLine($"Response: {response.Id},{response.Firstname},{response.Lastname},{response.Nickname},{response.Location},{response.Email},{response.Usertype},{response.Description},{response.UrlToImage}");
            response.Token = _jwtHandler.GenerateToken(user);
            //
            Console.WriteLine($"Generated token is {response.Token}");
            return response;

        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            // Validate
            if (_userRepository.ExistByNickname(request.Nickname))
                throw new AppException($"Nickname '{request.Nickname}' is already taken.");
         
            // Map request to user entity
            var user = _mapper.Map<User>(request);
            
            // Hash password
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            
            // Save User
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }

        }

        public async Task UpdateAsync(int id, UpdateRequest request)
        {
            var user = GetById(id);
            
            // Validate
            var userWithNickname = await _userRepository.FindByNicknameAsync(request.Nickname);

            if (userWithNickname != null && userWithNickname.Id != user.Id)
                throw new AppException($"Nickname '{request.Nickname}' is already taken");

            // hash Password if it was entered
            if (!string.IsNullOrEmpty(request.Password))
                user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Map request to entity 
            _mapper.Map(request, user);
            
            // Save User
            try
            {
                _userRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = GetById(id);

            try
            {
                _userRepository.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");

            }
        }
        
        //Method Functions

        private User GetById(int id)
        {
            var user = _userRepository.FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        
    }
}
using System;
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
            Console.WriteLine($"User: {user.Id},{user.Firstname},{user.Lastname},{user.Nickname},{user.TypeUser},{user.Result},{user.Trend},{user.CreateAt},{user.UrlToImage},{user.PasswordHash}");
            
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
            Console.WriteLine($"Response: {response.Id},{response.Firstname},{response.Lastname},{response.Nickname},{response.TypeUser},{response.Result},{response.Trend},{response.CreateAt},{response.UrlToImage}");
            response.Token = _jwtHandler.GenerateToken(user);
            //
            Console.WriteLine($"Generated token is {response.Token}");
            return response;

        }

        public Task<IEnumerable<User>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, UpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
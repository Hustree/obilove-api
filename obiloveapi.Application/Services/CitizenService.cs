// obiloveapi.Application/Services/UserService.cs
using System.Threading.Tasks;
using obiloveapi.Application.DTOs;
using obiloveapi.Application.DTOs.User;
using obiloveapi.Application.Interfaces;
using obiloveapi.Domain.Entities;
using obiloveapi.Domain.Enums;
using AutoMapper;
using System.Collections.Generic;

namespace obiloveapi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> CreateUserAsync(UserCreateRequest request)
        {
            // Map DTO to domain entity
            var user = _mapper.Map<User>(request);
            // Set the default status as Pending upon registration.
            user.Status = UserStatus.Pending;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new ApiResponse<int> { Data = user.UserId };
        }

        public async Task<ApiResponse<UserResponse>> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new ApiResponse<UserResponse>
                {
                    Success = false,
                    Errors = new Dictionary<string, string[]>
                    {
                        { "User", new [] { "User not found" } }
                    }
                };
            }

            // Map domain entity to response DTO.
            var response = _mapper.Map<UserResponse>(user);

            return new ApiResponse<UserResponse> { Data = response };
        }

        public async Task<ApiResponse<bool>> UpdateUserAsync(UserUpdateRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Errors = new Dictionary<string, string[]>
                    {
                        { "User", new [] { "User not found" } }
                    }
                };
            }

            // Map update DTO onto the existing domain entity.
            // This updates properties while leaving unmodified fields intact.
            _mapper.Map(request, user);

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            return new ApiResponse<bool> { Data = true };
        }

        public async Task<ApiResponse<bool>> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Errors = new Dictionary<string, string[]>
                    {
                        { "User", new [] { "User not found" } }
                    }
                };
            }

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();

            return new ApiResponse<bool> { Data = true };
        }
    }
}

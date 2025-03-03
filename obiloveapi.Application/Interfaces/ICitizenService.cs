// obiloveapi.Application/Interfaces/IUserService.cs
using System.Threading.Tasks;
using obiloveapi.Application.DTOs;
using obiloveapi.Application.DTOs.User;

namespace obiloveapi.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<int>> CreateUserAsync(UserCreateRequest request);
        Task<ApiResponse<UserResponse>> GetUserByIdAsync(int userId);
        Task<ApiResponse<bool>> UpdateUserAsync(UserUpdateRequest request);
        Task<ApiResponse<bool>> DeleteUserAsync(int userId);
    }
}

// obiloveapi.Application/Interfaces/ICitizenService.cs
using System.Threading.Tasks;
using obiloveapi.Application.DTOs;
using obiloveapi.Application.DTOs.Citizen;

namespace obiloveapi.Application.Interfaces
{
    public interface ICitizenService
    {
        Task<ApiResponse<int>> CreateCitizenAsync(CitizenCreateRequest request);
        Task<ApiResponse<CitizenResponse>> GetCitizenByIdAsync(int citizenId);
        Task<ApiResponse<bool>> UpdateCitizenAsync(CitizenUpdateRequest request);
        Task<ApiResponse<bool>> DeleteCitizenAsync(int citizenId);
    }
}

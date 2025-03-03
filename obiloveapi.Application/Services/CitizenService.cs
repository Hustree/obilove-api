// obiloveapi.Application/Services/CitizenService.cs
using System.Threading.Tasks;
using obiloveapi.Application.DTOs;
using obiloveapi.Application.DTOs.Citizen;
using obiloveapi.Application.Interfaces;
using obiloveapi.Domain.Entities;
using obiloveapi.Domain.Enums;
using AutoMapper;
using System.Collections.Generic;

namespace obiloveapi.Application.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;

        public CitizenService(ICitizenRepository citizenRepository, IMapper mapper)
        {
            _citizenRepository = citizenRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> CreateCitizenAsync(CitizenCreateRequest request)
        {
            // Map DTO to domain entity
            var citizen = _mapper.Map<Citizen>(request);
            // Set the default status as Pending upon registration.
            citizen.Status = CitizenStatus.Pending;

            await _citizenRepository.AddAsync(citizen);
            await _citizenRepository.SaveChangesAsync();

            return new ApiResponse<int> { Data = citizen.CitizenId };
        }

        public async Task<ApiResponse<CitizenResponse>> GetCitizenByIdAsync(int citizenId)
        {
            var citizen = await _citizenRepository.GetByIdAsync(citizenId);
            if (citizen == null)
            {
                return new ApiResponse<CitizenResponse>
                {
                    Success = false,
                    Errors = new Dictionary<string, string[]>
                    {
                        { "Citizen", new [] { "Citizen not found" } }
                    }
                };
            }

            // Map domain entity to response DTO.
            var response = _mapper.Map<CitizenResponse>(citizen);

            return new ApiResponse<CitizenResponse> { Data = response };
        }

        public async Task<ApiResponse<bool>> UpdateCitizenAsync(CitizenUpdateRequest request)
        {
            var citizen = await _citizenRepository.GetByIdAsync(request.CitizenId);
            if (citizen == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Errors = new Dictionary<string, string[]>
                    {
                        { "Citizen", new [] { "Citizen not found" } }
                    }
                };
            }

            // Map update DTO onto the existing domain entity.
            // This updates properties while leaving unmodified fields intact.
            _mapper.Map(request, citizen);

            _citizenRepository.Update(citizen);
            await _citizenRepository.SaveChangesAsync();

            return new ApiResponse<bool> { Data = true };
        }

        public async Task<ApiResponse<bool>> DeleteCitizenAsync(int citizenId)
        {
            var citizen = await _citizenRepository.GetByIdAsync(citizenId);
            if (citizen == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Errors = new Dictionary<string, string[]>
                    {
                        { "Citizen", new [] { "Citizen not found" } }
                    }
                };
            }

            _citizenRepository.Delete(citizen);
            await _citizenRepository.SaveChangesAsync();

            return new ApiResponse<bool> { Data = true };
        }
    }
}

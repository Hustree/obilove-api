// obiloveapi.Application/MappingProfiles/CitizenMappingProfile.cs
using AutoMapper;
using obiloveapi.Application.DTOs.Citizen;
using obiloveapi.Domain.Entities;
using obiloveapi.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace obiloveapi.Application.MappingProfiles
{
    public class CitizenMappingProfile : Profile
    {
        public CitizenMappingProfile()
        {
            // Map from CitizenCreateRequest to Citizen, including nested Address.
            CreateMap<CitizenCreateRequest, Citizen>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    ProvinceId = src.ProvinceId,
                    CityId = src.CityId,
                    BarangayId = src.BarangayId
                }))
                .ForMember(dest => dest.Status, opt => opt.Ignore()); // We'll set Status in the service.

            // Map from Citizen to CitizenResponse, including FullName formatting.
            CreateMap<Citizen, CitizenResponse>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}".Replace("  ", " ").Trim()))
                .ForMember(dest => dest.Street,
                    opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : string.Empty))
                .ForMember(dest => dest.ProvinceId,
                    opt => opt.MapFrom(src => src.Address != null ? src.Address.ProvinceId : 0))
                .ForMember(dest => dest.CityId,
                    opt => opt.MapFrom(src => src.Address != null ? src.Address.CityId : 0))
                .ForMember(dest => dest.BarangayId,
                    opt => opt.MapFrom(src => src.Address != null ? src.Address.BarangayId : 0));

            // Map from CitizenUpdateRequest to Citizen.
            // You might want to ignore some fields that should not be overwritten.
            CreateMap<CitizenUpdateRequest, Citizen>()
                .ForMember(dest => dest.CitizenId, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    ProvinceId = src.ProvinceId,
                    CityId = src.CityId,
                    BarangayId = src.BarangayId
                }));
        }
    }
}

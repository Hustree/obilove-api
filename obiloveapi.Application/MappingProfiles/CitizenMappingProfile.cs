// obiloveapi.Application/MappingProfiles/UserMappingProfile.cs
using AutoMapper;
using obiloveapi.Application.DTOs.User;
using obiloveapi.Domain.Entities;
using obiloveapi.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace obiloveapi.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // Map from UserCreateRequest to User, including nested Address.
            CreateMap<UserCreateRequest, User>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    ProvinceId = src.ProvinceId,
                    CityId = src.CityId,
                    BarangayId = src.BarangayId
                }))
                .ForMember(dest => dest.Status, opt => opt.Ignore()); // We'll set Status in the service.

            // Map from User to UserResponse, including FullName formatting.
            CreateMap<User, UserResponse>()
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

            // Map from UserUpdateRequest to User.
            // You might want to ignore some fields that should not be overwritten.
            CreateMap<UserUpdateRequest, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
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

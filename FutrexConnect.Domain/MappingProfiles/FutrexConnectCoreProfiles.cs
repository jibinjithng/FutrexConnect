using AutoMapper;
using FutrexConnect.Domain.DAO;
using FutrexConnect.Domain.Entities;

public class FutrexConnectCoreProfiles : Profile
{
    public FutrexConnectCoreProfiles()
    {
        CreateMap<CustomerAddressDetails, CustomerAddressDetailsDAO>().ReverseMap();
        CreateMap<CustomerContactDetails, CustomerContactDetailsDAO>().ReverseMap();

        CreateMap<Customer, CustomerDAO>()
            .ForMember(dest => dest.CustomerAddressDetails, opt => opt.MapFrom(src => src.AddressDetails))
            .ForMember(dest => dest.CustomerContactDetails, opt => opt.MapFrom(src => src.ContactDetails)).ReverseMap();
    }
}
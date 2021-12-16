using AutoMapper;
using FutrexConnect.Domain.DAO;
using FutrexConnect.Domain.Entities;

public class FutrexConnectCoreProfiles : Profile
{
    public FutrexConnectCoreProfiles()
    {
        CreateMap<Customer, CustomerDAO>().ReverseMap();
    }
}
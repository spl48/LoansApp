using AutoMapper;
using LoansApp.Server.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LoansApp.Server.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerVM>()
                            .ReverseMap();
        }
    }
}

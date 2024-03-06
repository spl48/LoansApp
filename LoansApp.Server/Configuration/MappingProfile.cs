using AutoMapper;
using LoansApp.Server.ViewModels;

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

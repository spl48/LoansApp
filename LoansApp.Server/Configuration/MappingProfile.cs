using AutoMapper;
using LoansApp.Server.Models;
using LoansApp.Server.ViewModels;

namespace LoansApp.Server.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerVM>()
                            .ReverseMap();

            CreateMap<LoanApplication, LoanApplicationVM>()
                            .ReverseMap();
        }
    }
}

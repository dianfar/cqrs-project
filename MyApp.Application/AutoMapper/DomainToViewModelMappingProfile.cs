using MyApp.Application.ViewModels;
using AutoMapper;
using MyApp.Domain.Models;

namespace MyApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}

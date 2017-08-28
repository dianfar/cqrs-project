using MyApp.Application.ViewModels;
using AutoMapper;
using MyApp.Domain.Commands;

namespace MyApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
            CreateMap<ProductViewModel, CreateNewProductCommand>()
                .ConstructUsing(c => new CreateNewProductCommand(c.Name, c.Quantity));
        }
    }
}

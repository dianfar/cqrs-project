using MyApp.Application.ViewModels;
using AutoMapper;
using MyApp.Domain.Commands;

namespace MyApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientViewModel, RegisterNewClientCommand>()
                .ConstructUsing(c => new RegisterNewClientCommand(c.Name, c.Description));
            CreateMap<ClientViewModel, UpdateClientCommand>()
                .ConstructUsing(c => new UpdateClientCommand(c.Id, c.Name, c.Description));
            CreateMap<ProjectViewModel, CreateNewProjectCommand>()
                .ConstructUsing(c => new CreateNewProjectCommand(c.Name, c.Description, c.CompletionDate, c.ClientId));
            CreateMap<ProjectViewModel, UpdateProjectCommand>()
                .ConstructUsing(c => new UpdateProjectCommand(c.Id, c.Name, c.Description, c.CompletionDate));
        }
    }
}

using MyApp.Application.ViewModels;
using AutoMapper;
using MyApp.Domain.Queries;
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
            CreateMap<UserViewModel, RegisterNewUserCommand>()
                .ConstructUsing(c => new RegisterNewUserCommand(c.Name, c.Email, c.RoleId, c.Password));
            CreateMap<UserViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.Name, c.Active, c.Email, c.RoleId));
            CreateMap<ProjectMemberViewModel, AddProjectMemberCommand>()
                .ConstructUsing(c => new AddProjectMemberCommand(c.ProjectId, c.UserId));
            CreateMap<EntryLogViewModel, AddEntryLogCommand>()
                .ConstructUsing(c => new AddEntryLogCommand(c.UserId, c.ProjectId, c.EntryDate, c.Hours, c.Description));
            CreateMap<EntryLogViewModel, UpdateEntryLogCommand>()
                .ConstructUsing(c => new UpdateEntryLogCommand(c.Id, c.UserId, c.ProjectId, c.EntryDate, c.Hours, c.Description));
            CreateMap<LoginViewModel, AccountLoginQuery>()
                .ConstructUsing(c => new AccountLoginQuery(c.Email, c.Password));
        }
    }
}

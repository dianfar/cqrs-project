using MyApp.Application.ViewModels;
using AutoMapper;
using MyApp.Domain.Models;

namespace MyApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<Project, ProjectViewModel>()
                .ConstructUsing(c => new ProjectViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    CompletionDate = c.CompletionDate,
                    ClientId = c.Client.Id,
                    ClientName = c.Client.Name
                });
            CreateMap<Project, UpdateProjectViewModel>()
                .ConstructUsing(c => new UpdateProjectViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    CompletionDate = c.CompletionDate,
                    ClientId = c.Client.Id,
                    ClientName = c.Client.Name
                });
            CreateMap<User, UserViewModel>()
                .ConstructUsing(c => new UserViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Active = c.Active,
                    Email = c.Email,
                    RoleId = c.Role.Id,
                    RoleName = c.Role.Name
                });
            CreateMap<User, UpdateUserViewModel>()
                .ConstructUsing(c => new UpdateUserViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Active = c.Active,
                    Email = c.Email,
                    RoleId = c.Role.Id,
                    RoleName = c.Role.Name
                });
            CreateMap<Role, RoleViewModel>();
        }
    }
}

using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using AutoMapper;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.EventHandlers;
using MyApp.Domain.Events;
using MyApp.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.Data.Context;
using MyApp.Infrastructure.Data.Repository;
using MyApp.Infrastructure.Data.UoW;
using MyApp.Infrastructure.Identity.PasswordHasher;
using MyApp.Domain.Models;
using MyApp.Domain.Core.Interfaces;
using System.Linq;
using MyApp.Domain.QueryHandlers;
using MyApp.Infrastructure.Mail;

namespace MyApp.Infrastructure.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IProjectAppService, ProjectAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IProjectMemberAppService, ProjectMemberAppService>();
            services.AddScoped<IEntryLogAppService, EntryLogAppService>();
            services.AddScoped<IAccountAppService, AccountAppService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ClientRegisteredEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<ClientUpdatedEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<ClientRemovedEvent>, ClientEventHandler>();

            services.AddScoped<IRequestHandler<RegisterNewClientCommand>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClientCommand>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClientCommand>, ClientCommandHandler>();

            services.AddScoped<IRequestHandler<CreateNewProjectCommand>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProjectCommand>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProjectCommand>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllProjectQuery, IQueryable<Project>>, GetAllProjectQueryHandler>();
            services.AddScoped<IRequestHandler<GetProjectByIdQuery, Project>, GetProjectByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetProjectsByUserQuery, IQueryable<Project>>, GetProjectsByUserQueryHandler>();

            services.AddScoped<IRequestHandler<RegisterNewUserCommand>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllUserQuery, IQueryable<User>>, GetAllUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllRoleQuery, IQueryable<Role>>, GetAllRoleQueryHandler>();

            services.AddScoped<IRequestHandler<AddProjectMemberCommand>, ProjectMemberCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProjectMemberCommand>, ProjectMemberCommandHandler>();
            services.AddScoped<IRequestHandler<GetEntryLogByUserQuery, IQueryable<EntryLog>>, GetEntryLogByUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetEntryLogByIdQuery, EntryLog>, GetEntryLogByIdQueryHandler>();

            services.AddScoped<IRequestHandler<AddEntryLogCommand>, EntryLogCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveEntryLogCommand>, EntryLogCommandHandler>();

            services.AddScoped<IRequestHandler<AccountLoginQuery, User>, AccountLoginQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllClientQuery, IQueryable<Client>>, GetAllClientQueryHandler>();
            services.AddScoped<IRequestHandler<GetClientByIdQuery, Client>, GetClientByIdQueryHandler>();

            services.AddScoped<IMailProvider, MockMailProvider>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IProjectMemberRepository, ProjectMemberRepository>();
            services.AddScoped<IEntryLogRepository, EntryLogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<MyAppContext>();
        }
    }
}

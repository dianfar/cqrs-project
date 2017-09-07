﻿using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using AutoMapper;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Commands;
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

namespace MyApp.Infrastructure.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IProjectAppService, ProjectAppService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ClientRegisteredEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<ClientUpdatedEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<ClientRemovedEvent>, ClientEventHandler>();

            services.AddScoped<INotificationHandler<RegisterNewClientCommand>, ClientCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateClientCommand>, ClientCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveClientCommand>, ClientCommandHandler>();
            services.AddScoped<INotificationHandler<CreateNewProjectCommand>, ProjectCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateProjectCommand>, ProjectCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveProductCommand>, ProjectCommandHandler>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyAppContext>();
        }
    }
}

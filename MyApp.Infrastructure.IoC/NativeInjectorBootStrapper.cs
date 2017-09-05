using MyApp.Application.Interfaces;
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
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            services.AddScoped<INotificationHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<CreateNewProductCommand>, ProductCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateProductCommand>, ProductCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveProductCommand>, ProductCommandHandler>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyAppContext>();
        }
    }
}

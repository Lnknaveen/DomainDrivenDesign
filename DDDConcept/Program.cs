using System.Net;

using AutoMapper.Execution;
using MediatR;
using System.Reflection;
using DDDConcept.PersonModule.Interface;
using AutoMapper;
using DDDConcept.PersonModule.Core.ApplicationService.Commands;
using DDDConcept.PersonModule.Interface.DTOs;
using DDDConcept.PersonModule.Infrastructure.Repositories;
using DDDConcept.PersonModule.Core.DomainService.Ports;
using DDDConcept.PersonModule.Infrastructure.Publisher;
using DDDConcept.PersonModule.Core.ApplicationService.Queries;
using DDDConcept.NotificationModule.Core.DomainService.Ports;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureServices(services =>
{
    Assembly assembly = Assembly.GetExecutingAssembly();
    services.AddMediatR(assembly);

    var mapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<PersonCommand, PersonDTO>();
        cfg.CreateMap<PersonDTO, PersonCommand>();
        cfg.CreateMap<PersonQueryResponse, PersonResponseDTO>();
        cfg.CreateMap<PersonResponseDTO, PersonQueryResponse>();


    });

    IMapper mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);
});

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IEmailNotification, EmailNotification>();

var app = builder.Build(); 
new PersonController(app).Configure();
app.Run();
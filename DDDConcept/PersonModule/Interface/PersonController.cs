using AutoMapper;
using DDDConcept.PersonModule.Core.ApplicationService.Commands;
using DDDConcept.PersonModule.Core.ApplicationService.Queries;
using DDDConcept.PersonModule.Interface.DTOs;
using DDDConcept.SharedKernel.X;
using MediatR;
using System.Net;

namespace DDDConcept.PersonModule.Interface
{
    public class PersonController
    {
        private WebApplication _app;

        public PersonController(WebApplication app)
        {
            _app = app;
        }

        public void Configure()
        {
            _app.MapGet("/", () => "Hello domain driven design!");
            _app.MapGet("/all", GetAll);
            _app.MapPost("/post", Post);
        }

        private async Task GetAll(HttpContext context)
        {
            IMediator mediator = context.GetInstance<IMediator>();
            IMapper mapper = context.GetInstance<IMapper>();

            IEnumerable<PersonResponseDTO> value = mediator.Send(new PersonQuery { Context = context }).Result.Select(mapper.Map<PersonResponseDTO>);
            await context.Response.WriteAsJsonAsync(value);
        }

        private async Task Post(HttpContext context)
        {
            if (!context.Request.HasJsonContentType())
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnsupportedMediaType;
                return;
            }

            IMediator mediator = context.GetInstance<IMediator>();
            IMapper mapper = context.GetInstance<IMapper>();

            var personDTO = await context.Request.ReadFromJsonAsync<PersonDTO>();
            PersonCommand personSaveCommand = mapper.Map<PersonCommand>(personDTO);
            personSaveCommand.Context = context;
            await mediator.Send(personSaveCommand);

            context.Response.StatusCode = (int)HttpStatusCode.Accepted;
        }
    }
}

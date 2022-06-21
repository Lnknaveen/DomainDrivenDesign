using MediatR;

namespace DDDConcept.PersonModule.Core.ApplicationService.Commands
{
    public class PersonCommand : IRequest<Guid>
    {
        public HttpContext Context { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;
    }
}

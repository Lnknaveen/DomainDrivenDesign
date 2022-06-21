using MediatR;

namespace DDDConcept.PersonModule.Core.DomainService.DomainEvents
{
    public class PersonCreatedDomainEvent : INotification
    {
        public HttpContext Context { get; set; } = default!;

        public Guid Id { get; set; }
    }
}

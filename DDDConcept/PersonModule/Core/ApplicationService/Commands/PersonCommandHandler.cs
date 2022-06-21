using DDDConcept.PersonModule.Core.ApplicationService.Commands;
using DDDConcept.PersonModule.Core.DomainService.DomainEvents;
using DDDConcept.PersonModule.Core.DomainService.Ports;
using DDDConcept.PersonModule.Core.Entities;
using DDDConcept.SharedKernel.X;
using MediatR;

namespace DDDConcept.PersonModule.Core.ApplicationService
{
    public class PersonCommandHandler : IRequestHandler<PersonCommand, Guid>
    {
        public Task<Guid> Handle(PersonCommand request, CancellationToken cancellationToken)
        {
            IPersonRepository personRepository = request.Context.GetInstance<IPersonRepository>();
            PersonAggregate person = new PersonAggregate { FirstName = request.FirstName, LastName = request.LastName };
            person.UpdateFullname();
            Guid result = personRepository.SavePerson(person);

            IMediator mediator = request.Context.GetInstance<IMediator>();
            mediator.Publish(new PersonCreatedDomainEvent { Id = person.Id, Context = request.Context });

            return Task.FromResult(result);
        }
    }
}

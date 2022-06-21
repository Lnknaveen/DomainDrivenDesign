using DDDConcept.PersonModule.Core.DomainService.Ports;
using DDDConcept.PersonModule.Core.Entities;
using DDDConcept.SharedKernel.X;
using MediatR;

namespace DDDConcept.PersonModule.Core.ApplicationService.Queries
{
    public class PersonQueryHandler : IRequestHandler<PersonQuery, IEnumerable<PersonQueryResponse>>
    {
        public Task<IEnumerable<PersonQueryResponse>> Handle(PersonQuery request, CancellationToken cancellationToken)
        {
            IPersonRepository personRepository = request.Context.GetInstance<IPersonRepository>();
            return Task.FromResult(personRepository.GetAll().Select(s => new PersonQueryResponse { FullName = s.FullName.Value }));
        }
    }
}

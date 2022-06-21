using DDDConcept.PersonModule.Core.Entities;

namespace DDDConcept.PersonModule.Core.DomainService.Ports
{
    public interface IPersonRepository
    {
        public Guid SavePerson(PersonAggregate person);

        public List<PersonAggregate> GetAll();

    }
}

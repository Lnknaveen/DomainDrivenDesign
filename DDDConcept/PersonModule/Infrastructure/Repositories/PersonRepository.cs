using DDDConcept.PersonModule.Core.DomainService.Ports;
using DDDConcept.PersonModule.Core.Entities;

namespace DDDConcept.PersonModule.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        static List<PersonAggregate> _aggregateList = new();

        public List<PersonAggregate> GetAll()
        {
            return _aggregateList;
        }

        public Guid SavePerson(PersonAggregate person)
        {
            // You can transform and Save
            person.Id = Guid.NewGuid();
            
            _aggregateList.Add(person);

            return person.Id;
        }
    }
}

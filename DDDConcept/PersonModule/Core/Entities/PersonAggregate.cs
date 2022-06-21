using DDDConcept.PersonModule.Core.Entities.SharedKernal;

namespace DDDConcept.PersonModule.Core.Entities
{
    public class PersonAggregate : Entity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        internal FullName FullName { get; set; } = default!;

        public void UpdateFullname()
        {
            FullName = new FullName(FirstName, LastName);
        }
    }
}

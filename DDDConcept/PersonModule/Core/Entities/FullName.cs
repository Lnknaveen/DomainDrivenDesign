
using DDDConcept.PersonModule.Core.Entities.SharedKernal;

namespace DDDConcept.PersonModule.Core.Entities
{
    public class FullName : ValueObject
    {
        public FullName(string firstName, string lastName)
        {
            Value = $"{firstName ?? throw new ArgumentNullException(nameof(firstName))}, {lastName ?? throw new ArgumentNullException(nameof(lastName))}";
        }

        public string Value { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

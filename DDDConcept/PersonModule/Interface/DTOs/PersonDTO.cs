
using System.ComponentModel.DataAnnotations;

namespace DDDConcept.PersonModule.Interface.DTOs
{
    public class PersonDTO
    {
        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;
    }
}

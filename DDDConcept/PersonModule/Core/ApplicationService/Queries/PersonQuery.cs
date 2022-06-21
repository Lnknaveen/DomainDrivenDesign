using MediatR;

namespace DDDConcept.PersonModule.Core.ApplicationService.Queries
{
    public class PersonQuery : IRequest<IEnumerable<PersonQueryResponse>>
    {
        public HttpContext Context { get; set; } = default!;

        public string FullName { get; set; } = default!;
    }

    public class PersonQueryResponse
    {
        public string FullName { get; set; } = default!;
    }
}

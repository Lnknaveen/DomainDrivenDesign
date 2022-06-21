using MediatR;

namespace DDDConcept.SharedKernel.IntegrationEvents
{
    public class SendEmailIntegrationEvent : IRequest
    {
        public HttpContext Context { get; set; } = default!;

        public string Content { get; set; } = default!;
    }
}

using DDDConcept.NotificationModule.Core.DomainService.Ports;
using DDDConcept.SharedKernel.IntegrationEvents;
using DDDConcept.SharedKernel.X;
using MediatR;

namespace DDDConcept.NotificationModule.Core.ApplicationService.Commands
{
    public class EmailNotificationHandler : IRequestHandler<SendEmailIntegrationEvent>
    {
        public Task<Unit> Handle(SendEmailIntegrationEvent request, CancellationToken cancellationToken)
        {
            IEmailNotification emailNotification = request.Context.GetInstance<IEmailNotification>();
            emailNotification.Send(request.Content);

            return Task.FromResult(Unit.Value);
        }
    }
}

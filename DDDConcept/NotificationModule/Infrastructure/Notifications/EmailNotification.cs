using DDDConcept.NotificationModule.Core.DomainService.Ports;

namespace DDDConcept.PersonModule.Infrastructure.Publisher
{
    public class EmailNotification : IEmailNotification
    {
        public void Send(string content)
        {
            // Send email logic            
        }
    }
}

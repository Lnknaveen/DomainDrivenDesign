using DDDConcept.PersonModule.Core.Entities;

namespace DDDConcept.NotificationModule.Core.DomainService.Ports
{
    public interface IEmailNotification
    {
        public void Send(string content);
    }
}

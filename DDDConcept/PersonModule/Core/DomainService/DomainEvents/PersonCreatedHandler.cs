using AutoMapper;
using DDDConcept.SharedKernel.IntegrationEvents;
using DDDConcept.SharedKernel.X;
using MediatR;

namespace DDDConcept.PersonModule.Core.DomainService.DomainEvents
{
    public class PersonCreatedHandler : INotificationHandler<PersonCreatedDomainEvent>
    {
        public Task Handle(PersonCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            IMediator mediator = notification.Context.GetInstance<IMediator>();
            mediator.Send(new SendEmailIntegrationEvent
            {
                Context = notification.Context,
                Content = $"Your account is crated with id : {notification.Id}"
            });

            return Task.CompletedTask;
        }
    }
}

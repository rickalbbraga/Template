using Semear.Context.CommonCore.DomainNotification;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity : INotificationList
    {
        public Guid Uid { get; protected set; }

        public ICollection<Notification> Errors { get; protected set; }

        protected Entity()
        {
            Errors = [];
        }

        protected abstract void Validate();
    }
}

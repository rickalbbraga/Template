using Domain.Utils.ErrorMessages;
using Semear.Context.CommonCore.DomainNotification;

namespace Domain.ValueObjects
{
    public class AuditDate : ValueObject
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        private AuditDate()
        {

        }

        private AuditDate(DateTime createdAt)
        {
            CreatedAt = createdAt;

            Validate();
        }

        private AuditDate(DateTime createdAt, DateTime updatedAt)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;

            Validate();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CreatedAt;
            yield return UpdatedAt ?? DateTime.MinValue;
        }

        protected override void Validate()
        {
            if (CreatedAt == DateTime.MinValue)
            {
                Errors.Add(new Notification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.CreatedAtIsRequired));
            }

            if (UpdatedAt is not null && UpdatedAt == DateTime.MinValue)
            {
                Errors.Add(new Notification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.UpdatedAtIsRequired));
            }
        }

        public static AuditDate Create(DateTime createdAt)
            => new(createdAt);

        public static AuditDate Create(DateTime createdAt, DateTime updatedAt)
            => new(createdAt, updatedAt);
    }
}

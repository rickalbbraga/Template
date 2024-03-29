﻿using Semear.Context.CommonCore.DomainNotification;

namespace Domain.ValueObjects
{
    public abstract class ValueObject : INotificationList
    {
        public ICollection<Notification> Errors { get; protected set; }

        protected ValueObject()
        {
            Errors = [];
        }

        protected static bool EqualOperator(ValueObject? left, ValueObject? right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return ReferenceEquals(left, right) || left!.Equals(right!);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        protected abstract void Validate();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}

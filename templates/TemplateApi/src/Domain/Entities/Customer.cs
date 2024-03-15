using Domain.Utils.ErrorMessages;
using Semear.Context.CommonCore.DomainNotification;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public partial class Customer : Entity
    {
        public string Name { get; private set; } = string.Empty;

        public string Document { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        private Customer()
        {

        }

        private Customer(string name, string document, string email)
        {
            Uid = Guid.NewGuid();
            Name = name;
            Document = document;
            Email = email;

            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Errors.Add(new Notification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.NameIsRequired));

            }

            if (string.IsNullOrEmpty(Document) || (GetAllCharacteresFromDocument().Replace(Document, string.Empty).Length != 11))
            {
                Errors.Add(new Notification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.DocumentIsNotValid));
            }

            if (string.IsNullOrEmpty(Email))
            {
                Errors.Add(new Notification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.EmailIsRequired));
                return;
            }

            if (!EmailPattern().IsMatch(Email))
            {
                Errors.Add(new Notification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.EmailIsNotValid));
            }
        }

        public static Customer Create(string name, string document, string email) => new(name, document, email);

        public void Update(string name, string document, string email)
        {
            Name = name;
            Document = document;
            Email = email;

            Validate();
        }

        [GeneratedRegex(@"[^0-9]")]
        private static partial Regex GetAllCharacteresFromDocument();
        
        [GeneratedRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        private static partial Regex EmailPattern();
    }
}

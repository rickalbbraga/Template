using System.Diagnostics.CodeAnalysis;

namespace Domain.Utils.ErrorMessages
{
    [ExcludeFromCodeCoverage]
    public static class DomainErrorMessages
    {
        public static readonly string BadRequest = "Bad Request";
        public static readonly string NameIsRequired = "Name is required";
        public static readonly string DocumentIsNotValid = "Document is not valid";
        public static readonly string EmailIsRequired = "E-mail is required";
        public static readonly string EmailIsNotValid = "E-mail is not valid";
        public static readonly string CommandIsNotValid = "Command is not valid";
        public static readonly string QueryIsNotValid = "Query is not valid";
        public static readonly string CustomerNotFound = "Customer not found";
        public static readonly string CreatedAtIsRequired = "CreatedAt is required";
        public static readonly string UpdatedAtIsRequired = "UpdatedAt is required";
    }
}

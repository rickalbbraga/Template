using System.Diagnostics.CodeAnalysis;

namespace Application.Queries.Customer
{
    [ExcludeFromCodeCoverage]
    public class GetAllCustomerQuery : Query
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

    }
}

using Domain.Interfaces.CQS;

namespace Application.Helpers.Builders
{
    public interface IResponseBuilder<out TDest, in TSrc> where TDest : IResult
    {
        TDest GetResponse(TSrc source);
    }
}

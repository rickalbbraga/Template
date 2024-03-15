using AutoMapper;
using Domain.Interfaces.CQS;

namespace Application.Helpers.Builders
{
    public class ResponseBuilder<TDest, TSrc>(IMapper mapper) : IResponseBuilder<TDest, TSrc> where TDest : IResult
    {

        protected readonly IMapper _mapper = mapper;

        public TDest GetResponse(TSrc source)
        {
            BeforeMapping(source);
            var result = _mapper.Map<TDest>(source);
            AfterMapping(result);
            return result;
        }

        protected virtual void AfterMapping(TDest? source)
        {
        }

        protected virtual void BeforeMapping(TSrc? source)
        {
        }
    }
}

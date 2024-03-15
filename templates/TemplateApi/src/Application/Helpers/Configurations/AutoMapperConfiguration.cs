using Application.Responses;
using Application.Responses.Customer;
using AutoMapper;
using Domain.Entities;
using Semear.Context.CommonCore.DomainNotification;
using System.Diagnostics.CodeAnalysis;

namespace Application.Helpers.Configurations
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Notification, ErrorResponse>()
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Detail, opt => opt.MapFrom(s => s.Message));

            CreateMap<Customer, CustomerResponse>();
        }
    }
}

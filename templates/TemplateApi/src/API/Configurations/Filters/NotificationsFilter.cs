using Application.Responses;
using Microsoft.AspNetCore.Mvc.Filters;
using Semear.Context.CommonCore.DomainNotification;
using Semear.Context.Logger.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace API.Configurations.Filters
{
    [ExcludeFromCodeCoverage]
    public class NotificationsFilter(
        INotificationContext notificationContext,
        ISemearLogService logger) : IAsyncResultFilter, IAsyncActionFilter
    {
        private const int BadRequestStatusCode = 400;
        private const string ContentType = "application/json";

        private readonly INotificationContext _notificationContext = notificationContext;
        private readonly ISemearLogService _logger = logger;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _notificationContext.Clear();

            await next();
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = BadRequestStatusCode;
                context.HttpContext.Response.ContentType = ContentType;
                await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(BuildResponse));
                return;
            }

            await next();
        }

        private IEnumerable<ErrorResponse> BuildResponse
        {
            get
            {
                var result = new List<ErrorResponse>();

                _notificationContext.Notifications.ToList().ForEach(notification =>
                {
                    _logger.WriteLogWarning(
                        JsonSerializer.Serialize(new
                        {
                            notification.Code,
                            notification.Title,
                            notification.Message,
                            ClassName = nameof(NotificationsFilter),
                            MethodName = nameof(OnResultExecutionAsync),

                        }));

                    result.Add(new ErrorResponse { Code = notification.Code, Title = notification.Title, Detail = notification.Message });
                });

                return result;
            }
        }
    }
}

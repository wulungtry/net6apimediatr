using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Rest.API.Application
{
    public class FindRequest : IRequest<FindResponse>
    {
        public string firstName { get; init; }
        public string lastName { get; set; }

        public static ValueTask<FindRequest> BindAsync(HttpContext context, ParameterInfo parameter)
        {
            FindRequest result = new()
            {
                firstName = context.Request.Query["firstName"],
                lastName = context.Request.Query["lastName"]
            };

            return ValueTask.FromResult(result);
        }
    }
}

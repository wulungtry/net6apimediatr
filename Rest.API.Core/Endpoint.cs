using MediatR;
using Rest.API.Application;

namespace Rest.API.Core
{
    public interface IEndpoint
    {
        void ConfigureApplication(WebApplication app);
    }

    public class Endpoint : IEndpoint
    {
        public void ConfigureApplication(WebApplication app)
        {
            app.MapGet("employee/{id}", async (IMediator mediator, string id) => await mediator.Send(new GetRequest(id)));
            app.MapGet("employee", async (IMediator mediator, FindRequest request) => await mediator.Send(request));
        }
    }
}

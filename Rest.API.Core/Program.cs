using MediatR;
using Rest.API.Application;
using Rest.API.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region SERVICES
builder.Services.ConfigureCORS();
builder.Services.AddMediatR(typeof(GetHandler).GetTypeInfo().Assembly);
builder.Services.ConfigureSwagger();
builder.Services.AddEndpoint(typeof(IEndpoint)); //Register all endpoint(controller) that implementing IEndpoint.
#endregion

var app = builder.Build();

#region PIPELINE
app.UseSwaggerApp();
app.UseEndpoint();
app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();
#endregion

app.Run();
using Microsoft.AspNetCore.Diagnostics;
using SmartCertify.API.Extension;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerExtension();
builder.Services.AddDBContextExtension(builder.Configuration);
builder.Services.AddCorsExtension(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartCertify.API v1");
        c.RoutePrefix = string.Empty; // optional: makes Swagger UI load at root "/"
    });
}

app.UseHttpsRedirection();
app.UseRouting();

//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseExceptionHandler();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

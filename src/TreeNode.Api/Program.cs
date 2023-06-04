using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using TreeNode.Api.Extensions;
using TreeNode.Api.Middlewares;
using TreeNode.Application.Nodes.Commands;
using TreeNode.Persistence;
using TreeNode.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddMediatR(m =>
    m.RegisterServicesFromAssemblies(typeof(CreateNodeCommand).Assembly));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationRulesToSwagger();
builder.Services.AddSwagger();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
    await initialiser.SeedAsync();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
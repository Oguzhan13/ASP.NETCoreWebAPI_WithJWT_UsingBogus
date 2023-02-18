var builder = WebApplication.CreateBuilder(args);
//AddController(), AddEndpointsApiExplorer() and Add.SwaggerGen() methods delete from Program.cs and move to AddApiServices() method from DependencyInjection.cs class in Extensions folder (Moved by developer)
// For access to DependencyInjection.cs file (Added by developer)
builder.Services.AddApiServices(builder.Configuration);
//when finish builder processes do Build process for builder
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
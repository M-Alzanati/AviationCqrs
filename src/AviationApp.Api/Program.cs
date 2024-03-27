using AviationApp.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
builder.Services.AddWebApiServices(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Aviation Api");
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseHealthChecks("/healthz");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}",
    defaults: new { controller = "Flights" });

app.Run();
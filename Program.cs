using System.Net; // Add this line
using MOCSocialClubPassWebService.Controllers;
using MOCSocialClubPassWebService.Options;
using Swashbuckle.AspNetCore.Swagger;
using Constants = MOCSocialClubPassWebService.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddTransient<
    IConfigureOptions<MOCSocialClubPassbookOptions>,
    FieldsConfigurator
>();
builder.Services.AddTransient<
    IConfigureOptions<MOCSocialClubPassbookOptions>,
    PassbookImageFileConfigurator
>();
builder.Services.AddTransient<
    IConfigureOptions<MOCSocialClubPassbookOptions>,
    OptionsConfigurator
>();
builder.Services.AddHttpClient<MembershipCardController>(client =>
    client.DefaultRequestHeaders.Add(Constants.Headers.ClientId, Constants.PkPassMimeType)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(new SwaggerOptions() { RouteTemplate = "swagger/{documentName}/swagger.json" });
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";
        c.SwaggerEndpoint(
            $"/swagger/{typeof(Program).Assembly.GetCustomAttribute<AssemblyVersionAttribute>()!.Version}/swagger.json",
            "V1 Docs"
        );
    });
}

app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();

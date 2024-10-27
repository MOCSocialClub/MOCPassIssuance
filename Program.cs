using MOCSocialClubPassWebService.Options;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();

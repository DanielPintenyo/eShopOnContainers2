using CatalogTCG.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CatalogContext>(opt =>opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "API Rest del Ejemplo eShopOnContainers",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Email = "dpl39@gcloud.ua.es",
                Name = "Daniel Pinteño Llerena"
            },
            License = new Microsoft.OpenApi.Models.OpenApiLicense
            {
                Name = "Apache License,2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            },
            Version = "v1"
        });

        var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    });

    var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<CatalogContext>();
        //it creates the DB in case it does not exist
        //this is used only while developing the system
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.MapControllers();

app.Run();

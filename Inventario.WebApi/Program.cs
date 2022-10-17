using IoC;
//using WebExceptionPresenter;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Agregar servicios al contenedor

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors();


builder.Services.AddInventoryServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();


app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200", "http://localhost:4500");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

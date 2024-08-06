using TrulyExplorer.WebApi.Repository;
using TrulyExplorer.WebApi.Repository.Implementation;
using TrulyExplorer.WebApi.Services;
using TrulyExplorer.WebApi.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();  
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Allows all origins
                   .AllowAnyMethod() // Allows all HTTP methods
                   .AllowAnyHeader(); // Allows all headers
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

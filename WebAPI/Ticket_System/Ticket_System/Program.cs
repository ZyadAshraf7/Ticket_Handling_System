using Microsoft.EntityFrameworkCore;
using Ticket_System.Data;
using Ticket_System.Interfaces;
using Ticket_System.Repository;
using Ticket_System.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register repositories and services
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

// Register background service
builder.Services.AddHostedService<TicketBackgroundService>();
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// use CORS
app.UseCors("AllowOrigin");

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

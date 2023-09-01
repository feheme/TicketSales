using TicketSales.DAL.Abstract;
using TicketSales.DAL.Concrete.Repositories;
using TicketSales.BLL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScopeBLL();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

using BasicBilling.Data;
using BasicBilling.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var CONNECTION_STRING = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BillingDbContext>(options => 
    options.UseSqlite(CONNECTION_STRING));
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        }
    );
});

builder.Services.AddScoped<BillingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

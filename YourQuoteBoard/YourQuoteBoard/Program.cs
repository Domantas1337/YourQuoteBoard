using YourQuoteBoard.Data;
using YourQuoteBoard.Data;
using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Services;
using YourQuoteBoard.Repositories;
using YourQuoteBoard;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173") 
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(options => {
    options.AddProfile<MappingProfile>();
});

builder.Services.AddTransient<IQuoteRepository, QuoteRepository>();
builder.Services.AddTransient<IQuoteService, QuoteService>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();


app.Run();

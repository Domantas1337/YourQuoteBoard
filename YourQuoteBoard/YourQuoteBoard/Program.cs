using YourQuoteBoard.Data;
using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Services;
using YourQuoteBoard.Repositories;
using YourQuoteBoard;
using YourQuoteBoard.Interfaces.Service;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.None;
});

builder.Services.AddCors(options =>
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowCredentials();
        }));


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));


builder.Services.AddAuthorization()
    ;
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(options => {
    options.AddProfile<MappingProfile>();
});

builder.Services.AddTransient<IQuoteRepository, QuoteRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookRatingRepository, BookRatingRepository>();
builder.Services.AddTransient<IFolderRepository, FolderRepository>();
builder.Services.AddTransient<IQuoteRatingRepository, QuoteRatingRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();


builder.Services.AddTransient<IQuoteService, QuoteService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRatingService, BookRatingService>();
builder.Services.AddTransient<IQuoteRatingService, QuoteRatingService>();
builder.Services.AddTransient<IFolderService, FolderService>();
builder.Services.AddTransient<ITagService, TagService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowSpecificOrigin");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapIdentityApi<ApplicationUser>();

app.UseStaticFiles();


app.MapPost("/logout", async (SignInManager<ApplicationUser> signInManager) =>
{

    await signInManager.SignOutAsync();
    return Results.Ok();

}).RequireAuthorization();


app.MapGet("/pingauth", (ClaimsPrincipal user) =>
{
    var email = user.FindFirstValue(ClaimTypes.Email); // get the user's email from the claim
    return Results.Json(new { Email = email }); ; // return the email as a plain text response
}).RequireCors("AllowSpecificOrigin")
    .RequireAuthorization();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.Run();

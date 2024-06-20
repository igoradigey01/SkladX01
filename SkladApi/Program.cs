
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkladDB;
using X01.Model.Identity;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var urls = builder.Configuration.GetSection("CorsPolicy").Get<string[]>()!;

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(urls)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
string connectString = String.Empty;

if (builder.Environment.IsDevelopment())
{
    connectString = builder.Configuration["ConnectionStrings:DeveloperX01"]!;
    // Console.WriteLine(connectString);
}
else
{
    connectString = builder.Configuration.GetSection("ConnectString").Value!;


}

var connectStringSklad = connectString + "Database=Sh_Skald;";

var connectStringAppIdentity = connectString + "database=AppIdentityDB;";

builder.Services.AddDbContext<AppIdentityDbContext>(
    options => options.UseSqlServer(connectStringAppIdentity)
);

builder.Services.AddDbContext<SkaldDBContext>(
    options => options
        .UseSqlServer(connectStringSklad)

);

builder.Services.AddIdentity<UserIdentityX01, IdentityRole>()
    .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AppIdentityDbContext>()
       .AddDefaultTokenProviders();

//------------------------ jwt --------------------------------

var mySecurityKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(builder.Configuration.GetSection("IdentityX01:TokenX01-Key").Value!)
              );
string[]? audence = builder.Configuration.GetSection("Authentication:Schemes:JwtBearer:Audiences").Get<string[]>();
string joinedString = String.Empty;
if (audence != null)
{
    joinedString = audence.Aggregate((prev, current) => prev + "," + current);
}

builder.Services.AddAuthentication().AddJwtBearer
    (options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("Authentication:Schemes:JwtBearer:Issuer").Value,
            ValidAudience = joinedString,
            IssuerSigningKey = mySecurityKey
        };
    });

builder.Services.AddSwaggerGen();

var app = builder.Build();
// for nginx
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();   // добавление middleware аутентификации 
app.UseAuthorization();   // добавление middleware авторизации 

app.MapControllers();

app.Run();

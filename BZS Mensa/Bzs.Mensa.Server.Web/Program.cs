using Bzs.Mensa.Server.Services;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Attach services.
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IBenutzerService, BenutzerService>();
builder.Services.AddScoped<IAllergienService, AllergienService>();
builder.Services.AddScoped<IKlasseService, KlasseService>();
builder.Services.AddScoped<IEssenService, EssenService>();
builder.Services.AddScoped<IFeiertagService, FeiertagService>();
builder.Services.AddScoped<IFerienService, FerienService>();
builder.Services.AddScoped<IEssenMenuService, EssenMenuService>();
builder.Services.AddScoped<IEssenStandardService, EssenStandardService>();

// Security
byte[] key = Encoding.ASCII.GetBytes("BzsMensaTokenKey");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

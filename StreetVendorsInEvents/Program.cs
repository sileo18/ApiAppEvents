using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StreetVendorsInEvents.Data;
using StreetVendorsInEvents.Repository;
using StreetVendorsInEvents.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Configura serviços no contêiner.
builder.Services.AddControllers();

// Configura o contexto do banco de dados para usar SQLite.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=BancoStreetVendors.sqlite"));

// Registra o repositório e a interface para injeção de dependência.
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configura o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

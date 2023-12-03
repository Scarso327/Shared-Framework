using Microsoft.EntityFrameworkCore;
using Scarso.Framework.AspNetCore.MultiTenancy.Extensions;
using Scarso.Framework.AspNetCore.MultiTenancy.Resolvers;
using Scarso.Framework.Domain.MultiTenancy.Configuration;
using Scarso.Framework.Domain.MultiTenancy.Services;
using Scarso.Framework.Domain.Persistence.Interfaces;
using Scarso.Framework.Infrastructure.EntityFramework.MultiTenancy.Services;
using Scarso.Framework.Infrastructure.EntityFramework.Persistence;
using Scarso.Framework.Samples.APITenantResolution.Domain.MultiTenancy.Entities;
using Scarso.Framework.Samples.APITenantResolution.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Add configure services to each layer
// NOTE: Maybe Autofac?

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BaseDbContext, WeatherDbContext>(o => o.UseInMemoryDatabase(databaseName: "ApiWeatherDb"));
builder.Services.AddScoped<IUnitOfWork>(o => o.GetRequiredService<WeatherDbContext>());

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.Configure<MultiTenancyConfig>(o =>
{
    o.IsRequired = true;
    o.ResolverTypes = [ typeof(ResolveTenantIdFromHeader), typeof(ResolveTenantIdFromSubDomain) ];
});

builder.Services.AddScoped<ResolveTenantIdFromHeader>();
builder.Services.AddScoped<ResolveTenantIdFromSubDomain>();
builder.Services.AddScoped<ITenantResolver, TenantResolver>();
builder.Services.AddScoped<ITenantStore, TenantStore<Tenant>>();
builder.Services.AddScoped<ICurrentTenant, CurrentTenant>();

var app = builder.Build();

// This next bit is just here to ensure our in memory database gets it's data seeded
// Using an actual db provider with proper migration usage would not require this
var scope = app.Services.CreateScope();

// Ensures our in mem database seeds our data
using (var context = scope.ServiceProvider.GetRequiredService<WeatherDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMultiTenancy();

app.UseAuthorization();

app.MapControllers();

app.Run();

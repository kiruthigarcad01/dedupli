﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DatabaseProject.Data;
using DatabaseProject;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseProjectContext") ?? throw new InvalidOperationException("Connection string 'DatabaseProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed the database with sample data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DatabaseProjectContext>();
    DbInitializer.Initialize(context);
}

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
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
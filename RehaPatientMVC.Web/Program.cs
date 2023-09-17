using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RehaPatientMVC.Infrastructure;
using RehaPatientMVC.Web.Configuration;
using RehaPatientMVC.Application;
using AutoMapper;
using RehaPatientMVC.Domain.MappingProfile;
using RehaPatientMVC.Application.MappingProfile;
using FluentValidation.AspNetCore;
using FluentValidation;
using RehaPatientMVC.Application.ViewModels.Patients;
using RehaPatientMVC.Application.MappingProfile.Patient;
using RehaPatientMVC.Application.MappingProfile.Medic;
using RehaPatientMVC.Application.ViewModels.Referral;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews().AddFluentValidation(/*fv=>fv.DisableDataAnnotationsValidation = true*/); 


builder.Services.AddTransient<IValidator<NewPatientVm>, NewPatientValidation>();
builder.Services.AddTransient<IValidator<NewReferralVm>, NewReferralValidation>();

//zbiorcze dodawanie DependencyInjection oraz profili mapowania => RehaPatientMVC.Web.Configuration
builder.Services
    .AddApplication()
    .AddInterface()
    .AddMapping();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();


using Business.Abstracts;
using Business.Concretes;
using Business.Rules.Abstracts;
using Business.Rules.Concretes;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBrandService,BrandManager>();
builder.Services.AddSingleton<IBrandDal,EfBrandDal>();

builder.Services.AddSingleton<IColorService,ColorManager>();
builder.Services.AddSingleton<IColorDal,EfColorDal>();

builder.Services.AddSingleton<ICarService,CarManager>();
builder.Services.AddSingleton<ICarBusinessRules, CarBusinessRules>();
builder.Services.AddSingleton<ICarDal,EfCarDal>();

builder.Services.AddSingleton<ICustomerService,CustomerManager>();
builder.Services.AddSingleton<ICustomerDal,EfCustomerDal>();

builder.Services.AddSingleton<ICompanyService,CompanyManager>();
builder.Services.AddSingleton<ICompanyDal,EfCompanyDal>();

builder.Services.AddSingleton<IRentalService,RentalManager>();
builder.Services.AddSingleton<IRentalBusinessRules,RentalBusinessRules>();
builder.Services.AddSingleton<IRentalDal,EfRentalDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
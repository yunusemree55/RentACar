﻿using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Business.Rules.Abstracts;
using Business.Rules.Concretes;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{

    protected override void Load(ContainerBuilder builder)
    {

        builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
        builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

        builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
        builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

        builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
        builder.RegisterType<CarBusinessRules>().As<ICarBusinessRules>().SingleInstance();
        builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

        builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
        builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

        builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
        builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

        builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
        builder.RegisterType<RentalBusinessRules>().As<IRentalBusinessRules>().SingleInstance();
        builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();





    }


}
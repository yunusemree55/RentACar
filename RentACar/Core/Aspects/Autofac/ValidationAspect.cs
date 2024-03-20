using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess;
using Core.Utilities.Interceptors;
using DataAccess.Concretes.EntityFramework;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        private Type _dbType;

        public ValidationAspect(Type validatorType,Type dbType = null)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Doğrulama gerçekleştirilemiyor");
            }

            if(dbType != null)
            {
                _dbType = dbType;
            }

            _validatorType = validatorType;
            

        }


        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator = null;

            if (_dbType != null)
            {
                var entityDal = (IBaseEntityRepository)Activator.CreateInstance(_dbType);
                validator = (IValidator)Activator.CreateInstance(_validatorType, entityDal);
            }
            else
            {
                validator = (IValidator)Activator.CreateInstance(_validatorType);

            }

            

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);



            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

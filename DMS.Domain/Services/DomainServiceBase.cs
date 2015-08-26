using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.Domain;
using System.Diagnostics;
using FluentValidation;
using FluentValidation.Results;
using DMS.Domain.Repositories;
using DMS.Service;

namespace DMS.Domain.Services
{
    public abstract class DomainServiceBase<T> : IDomainService<T> where T : class
    {
        protected readonly IRepository<T> Repository;

        public DomainServiceBase(IRepository<T> repository)
        {
            Debug.Assert(repository != null);

            Repository = repository;
        }

        public virtual IEnumerable<T> GetAll(params string[] includes)
        {
            return Repository.GetAll(includes);
        }

        public virtual T Get(int id)
        {
            return Repository.Get(id);
        }

        public virtual void Add(T entity)
        {
            Repository.Add(entity);
            Repository.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            Repository.Update(entity);
            Repository.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
            Repository.SaveChanges();
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            Repository.Delete(entities);
            Repository.SaveChanges();
        }

        public static ValidationException CreateValidationException(string propertyName, string error)
        {
            return CreateValidationException(propertyName, error, null);
        }

        public static ValidationException CreateValidationException(string propertyName, string error, string attemptedValue)
        {
            return new ValidationException(new List<ValidationFailure>
            { 
                new ValidationFailure(propertyName, error, attemptedValue)
            });
        }

        public static ValidationException InvalidStatusValidationException(string message = null)
        {
            return CreateValidationException("status", message ?? ServiceResources.StatusIsInvalid);
        }
    }
}

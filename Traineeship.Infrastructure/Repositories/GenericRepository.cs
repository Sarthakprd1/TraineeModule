using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traineeship.Infrastructure.DBContext;
using Traineeship.Domain.Repositories.IServices;

namespace Traineeship.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;

        public GenericRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        #region Synchronous
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetByTwoId(int idOne, int idTwo)
        {
            return _dbContext.Set<T>().Find(idOne, idTwo);
        }

        //getBySerial
        public T GetBySerial(string serial)
        {
            return _dbContext.Set<T>().Find(serial);
        }

        public void Insert(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occurred", ex);
            }
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            //try
            //{
            //    var entityToUpdate = _DBContext.Set<T>().Find();
            //    if (entityToUpdate != null)
            //    {
            //        throw new ArgumentException("Entity not found by ID.", nameof(id));
            //    }
            //    _DBContext.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error Occured", ex);
            //}
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        //public int GetMaxId()
        //{
        //    var y = (_dbContext.Set<T>().ToList().Max(x => x.)) + 1;
        //}
        

        #endregion
    }
}

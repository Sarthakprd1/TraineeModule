using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traineeship.Domain.Repositories.IServices
{
    public interface IGenericRepository<T> where T : class
    {
        #region Synchronous
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetBySerial(string serial);
        int Save();
        T GetByTwoId(int idOne, int idTwo);

        #endregion
    }
}

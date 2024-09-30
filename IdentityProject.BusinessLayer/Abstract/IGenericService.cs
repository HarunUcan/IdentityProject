using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        public void TInsert(T t);
        public void TDelete(T t);
        public void TUpdate(T t);
        public List<T> TGetList();
        public T TGetByID(int id);
    }
}

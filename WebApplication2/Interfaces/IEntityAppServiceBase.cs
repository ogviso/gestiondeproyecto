using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IEntityAppServiceBase<E, D>
        where E : class, IEntityBase, new()
        where D : class, IDto, new()
    {
        IEnumerable<D> GetAll();

        D GetById(int id);

        D Update(D dto);

        void DeleteById(int id);

    }
}

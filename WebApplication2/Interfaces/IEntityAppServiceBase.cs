using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IEntityAppServiceBase<D>
        where D : class, IDto, new()
    {
        IEnumerable<D> GetAll();

        D GetById(int id);

        D Update(D dto);

        void DeleteById(int id);

    }
}

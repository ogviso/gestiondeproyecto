using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WebApplication2.Interfaces;
using WebApplication2.Interfaces.Repositories;

namespace WebApplication2.Services
{
    public class EntityAppServiceBase<E, D> : IEntityAppServiceBase<E, D>
        where E : class, IEntityBase, new()
        where D : class, IDto, new()
    {
        //protected readonly IUnitOfWork unitOfWork;
        protected readonly IEntityBaseRepository<E> entityRepository;

        public EntityAppServiceBase(IEntityBaseRepository<E> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public virtual IEnumerable<D> GetAll()
        {
            var query = this.entityRepository.GetAll();
            var entities = query.ToList();
            var dtos = Mapper.Map<IEnumerable<E>, IEnumerable<D>>(entities); // ver si es por version de Automapper!

            return dtos;
        }

        public virtual D GetById(int id)
        {
            var enti = this.entityRepository.GetSingle(id);
            var dtos = Mapper.Map<E, D>(enti);

            return dtos;
        }

        public virtual void DeleteById(int id)
        {
            using (var scope = new TransactionScope())
            {
                this.ValidarEntityDeleting(id);
                this.entityRepository.DeleteById(id);
                this.unitOfWork.Commit(); // aca commitear el borrado en base
                scope.Complete();
            }
        }

        public virtual D Update(D dto)
        {
            using (var scope = new TransactionScope())
            {
                E entity = null;
                entity = Mapper.Map<D, E>(dto);
                var isNew = (dto.ID == 0);

                this.ValidarEntityUpdating(entity, dto, isNew);

                if (dto.ID == 0)
                {
                    this.entityRepository.Add(entity);
                }
                else
                {
                    this.entityRepository.Edit(entity);
                }

                this.unitOfWork.Commit(); // aca commitear el update o insert de base
            }
        }

        protected virtual void ValidarEntityUpdating(E entity, D dto, bool isNew)
        {

        }

        protected virtual void ValidarEntityUpdated(E entity, D dto, bool isNew)
        {

        }

        protected virtual void ValidarEntityDeleting(int entityId)
        {

        }

        protected virtual void ValidarEntityDeleted(int entityId)
        {

        }

    }
}

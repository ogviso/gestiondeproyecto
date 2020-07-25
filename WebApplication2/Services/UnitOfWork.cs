using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.Interfaces.Repositories;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext dbContext;
        // VER COMO IMPLEMENTAR ESTO
        //public UnitOfWork()

        public void Commit()
        {
            dbContext.Commit();
        }
    }
}

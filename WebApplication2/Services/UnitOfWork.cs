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
        private readonly IDbFactory<ApplicationDbContext> dbFactory;
        private ApplicationDbContext dbContext;
        
        public UnitOfWork(IDbFactory<ApplicationDbContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public ApplicationDbContext DbContext
        {
            get { return DbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            dbContext.Commit();
        }
    }
}

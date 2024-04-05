using Application.Repositories.IRepository;
using Application.Repositories.Repository;
using Infrastructure.Persistence.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LuftBornContext _context;
       public IItemRepository Item { get; private set; }
        public UnitOfWork(LuftBornContext context)
        {
            _context=context;
            Item = new ItemRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

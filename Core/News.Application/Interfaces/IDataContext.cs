using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Interfaces
{
    public interface IDataContext
    {
        
        DbSet<Users> Users { get;}
        public DbSet<Photos> Photos {get;}
        public DbSet<News.Domain.Entities.News> News {get;}
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

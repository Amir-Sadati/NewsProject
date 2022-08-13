using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Context
{
    public class DataContext : DbContext , IDataContext
    {
       
        public DataContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Users> Users {get;set;}
        public DbSet<Photos> Photos { get; set; }
        public DbSet<News.Domain.Entities.News> News { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
           
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

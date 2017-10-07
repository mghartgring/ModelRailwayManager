using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayCottageManager.Shared.Services
{
    public class DatabaseService : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Locomotive> Locomotives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mrm.db, Version=3");
            
        }

        public void AddAndSave<U>(U elem) where U : class
        {
            Add(elem);
            SaveChanges();
        }
        
        public void RemoveAndSave<U>(U elem) where U : class
        {
            Remove(elem);
            SaveChanges();
        }

        public void UpdateAndSave<U>(U elem) where U : class
        {
            Update(elem);
            SaveChanges();
        }

        public DatabaseService()
        {
            
        }
    }
}

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
        public DbSet<Train> Trains { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mrm.db, Version=3");
        }
        public DatabaseService()
        {
            
        }
    }
}

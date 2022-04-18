using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.EF
{
    public class ChessTrainerContext : DbContext
    {
        public ChessTrainerContext() : base("ConnectionString")
        {
        }
        public DbSet<MaterialAdvantage> MaterialAdvantages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ChessTrainerContext>(null);
            base.OnModelCreating(modelBuilder);
        }

    }
}

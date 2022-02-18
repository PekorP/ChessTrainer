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
    }
}

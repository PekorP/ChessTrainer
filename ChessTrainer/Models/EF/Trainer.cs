using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.EF
{
    [Table("Trainers")]
    public class Trainer
    {
        public int ID { get; set; }
        public string TrainerName{ get; set; }
    }
}

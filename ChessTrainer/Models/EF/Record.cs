using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.EF
{
    [Table("Records")]
    public class Record
    {
        public int ID { get; set; }
        public int IdUser { get; set; }
        public int IdTrainer { get; set; }
        public int Result { get; set; }
    }
}

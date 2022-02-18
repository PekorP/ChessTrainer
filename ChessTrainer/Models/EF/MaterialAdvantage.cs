using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.EF
{
    [Table("MaterialAdvantage")]
    public class MaterialAdvantage
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public int Advantage { get; set; }
    }
}

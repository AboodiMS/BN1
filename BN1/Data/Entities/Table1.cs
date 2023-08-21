using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BN1.Data.Entities
{
    public class Table1
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Desimal { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid CreateBy { get; set; } = Guid.NewGuid();

    }
}

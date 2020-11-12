using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceServ
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [MinLength(3), MaxLength(50)]
        public string name { get; set; }

        [MaxLength(150)]
        public string description { get; set; }

        [Required]
        public decimal price { get; set; }

        [ForeignKey("category")]
        public virtual ProductCategory category { get; set; }
    }
}

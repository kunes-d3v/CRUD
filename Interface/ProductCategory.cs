using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterfaceServ
{
    [Table("productscategories")]
    public class ProductCategory
    {
        [Key]
        public int id { get; set; }

        [MinLength(3), MaxLength(50)]
        public string name { get; set; }

        [MaxLength(150)]
        public string description { get; set; }

        [ForeignKey("products")]
        public virtual ICollection<Product> products { get; set; }
    }
}

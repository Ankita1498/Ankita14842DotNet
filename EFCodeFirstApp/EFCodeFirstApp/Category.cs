using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstApp
{
    [Table("Category")]
   public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        [Column(TypeName ="varchar(20)")]
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

    }
}

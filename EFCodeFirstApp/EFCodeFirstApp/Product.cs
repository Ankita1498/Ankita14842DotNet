using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstApp
{
    [Table("Product")]
   public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        [Column(TypeName ="varchar(20)")]
        public string ProductName { get; set; }
        [ForeignKey("CatgeoryId")]

        public Category Category { get; set; }

        [Column(TypeName ="numeric(10,2)")]
        public decimal?Price { get; set; }
    }
}

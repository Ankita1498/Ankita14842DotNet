using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFCodeFirstAssignment
{
    [Table("Book")]
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int BookId { get; set; }
        [ForeignKey("PublisherId")]

        public Publisher Publisher { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string BookName { get; set; }
    }
}

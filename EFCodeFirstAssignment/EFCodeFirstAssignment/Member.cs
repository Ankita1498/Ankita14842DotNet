using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstAssignment
{
    [Table("Member")]
    public class Member
    {
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int MemberId { get; set; }

            [Column(TypeName = "varchar(20)")]
            public string MemberName { get; set; }
        
    }
}

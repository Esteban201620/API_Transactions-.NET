using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TransactionsAPI.Entities.Users;

namespace TransactionsAPI.Entities.Users
{
    public class UserProfile
    {
        [Key]
        [Precision(16, 0)]
        public decimal account { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [StringLength(maximumLength: 100)]
        public string name { get; set; }

        [Required]
        [Precision(15,0)]
        public decimal dni { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string email { get; set; }        

        [ForeignKey("Bank")]
        public int fkBank { get; set; }
        public Bank Bank { get; set; }

        public List<Transaction> Transaction { get; set; }

    }
}

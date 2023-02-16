using TransactionsAPI.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionsAPI.Entities.Users
{
    public class Transaction
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Precision(20,0)]
        public decimal amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [ForeignKey("UserProfile")]
        public decimal fkUser { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TransactionsAPI.DTOs.Users.Creation
{
    public class TransactionQueryDTO
    {
        public int id { get; set; }

        [Required]
        [Precision(20, 0)]
        public decimal amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public decimal fkUser { get; set; }
    }
}

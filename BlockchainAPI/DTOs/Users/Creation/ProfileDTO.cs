using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace TransactionsAPI.DTOs.Users.Creation
{
    public class ProfileDTO
    {
        public decimal account { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [StringLength(maximumLength: 100)]
        public string name { get; set; }

        [Required]
        [Precision(15, 0)]
        public decimal dni { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string email { get; set; }

        public int fkBank { get; set; }
    }
}

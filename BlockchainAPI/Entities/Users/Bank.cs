using TransactionsAPI.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace TransactionsAPI.Entities.Users
{
    public class Bank
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nameBank { get; set; }

        public List<UserProfile> UserProfile { get; set; }
    }
}

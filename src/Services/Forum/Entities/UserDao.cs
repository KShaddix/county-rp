using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class UserDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }

        [MinLength(3)]
        [MaxLength(32)]
        public string Login { get; }

        [MinLength(3)]
        [MaxLength(16)]
        public string GroupId { get; }
        public int Reputation { get; }
        public int Posts { get; }
        public int Warnings { get; }

        public UserDao(int id,
            string login,
            string groupId,
            int reputation,
            int posts,
            int warnings)
        {
            Id = id;
            Login = login;
            GroupId = groupId;
            Reputation = reputation;
            Posts = posts;
            Warnings = warnings;
        }
    }
}

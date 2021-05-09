using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class ForumDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }

        [MaxLength(96)]
        public string Name { get; }
        public int ParentId { get; }
        public int Order { get; }

        public ForumDao(int id,
            string name,
            int parentId,
            int order)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Order = order;
        }
    }
}

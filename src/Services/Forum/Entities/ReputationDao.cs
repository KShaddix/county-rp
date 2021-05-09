using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class ReputationDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public int UserId { get; }
        public int ChangedByUserId { get; }
        public DateTime DateTime { get; }
        public int Action { get; }

        [MaxLength(128)]
        public string Text { get; }

        public ReputationDao(int id,
            int userId,
            int changedByUserId,
            DateTime dateTime,
            int action,
            string text)
        {
            Id = id;
            UserId = userId;
            ChangedByUserId = changedByUserId;
            DateTime = dateTime;
            Action = action;
            Text = text;
        }
    }
}

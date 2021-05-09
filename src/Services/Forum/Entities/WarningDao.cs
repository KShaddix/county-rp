using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class WarningDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public int UserId { get; }
        public int AdminId { get; }
        public DateTimeOffset DateTime { get; }
        public DateTimeOffset FinishDateTime { get; }
        public int Action { get; }

        [MaxLength(128)]
        public string Text { get; }

        public WarningDao(int id,
            int userId,
            int adminId,
            DateTimeOffset dateTime,
            DateTimeOffset finishDateTime,
            int action,
            string text)
        {
            Id = id;
            UserId = userId;
            AdminId = adminId;
            DateTime = dateTime;
            FinishDateTime = finishDateTime;
            Action = action;
            Text = text;
        }
    }
}

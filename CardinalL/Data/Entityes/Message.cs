using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardinalL.Data.Entityes
{
    public class Message
    {
        [Key]
        [Column("MessageId")]
        public int MessageId { get; set; }

        public string Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Внешний ключ для связи с таблицей User
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Внешний ключ для связи с таблицей ChatBox
        [ForeignKey("ChatId")]
        public ChatBox ChatBox { get; set; }
    }
}

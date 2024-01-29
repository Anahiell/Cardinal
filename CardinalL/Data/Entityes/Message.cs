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
        [Column("userID")]
        public int UserId { get; set; }
        [Column("ChatBoxID")]
        public int ChatId { get; set; }
    }
}

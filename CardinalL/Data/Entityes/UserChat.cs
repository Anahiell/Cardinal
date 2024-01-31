using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardinalL.Data.Entityes
{
    public class UserChat
    {
        [Key]
        [Column("UserChatId")]
        public int UserChatId { get; set; }

        [ForeignKey("ChatBox")]
        [Column("ChatId")]
        public int ChatId { get; set; }
        public ChatBox ChatBox { get; set; }

        // Внешний ключ для связи с таблицей User
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
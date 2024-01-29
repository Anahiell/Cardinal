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
        [Column("ChatBoxId")]
        public int UserId { get; set; }

        public int ChatId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardinalL.Data.Entityes
{
    public class ChatBox
    {
        [Key]
        public int ChatId { get; set; }
        public string ChatName { get; set; }

        // Навигационное свойство для сообщений в чате
        public ICollection<Message> Messages { get; set; }

        // Навигационное свойство для связи с пользователями в чате
        public ICollection<UserChat> UserChats { get; set; }
    }
}

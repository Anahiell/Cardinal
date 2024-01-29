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
        [Column("ChatBoxId")]
        public int ChatId { get; set; }
        public string ChatName { get; set; }
    }
}

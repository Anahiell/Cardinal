using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardinalL.Data.Entityes
{
    public class Friend
    {
        [Key]
        [Column("id")]
        public int FriendshipId { get; set; }

        [ForeignKey("User1Id")]
        public User User1 { get; set; }

        [Column("user1id")]
        public int User1Id { get; set; }

        [ForeignKey("User2Id")]
        public User User2 { get; set; }

        [Column("user2id")]
        public int User2Id { get; set; }

        public string Status { get; set; }
    }
}

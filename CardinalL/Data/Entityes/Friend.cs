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

        // Идентификатор первого пользователя в дружбе
        [Column("user1_id")]
        public int User1Id { get; set; }

        // Идентификатор второго пользователя в дружбе
        [Column("user2_id")]
        public int User2Id { get; set; }
        // Статус дружбы (например, "Друзья", "В ожидании", "Заблокировано" и т. д.)
        public string Status { get; set; }
    }
}

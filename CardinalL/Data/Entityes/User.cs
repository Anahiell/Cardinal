using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardinalL.Data.Entityes
{
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Login { get; set; } = null!;
        public int CheckCode { get; set; }

        // Свойство для хранения данных изображения аватара
        public byte[]? AvatarData { get; set; }

        // Навигационное свойство для хранения списка друзей
        public virtual ICollection<Friend> Friends { get; set; } = new List<Friend>();
        public ICollection<UserChat> UserChats { get; set; }
    }
}

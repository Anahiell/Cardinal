using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace CardinalL.Data.Entityes
{
    public class DataContext : DbContext
    {
        public DbSet<Entityes.User> Users { get; set; }
        public DbSet<Entityes.Friend> Friends { get; set; }
        public DbSet<Entityes.ChatBox> Chats { get; set; }
        public DbSet<Entityes.UserChat> UserChats { get; set; }
        public DbSet<Entityes.Message> Messages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = JsonSerializer.Deserialize<JsonNode>(File.ReadAllText("CardinalPconfig.json"));
            string? connectionString = config?["databases"]?["planetScale"]?["connectionString"]?.ToString();
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 34))
            );
        }

        public bool AuthenticateUser(string usernameOrEmail, string password)
        {
            // Проверка аутентификации пользователя
            var user = Users.SingleOrDefault(u => u.Email == usernameOrEmail || u.Login == usernameOrEmail);

            if (user != null)
            {
                if (user.Password == password)
                {
                    return true; // Пользователь успешно аутентифицирован
                }
            }

            return false; // Неверное имя пользователя или пароль
        }
    }
}

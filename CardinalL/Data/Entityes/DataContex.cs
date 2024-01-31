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
            string projectRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
            string configPath = Path.Combine(projectRoot, "CardinalConfig.json");

            var config = JsonSerializer.Deserialize<JsonNode>(File.ReadAllText(configPath));
            string? connectionString = config?["databases"]?["connectionString"]?.ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User1)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User2)
                .WithMany()
                .HasForeignKey(f => f.User2Id)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
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
        public int GetUserIdByUsernameOrEmail(string usernameOrEmail)
        {
            var user = Users.SingleOrDefault(u => u.Login == usernameOrEmail || u.Email == usernameOrEmail);

            if (user != null)
            {
                return user.Id; 
            }

            return -1;
        }
    }
}

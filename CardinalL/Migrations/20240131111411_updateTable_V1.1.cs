using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardinalL.Migrations
{
    /// <inheritdoc />
    public partial class updateTable_V11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatBoxID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Chats_ChatBoxId",
                table: "UserChats");

            migrationBuilder.RenameColumn(
                name: "ChatBoxId",
                table: "UserChats",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_UserChats_ChatBoxId",
                table: "UserChats",
                newName: "IX_UserChats_ChatId");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ChatBoxID",
                table: "Messages",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_userID",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatBoxID",
                table: "Messages",
                newName: "IX_Messages_ChatId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserChats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_UserId",
                table: "UserChats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Users_UserId",
                table: "UserChats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Users_UserId",
                table: "UserChats");

            migrationBuilder.DropIndex(
                name: "IX_UserChats_UserId",
                table: "UserChats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserChats");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "UserChats",
                newName: "ChatBoxId");

            migrationBuilder.RenameIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChats",
                newName: "IX_UserChats_ChatBoxId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Messages",
                newName: "ChatBoxID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_userID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                newName: "IX_Messages_ChatBoxID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatBoxID",
                table: "Messages",
                column: "ChatBoxID",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_userID",
                table: "Messages",
                column: "userID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Chats_ChatBoxId",
                table: "UserChats",
                column: "ChatBoxId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardinalL.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "UserChats");

            migrationBuilder.RenameColumn(
                name: "user2_id",
                table: "Friends",
                newName: "user2id");

            migrationBuilder.RenameColumn(
                name: "user1_id",
                table: "Friends",
                newName: "user1id");

            migrationBuilder.RenameColumn(
                name: "ChatBoxId",
                table: "Chats",
                newName: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_ChatBoxId",
                table: "UserChats",
                column: "ChatBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatBoxID",
                table: "Messages",
                column: "ChatBoxID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_userID",
                table: "Messages",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_user1id",
                table: "Friends",
                column: "user1id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_user2id",
                table: "Friends",
                column: "user2id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_user1id",
                table: "Friends",
                column: "user1id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_user2id",
                table: "Friends",
                column: "user2id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_user1id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_user2id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatBoxID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Chats_ChatBoxId",
                table: "UserChats");

            migrationBuilder.DropIndex(
                name: "IX_UserChats_ChatBoxId",
                table: "UserChats");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatBoxID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_userID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Friends_user1id",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_user2id",
                table: "Friends");

            migrationBuilder.RenameColumn(
                name: "user2id",
                table: "Friends",
                newName: "user2_id");

            migrationBuilder.RenameColumn(
                name: "user1id",
                table: "Friends",
                newName: "user1_id");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Chats",
                newName: "ChatBoxId");

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "UserChats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renametoparticipantS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationParticipant_AspNetUsers_UserId",
                table: "ConversationParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationParticipant_Conversations_ConversationId",
                table: "ConversationParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversationParticipant",
                table: "ConversationParticipant");

            migrationBuilder.RenameTable(
                name: "ConversationParticipant",
                newName: "ConversationParticipants");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationParticipant_UserId",
                table: "ConversationParticipants",
                newName: "IX_ConversationParticipants_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversationParticipants",
                table: "ConversationParticipants",
                columns: new[] { "ConversationId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationParticipants_AspNetUsers_UserId",
                table: "ConversationParticipants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationParticipants_Conversations_ConversationId",
                table: "ConversationParticipants",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationParticipants_AspNetUsers_UserId",
                table: "ConversationParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationParticipants_Conversations_ConversationId",
                table: "ConversationParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversationParticipants",
                table: "ConversationParticipants");

            migrationBuilder.RenameTable(
                name: "ConversationParticipants",
                newName: "ConversationParticipant");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationParticipants_UserId",
                table: "ConversationParticipant",
                newName: "IX_ConversationParticipant_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversationParticipant",
                table: "ConversationParticipant",
                columns: new[] { "ConversationId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationParticipant_AspNetUsers_UserId",
                table: "ConversationParticipant",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationParticipant_Conversations_ConversationId",
                table: "ConversationParticipant",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

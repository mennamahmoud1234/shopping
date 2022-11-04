using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping.Data.Migrations
{
    public partial class addroletoadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.Sql("INSERT INTO [dbo].[UserRoles] (UserId,RoleId) SELECT '91b8ca10-6c64-4251-b051-2779a39e58b6' ,Id FROM [dbo].[Roles]");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[UserRoles] WHERE UserId='91b8ca10-6c64-4251-b051-2779a39e58b6'");

        }
    }
}

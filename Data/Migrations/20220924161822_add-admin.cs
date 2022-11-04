﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping.Data.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'91b8ca10-6c64-4251-b051-2779a39e58b6', N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEM9vufBcmadvQDgSdDkarI1EFWA+1LAS65MkHiUmIpDTJ89Av6FoEM2NWZKQciHLqA==', N'63WK7YM3FFGZI72KCCXFTENWGFLENOQV', N'535258db-bbd6-4674-9b4d-e0630337c101', NULL, 0, 0, NULL, 1, 0, N'menna', N'afifi')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM[dbo].[User] WHERE Id='91b8ca10-6c64-4251-b051-2779a39e58b6'");
        }
    }
}

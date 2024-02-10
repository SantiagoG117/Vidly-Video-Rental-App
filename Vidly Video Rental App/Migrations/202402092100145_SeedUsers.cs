namespace Vidly_Video_Rental_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c5d0435c-0949-4d17-907f-7950887d196b', N'guest@vidly.com', 0, N'APSy/RnFEhdcpzltWmCUC7iKjp7p08oHA092HdUQYXVHdl5FMmCukjCP6ih9X2aTjw==', N'99c0d105-fc21-4bf2-b8d7-18f9eeffd459', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f68e7f79-0f1f-4117-8525-d54468e84341', N'admin@vidly.com', 0, N'AMtDvEhitnya8DTqNqIYDaBKske8vdZxN5Q6fx1iyRQQIEeEM7xknYkXl7pypRYhgQ==', N'dee8d090-5530-4b98-bc9f-78102673bc66', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'23ee596a-19a8-4e96-aa94-c65a968170dc', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f68e7f79-0f1f-4117-8525-d54468e84341', N'23ee596a-19a8-4e96-aa94-c65a968170dc')

                ");
        }
        
        public override void Down()
        {
        }
    }
}

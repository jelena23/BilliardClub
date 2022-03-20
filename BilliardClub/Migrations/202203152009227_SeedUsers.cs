namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3ef42571-9777-4ef2-b5b9-1a32eec7f479', N'filip@bclub.com', 0, N'AN3YStLIc4YEHnyigvzuEiGPVT8I/LyHHXJXs5eraFVryKuVvOWWuIKfBTP516iE4A==', N'a79ca405-3f83-4408-b364-68413f51e7ab', NULL, 0, 0, NULL, 1, 0, N'filip@bclub.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7826e165-03a7-4006-bb50-c442aa0cd2fa', N'marija@umail.com', 0, N'ACiXqvx99inDfw+PzmVWMn/A9Nnht8TA785PuXxzvNzo1nAumIt+yAYIilnnKgV1Qg==', N'103e149a-1512-41cd-ac16-523f234a06c7', NULL, 0, 0, NULL, 1, 0, N'marija@umail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'93912f02-b6bf-47f7-802f-64a4602701d9', N'Employee')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ef42571-9777-4ef2-b5b9-1a32eec7f479', N'93912f02-b6bf-47f7-802f-64a4602701d9')
");
        }
        
        public override void Down()
        {
        }
    }
}

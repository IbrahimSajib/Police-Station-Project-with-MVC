using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Police_Station.Models.DbContext
{
    public static class SeedDataExtensions
    {
        //Seed Role
        public static void SeedRole(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "70cecf66-f00e-406f-ae29-0feb2183689c",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "f672f1be-450b-4899-b9a5-13a0ff856015",
                    Name = "Police",
                    NormalizedName = "Police"
                }
                );
        }

        //Seed User
        public static void SeedUser(this ModelBuilder builder)
        {
            //PasswordHasher
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            //Creating User
            var user1 = new IdentityUser
            {
                Id = "c02f71c8-a822-4b3a-900c-5c62478b32f0",
                UserName = "Admin1@gmail.com",
                NormalizedUserName = "ADMIN1@GMAIL.COM",
                Email = "Admin1@gmail.com",
                NormalizedEmail = "ADMIN1@GMAIL.COM",
            };
            user1.PasswordHash = ph.HashPassword(user1, "Admin1@gmail.com"); //Set user password

            var user2 = new IdentityUser
            {
                Id = "4b9d054d-bcb0-475e-96be-7e07d5ee3b85",
                UserName = "Police1@gmail.com",
                NormalizedUserName = "POLICE1@GMAIL.COM",
                Email = "Police1@gmail.com",
                NormalizedEmail = "POLICE1@GMAIL.COM",
            };
            user2.PasswordHash = ph.HashPassword(user2, "Police1@gmail.com");

            var user3 = new IdentityUser
            {
                Id = "b7f46612-41d2-47ba-af30-f957a680d92a",
                UserName = "Ibrahim@example.com",
                NormalizedUserName = "IBRAHIM@EXAMPLE.COM",
                Email = "Ibrahim@example.com",
                NormalizedEmail = "IBRAHIM@EXAMPLE.COM",
            };
            user3.PasswordHash = ph.HashPassword(user3, "Ibrahim1@example.com");

            var user4 = new IdentityUser
            {
                Id = "0442b285-375d-48a0-8f47-d6e21bf342c9",
                UserName = "Sajib@example.com",
                NormalizedUserName = "SAJIB@EXAMPLE.COM",
                Email = "Sajib@example.com",
                NormalizedEmail = "SAJIB@EXAMPLE.COM",
            };
            user4.PasswordHash = ph.HashPassword(user4, "Sajib1@example.com");

            //Seed User
            builder.Entity<IdentityUser>().HasData(user1, user2, user3, user4);
        }


        //Seed User Role
        public static void SeedUserRole(this ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "c02f71c8-a822-4b3a-900c-5c62478b32f0", RoleId = "70cecf66-f00e-406f-ae29-0feb2183689c" },
                new IdentityUserRole<string> { UserId = "4b9d054d-bcb0-475e-96be-7e07d5ee3b85", RoleId = "f672f1be-450b-4899-b9a5-13a0ff856015" },
                new IdentityUserRole<string> { UserId = "b7f46612-41d2-47ba-af30-f957a680d92a", RoleId = "70cecf66-f00e-406f-ae29-0feb2183689c" },
                new IdentityUserRole<string> { UserId = "0442b285-375d-48a0-8f47-d6e21bf342c9", RoleId = "70cecf66-f00e-406f-ae29-0feb2183689c" }
                );
        }


        //Seed Prison
        public static void SeedPrison(this ModelBuilder builder)
        {
            builder.Entity<Prison>().HasData(
                    new Prison
                    {
                        PrisonId = 1,
                        PrisonName = "Dhaka Central Jail",
                        Location = "Keraniganj, Dhaka",
                        Capacity = 8000,
                        ContactInfo = "+8801712345678"
                    },
                    new Prison
                    {
                        PrisonId = 2,
                        PrisonName = "Chittagong Central Jail",
                        Location = "Chittagong",
                        Capacity = 2000,
                        ContactInfo = "+8801812312345"
                    },
                    new Prison
                    {
                        PrisonId = 3,
                        PrisonName = "Rajshahi Central Jail",
                        Location = "Rajshahi",
                        Capacity = 1500,
                        ContactInfo = "+8801912341234"
                    }
                );
        }



        //Seed Prison
        public static void SeedPoliceOfficer(this ModelBuilder builder)
        {
            builder.Entity<PoliceOfficer>().HasData(
                   new PoliceOfficer { PoliceOfficerId = 1, BadgeNumber = 123, Name = "Officer A", DateOfBirth = new DateTime(1980, 5, 1), Rank = "Sergeant", BadgeType = "Metal", JoinDate = new DateTime(2000, 1, 1), Salary = 50000, Shift = "Day", Supervisor = "Chief B", Department = "Homicide" },

    new PoliceOfficer { PoliceOfficerId = 2, BadgeNumber = 124, Name = "Officer B", DateOfBirth = new DateTime(1981, 6, 2), Rank = "Lieutenant", BadgeType = "Plastic", JoinDate = new DateTime(2001, 2, 2), Salary = 60000, Shift = "Night", Supervisor = "Chief A", Department = "Robbery" },
    new PoliceOfficer { PoliceOfficerId = 3, BadgeNumber = 125, Name = "Officer C", DateOfBirth = new DateTime(1982, 7, 3), Rank = "Captain", BadgeType = "Metal", JoinDate = new DateTime(2002, 3, 3), Salary = 70000, Shift = "Day", Supervisor = "Chief B", Department = "Fraud" },
    new PoliceOfficer { PoliceOfficerId = 4, BadgeNumber = 126, Name = "Officer D", DateOfBirth = new DateTime(1983, 8, 4), Rank = "Detective", BadgeType = "Plastic", JoinDate = new DateTime(2003, 4, 4), Salary = 80000, Shift = "Night", Supervisor = "Chief A", Department = "Narcotics" },
    new PoliceOfficer { PoliceOfficerId = 5, BadgeNumber = 127, Name = "Officer E", DateOfBirth = new DateTime(1984, 9, 5), Rank = "Inspector", BadgeType = "Metal", JoinDate = new DateTime(2004, 5, 5), Salary = 90000, Shift = "Day", Supervisor = "Chief B", Department = "Patrol" },
    new PoliceOfficer { PoliceOfficerId = 6, BadgeNumber = 128, Name = "Officer F", DateOfBirth = new DateTime(1985, 10, 6), Rank = "Sergeant", BadgeType = "Plastic", JoinDate = new DateTime(2005, 6, 6), Salary = 100000, Shift = "Night", Supervisor = "Chief A", Department = "Traffic" },
    new PoliceOfficer { PoliceOfficerId = 7, BadgeNumber = 129, Name = "Officer G", DateOfBirth = new DateTime(1986, 11, 7), Rank = "Lieutenant", BadgeType = "Metal", JoinDate = new DateTime(2006, 7, 7), Salary = 110000, Shift = "Day", Supervisor = "Chief B", Department = "Homicide" },
    new PoliceOfficer { PoliceOfficerId = 8, BadgeNumber = 130, Name = "Officer H", DateOfBirth = new DateTime(1987, 12, 8), Rank = "Captain", BadgeType = "Plastic", JoinDate = new DateTime(2007, 8, 8), Salary = 120000, Shift = "Night", Supervisor = "Chief A", Department = "Robbery" },
    new PoliceOfficer { PoliceOfficerId = 9, BadgeNumber = 131, Name = "Officer I", DateOfBirth = new DateTime(1988, 1, 9), Rank = "Detective", BadgeType = "Metal", JoinDate = new DateTime(2008, 9, 9), Salary = 130000, Shift = "Day", Supervisor = "Chief B", Department = "Fraud" },
    new PoliceOfficer { PoliceOfficerId = 10, BadgeNumber = 132, Name = "Officer J", DateOfBirth = new DateTime(1989, 2, 10), Rank = "Inspector", BadgeType = "Plastic", JoinDate = new DateTime(2009, 10, 10), Salary = 140000, Shift = "Night", Supervisor = "Chief A", Department = "Narcotics" }
                );
        }


    }
}

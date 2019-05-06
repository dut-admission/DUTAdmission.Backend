namespace DUTAdmissionSystem.Database.Migrations
{
    using DUTAdmissionSystem.Database.Schema.Entity;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DUTAdmissionSystem.Database.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DUTAdmissionSystem.Database.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.AccountGroups.AddOrUpdate(x => x.Name,
                new Schema.Entity.AccountGroup() { Name = "Admin" },
                new Schema.Entity.AccountGroup() { Name = "Employee" },
                new Schema.Entity.AccountGroup() { Name = "Student" }
                );

            context.Accounts.AddOrUpdate(x => x.UserName,
                new Account()
                {
                    UserInfo = new UserInfo()
                    {
                        FirstName = "An",
                        LastName = "Trinh",
                        Avatar = "https://png.pngtree.com/svg/20161027/631929649c.svg",
                        BirthInfo = new BirthInfo()
                        {
                            Sex = true,
                            DateOfBirth = DateTime.Now,
                            PlaceOfBirth = "Da Nang"
                        },
                        ContactInfo = new ContactInfo()
                        {
                            Address = "K82/34, Nguyen Luong Bang, Da Nang.",
                            Email = "trinhminhan1996@gmail.com",
                            PhoneNumber = "0772142887"
                        },
                        IdentityInfo = new IdentityInfo()
                        {
                            IdentityNumber = "205796190",
                            DateOfIssue = DateTime.Now,
                            PlaceOfIssue = "Quang Nam"
                        }
                    },
                    AccountGroup = new AccountGroup()
                    {
                        Name = "Student"
                    },
                    Token = "",
                    UserName = "102140055",
                    Password = "password"
                });
        }
    }
}
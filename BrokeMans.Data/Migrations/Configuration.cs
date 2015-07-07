namespace BrokeMans.Data.Migrations
{
    using BrokeMans.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<BrokeMans.Data.BrokeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BrokeContext context)
        {
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);

            RoleStore<Role> roleStore = new RoleStore<Role>(context);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new Role
                {
                    Name = "Admin"
                });
            }
            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new Role
                {
                    Name = "User"
                });
            }
            ApplicationUser Chris = manager.FindByEmail("cgriffin.902@gmail.com");
            if (Chris == null)
            {
                manager.Create(new ApplicationUser
                {
                    UserName = "chris",
                    Email = "cgriffin.902@gmail.com",
                    
                }, "123456");
                Chris = manager.FindByEmail("cgriffin.902@gmail.com");
                manager.AddToRole(Chris.Id, "Admin");
            }
            ApplicationUser Tiff = manager.FindByEmail("daking_234@yahoo.com");
            if (Tiff == null)
            {
                manager.Create(new ApplicationUser
                {
                    UserName = "tiff",
                    Email = "daking_234@yahoo.com"
                }, "123456");
                Tiff = manager.FindByEmail("daking_234@yahoo.com");
                manager.AddToRole(Tiff.Id, "User");
            }
            context.Items.AddOrUpdate(i => i.Id,
                new Item { Id = 1, UserId = Chris.Id, Title = "RAMEN", Pic = "http://ramenguy.files.wordpress.com/2013/03/img_0829.jpg", Description = "this is cheap but okay" },
                new Item { Id = 2, UserId = Tiff.Id, Title = "Chicken Ramin", Pic = "https://tse1.mm.bing.net/th?&id=JN.vaCP%2bQPCXyzuXmrRXRD6fw&w=300&h=300&c=0&pid=1.9&rs=0&p=0", Description = "this is better than the original Ramen" },
                new Item { Id = 3, UserId = Tiff.Id, Title = "Beef Ramin", Pic = "http://www.totalgifs.com/naruto/03%20(2).gif", Description = "this is better than the Chicken Ramen" },
                new Item { Id = 4, UserId = Chris.Id, Title = "Spicy Ramin", Pic = "https://c2.staticflickr.com/4/3708/10078599895_1e3a53110e_z.jpg", Description = "this is better than the Beef Ramen" }
                );
            context.Comments.AddOrUpdate(c => c.Id,
                new Comment { Id = 1, ItemId = 3, UserComment = "this is from chris on Beef", UserId = Chris.Id, DateCreated = DateTime.UtcNow },
                new Comment { Id = 2, ItemId = 2, UserComment = "this is from chris on Chicken", UserId = Chris.Id, DateCreated = DateTime.UtcNow },
                new Comment { Id = 3, ItemId = 1, UserComment = "this is from tiff on ramen", UserId = Tiff.Id, DateCreated = DateTime.UtcNow },
                new Comment { Id = 4, ItemId = 4, UserComment = "this is from tiff on spicy", UserId = Tiff.Id, DateCreated = DateTime.UtcNow });



        }
    }
}

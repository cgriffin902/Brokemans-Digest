using System;
using System.Linq;
using System.Web;
using BrokeMans.Data;
using BrokeMans.Models;
using BrokeMans.Data.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
namespace BrokeMans.Adapters.Data.ItemDetailsData
{
    public class ItemsData : IItem
    {
        
        
        private BrokeContext context = new BrokeContext();
        public ItemViewModel GetItemDetails(int id)
        {
            ItemViewModel model = context.Items.Where(i => i.Id == id)
                .Select(i => new ItemViewModel
            {
                Id = i.Id,
                UserName = i.User.UserName,
                Description = i.Description,
                Pic = i.Pic,
                Title = i.Title,
                commentViewModel = context.Comments.Where(c => c.ItemId == id).Select(c => new CommentViewModel
                {
                    UserComment = c.UserComment,
                    TimeStamp = c.DateCreated,
                    Commenter = c.User.UserName
                }).OrderBy(t => t.TimeStamp).ToList()

            }).FirstOrDefault();


            return model;
        }


        public ItemListViewModel Get4ItemPics()
        {

            ItemListViewModel model = context.Items.Select(i =>
                    new ItemListViewModel
                    {
                        ItemList = context.Items.Select(l => new ItemViewModel
                        {
                            Pic = l.Pic,
                            Id = l.Id
                        }).OrderBy(v => Guid.NewGuid()).Take(4).ToList()

                    }).FirstOrDefault();
            return model;
        }


        public ItemListViewModel GetAllItems() 
        {
            ItemListViewModel model = context.Items.Select(i => new ItemListViewModel
                {
                    ItemList = context.Items.Select(l => new ItemViewModel
                    {
                        Title = l.Title,
                        Id = l.Id
                    }).OrderBy(x => x.Title).ToList()

                }).FirstOrDefault();
            return model;
        }

       
        public Item Create(Item item, ApplicationUser user)
        {
            if (item != null)
            {
                context.Items.Add(new Item
                {
                    Description = item.Description,
                    Title = item.Title,
                    Pic = item.Pic,
                    UserId = HttpContext.Current.User.Identity.GetUserId()
                });
                context.SaveChanges();
            }
            return item;
        }

        public Item GetEdit(Item item, ApplicationUser user, int id)
        {
            //Item model = context.Items.Where(i => i.Id == id).FirstOrDefault();
            item = context.Items.Find(id);

            return item;
        }

        public Item PostEdit(Item item, int id)
        {
            Item model = context.Items.Where(i => i.Id == id).FirstOrDefault();
            if (model != null)
            {
                model.Pic = item.Pic;
                model.Title = item.Title;
                model.Description = item.Description;
                context.SaveChanges();
            }
            return model;
        }
        public void Delete(int id)
        {
            var item = context.Items.Where(i => i.Id == id).FirstOrDefault();
            context.Items.Remove(item);
            context.SaveChanges();
        }


    }
}
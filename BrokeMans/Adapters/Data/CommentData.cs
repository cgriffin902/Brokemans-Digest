using BrokeMans.Data;
using BrokeMans.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using BrokeMans.Models;
namespace BrokeMans.Adapters.Data
{
    public class CommentData : IComments
    {
        private BrokeContext context = new BrokeContext();
        public Comment CreateComment( Comment comment,int id)
        {
            Comment c =new Comment();
            c.ItemId = id;
            c.DateCreated = DateTime.UtcNow;
            c.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            c.UserComment = comment.UserComment;
            context.Comments.Add(c);
            context.SaveChanges();
           return comment;
           }
        }
    }

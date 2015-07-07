using BrokeMans.Adapters;
using BrokeMans.Data;
using BrokeMans.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrokeMans.Models;
using Microsoft.AspNet.Identity;


namespace BrokeMans.Controllers
{
    public class CommentsController : Controller
    {
        private IComments _adapter;
        // GET: Comment
        [HttpGet]
        public ActionResult CommentPage( int id)
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentPage(int id,Comment comment)
        {
            BrokeContext context = new BrokeContext();
            //_adapter.CreateComment(comment, id);
            Comment c = new Comment();
            c.ItemId = id;
            c.DateCreated = DateTime.UtcNow;
            c.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            c.UserComment = comment.UserComment;
            context.Comments.Add(c);
            context.SaveChanges();
           
            return RedirectToAction("Index", "Item", new {id = id });
        }
    }
}
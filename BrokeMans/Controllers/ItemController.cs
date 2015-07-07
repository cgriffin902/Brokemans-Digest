using BrokeMans.Adapters;
using BrokeMans.Adapters.Data;
using BrokeMans.Adapters.Data.ItemDetailsData;
using BrokeMans.Data.Models;
using BrokeMans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokeMans.Controllers
{
    public class ItemController : Controller
    {
        // GET: ItemDetails
        private IItem _adapter;
        public ItemController()
        {
            _adapter = new ItemsData();
        }
        public ActionResult Index(int id)
        {
            
            ItemViewModel model = _adapter.GetItemDetails(id);

            return View(model);
        }
        //GET
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item Item, ApplicationUser user)
        {
            _adapter.Create(Item, user);
            return RedirectToAction("ItemList","Home");
            
        }

        public ActionResult Delete(int id)
        {
            _adapter.Delete(id);
            return RedirectToAction("ItemList", "Home");
        }
        [HttpGet]
        public ActionResult Edit(Item item, int id, ApplicationUser user)
        {
            item = _adapter.GetEdit(item, user, id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item item, int id )
        {
            _adapter.PostEdit(item, id);
            return RedirectToAction("Index", "Item", new { id });
        }
    }

}
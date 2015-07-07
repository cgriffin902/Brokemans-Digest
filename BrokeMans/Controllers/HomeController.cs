using BrokeMans.Adapters;
using BrokeMans.Adapters.Data.ItemDetailsData;
using BrokeMans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokeMans.Controllers
{
    public class HomeController : Controller
    {
        IItem _adapter;
        public HomeController()
        {
            _adapter = new ItemsData();
        }
        public ActionResult Index()
        {
            ItemListViewModel model = _adapter.Get4ItemPics();
            return View(model);
        }

        public ActionResult ItemList()
        {
            ItemListViewModel model = _adapter.GetAllItems();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
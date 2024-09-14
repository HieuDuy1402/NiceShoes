using NiceShoesWeb.Context_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NiceShoesWeb.Context_DB;

namespace NiceShoesWeb.Controllers
{
    public class HomeController : Controller
    {
        QLNiceShoes_Entities objQLNiceShoesEntities = new QLNiceShoes_Entities();
        public ActionResult Index()
        {
            var lstSanPham = objQLNiceShoesEntities.SanPhams.ToList();
            return View(lstSanPham);
        }
    }
}
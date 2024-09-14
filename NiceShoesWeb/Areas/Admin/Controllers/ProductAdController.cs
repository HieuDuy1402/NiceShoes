using NiceShoesWeb.Context_DB;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiceShoesWeb.Areas.Admin.Controllers
{
    public class ProductAdController : Controller
    {
        QLNiceShoes_Entities objQLNiceShoesEntities = new QLNiceShoes_Entities();
        // GET: Admin/ProductAd
        public ActionResult Index()
        {
            var lstSanPham = objQLNiceShoesEntities.SanPhams.ToList();
            return View(lstSanPham);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham objProduct)
        {
            try
            {
                if (objProduct.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss" + extension));
                    objProduct.AnhSP = fileName;
                    objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objQLNiceShoesEntities.SanPhams.Add(objProduct);
                objQLNiceShoesEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception Exception)
            {
                return RedirectToAction("Index");
            }           
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = objQLNiceShoesEntities.SanPhams.Where(n => n.IdSP == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objQLNiceShoesEntities.SanPhams.Where(n => n.IdSP == id).FirstOrDefault();           
            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Delete(SanPham objPro)
        {
            var objProduct = objQLNiceShoesEntities.SanPhams.Where(n => n.IdSP == objPro.IdSP).FirstOrDefault();
            objQLNiceShoesEntities.SanPhams.Remove(objProduct);
            objQLNiceShoesEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objQLNiceShoesEntities.SanPhams.Where(n => n.IdSP == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Edit( SanPham objProduct)
        {
            if (objProduct.ImageUpLoad != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss" + extension));
                objProduct.AnhSP = fileName;
                objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objQLNiceShoesEntities.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;
            objQLNiceShoesEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class ProductController : Controller
    {
        //test
       private IServiceProduct sp ;
       private IServiceCategorycs sc ;
        public ProductController(IServiceProduct sp, IServiceCategorycs sc)
        {
            this.sp = sp;
            this.sc = sc;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(sp.GetMany());
        }
        // Post: ProductController search
        [HttpPost]
        public ActionResult Index(String filter)
        {
            return View(sp.GetMany(p=>p.Name.Contains(filter)));
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
                       
            return View(sp.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryFK = new SelectList(sc.GetMany(), "CategoryId","Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection,IFormFile file)
        {
            collection.ImageName= file.FileName;
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads",
               file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            sp.Add(collection);
            sp.Commit();
            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(sp.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
           
       

        sp.Update(collection);
        sp.Commit();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sp.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
        sp.Delete(collection);
        sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

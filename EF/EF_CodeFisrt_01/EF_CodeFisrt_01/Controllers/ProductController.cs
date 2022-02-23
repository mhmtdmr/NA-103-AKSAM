using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF_CodeFisrt_01.Models;

namespace EF_CodeFisrt_01.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            List<SelectListItem> categories = db.Categories.ToList().OrderBy(n => n.Name)
                .Select(n =>
                        new SelectListItem
                        {
                            Value = n.ID.ToString(),
                            Text = n.Name
                        }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,UnitsInStock,Expiration,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,UnitsInStock,Expiration")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Filter()
        {
            // Tüm ürünleri liste olarak döndürür.
            // var allProductsList = db.Products.ToList()

            // ID ile tek bir ürün nesnesi getirmek istersem.
            // Product urun = db.Products.Find(2);

            // Where fonksiyonu ile filtreleme yapmak. 
            // Where liste döndürür. Biz listeden ilk elemanı aldık. Yoksa default null nesne alırız.
            // Product urun = db.Products.Where(p => p.ID == 2).FirstOrDefault();


            //// Stok adedi 10 ve üzeri olanları liste olarak döndür.
            //var urunler = db.Products.Where(p => p.UnitsInStock>=10);



            //// Stok adedi 10 ve üzeri olup fiyatı 15 ve altı olanları liste olarak döndür.
            //var urunler = db.Products.Where(p => p.UnitsInStock >= 10 && p.Price<=15);


            ////// Stok adedi 10 ve üzeri olup fiyatı 15 veya altı olanları liste olarak döndür.
            //var urunler = db.Products.Where(p => p.UnitsInStock >= 10 || p.Price <= 15);


            // Select ile SQL deki SELECT sorugusnda olduğu gibi belirli kolonları seçebiliriz.
            ViewBag.urunAdlari = db.Products.Select(p => p.Name );

            //////  Name'i Patates olan ilk kayıtı döndür bulamazsa varsayılan değeri döndürür.
            //var urun = db.Products.FirstOrDefault(p => p.Name == "Patates");
            //if (urun == null)
            //    urun = new Product();

            //////  ID si 7 olan kayıtı getir. Yoksa hata ver.
            //var urun = db.Products.Single(p=>p.ID==7);
            //if (urun == null)
            //    urun = new Product();

            ////////  2 kayıt getir.
            //var urunler = db.Products.Take(2);

            //////// Son 2 kayıtı getir.
            var urunler = db.Products.OrderByDescending(p=>p.ID).Take(2);

            // En az 1 tane adında Cips geçen ürün varsa true döner.
            ViewBag.cipsVarMi = db.Products.Any(p => p.Name.Contains("Cips"));

            // Tüm ürünlerin stok adedi 0 dan büyükse true yoksa false.
            ViewBag.tumUrunlerStoktaVarMi = db.Products.All(p => p.UnitsInStock > 0);

            // Kaç farklı ürün var?
            ViewBag.UrunCesitSayisi = db.Products.Count();

            // Fiyatı 20 den büyük olan kaç ürün var?
            ViewBag.urun20denPahali = db.Products.Where(p => p.Price > 20).Count();

            // En Ucuz Ürün
            ViewBag.enucuz = db.Products.Min(p => p.Price);
            // En Pahalı Ürün
            ViewBag.enpahali = db.Products.Max(p => p.Price);
            // Ortalama fiyat
            ViewBag.ortalamafiyat = db.Products.Average(p => p.Price);

            // Son ürün
            Product sonurun = db.Products.ToList().LastOrDefault();
            ViewBag.sonurun = sonurun;


            // SQL sorgusu ile ürün getirme.
            Product yumurta = db.Products.SqlQuery("SELECT * FROM Products WHERE Name LIKE '%Yumurta%';").FirstOrDefault();
            ViewBag.yumurta = yumurta;


            return View(urunler);

        }

        public ActionResult AddProduct()
        {
            Product yeniUrun = new Product();
            yeniUrun.Name = "Patates";
            yeniUrun.Description = "Manisa patatesi,kızartmalık";
            yeniUrun.Expiration = new DateTime(2022, 6, 20);
            yeniUrun.Price = 15;

            db.Products.Add(yeniUrun); 
            db.SaveChanges(); // Kaydeder.
            return Content("Yeni ürün eklendi!");
        }

        public ActionResult  UpdateProduct()
        {
            Product kek = db.Products.Find(3);
            kek.Description = "Üzümlü,havuçlu kek.";
            db.SaveChanges();
            return Content("Kek güncellendi!");
        }
        public ActionResult RemoveProduct()
        {
            Product ekmek = db.Products.FirstOrDefault(p => p.Name == "Ekmek");
            db.Products.Remove(ekmek);
            db.SaveChanges();
            return Content("Ekmek silindi!");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using MVC_Example.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC_Example.Controllers
{
    public class MoviesController : Controller
    {
        //实例化数据库
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        public ActionResult Index(string searchString)
        {
            //Linq查询语句，m为范围变量
            var movies = from m in db.Movies
                         select m;
            if (!String.IsNullOrEmpty(searchString))

            {

                movies = movies.Where(s => s.Title.Contains(searchString));
                //查询执行会被延迟，这意味着表达式的计算延迟，直到取得实际的值或调用ToList方法。
                //Contains方法运行于数据库上
            }

            return View(movies);
        }


        // GET: Movies/Details/5
        //id参数一般是通过路由数据传递.
        public ActionResult Details(int? id) //int? id中代表是一个可以为NULL的参数
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5       第一个为get 第二个为post
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }//END for 第一个Edit

        // POST: Movies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[ValidateAntiForgeryToken]过滤特性。该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。

        [HttpPost]
        [ValidateAntiForgeryToken]
        //ValidateAntiForgeryToken用于防止伪造请求
        //下面这个方法只被post请求调用（就是当表单被保存的时候）
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        //绑定（Bind）属性是另一个重要安全机制，可以防止黑客攻击(从over-posting数据到你的模型)。在bind中包含你想要更改的
        {
            if (ModelState.IsValid)
            //isValid验证提交的表单数据是否可用于修改（编辑或更新）一个Movie对象。
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
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

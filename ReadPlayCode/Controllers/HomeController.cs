using ReadPlayCode.Models;
using ReadPlayCode.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadPlayCode.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<IBlogPost> _repo;

        public HomeController(IRepository<IBlogPost> repo)
        {
            if (repo == null)
                throw new ArgumentNullException("repo");

            _repo = repo;
        }

        public ActionResult Index()
        {
            var blogs = _repo.All().OrderByDescending(b => b.Created).Take(10);
            return View(blogs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
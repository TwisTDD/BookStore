using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore.Models;
using PagedList;
using PagedList.Mvc;
namespace MvcBookStore.Controllers
{
    public class AdmonController : Controller
    {
        dbQLbansachDataContext db = new dbQLbansachDataContext();
        //
        // GET: /Admon/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sach(int ?page)
        {
            int pageNumber=(page ?? 1);
            int pageSize=7;
            return View(db.SACHes.ToList().OrderBy(n => n.Masach).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
	}
}
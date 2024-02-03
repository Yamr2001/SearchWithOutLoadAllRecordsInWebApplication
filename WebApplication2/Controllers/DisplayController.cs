using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class DisplayController : Controller
    {
        readonly EDA_medical_devicesEntities dbContext = new EDA_medical_devicesEntities();
        // GET: Display
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GetItems(string searchTerm)
       {
            var items = dbContext.MDNames
                .Where(item => item.MDName_Ar.Contains(searchTerm))
                .Take(20)
                .Select(item => new { id = item.MDNameIDPK, text = item.MDName_Ar })
                .ToList();

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}
using mvcdapperörnproje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;

namespace mvcdapperörnproje.Controllers
{
    public class MalzemeController : Controller
    {
        // GET: Malzeme
        public ActionResult Index()
        {
            return View(DP.Listeleme<MalzemeModel>("MalzemeViewAll"));
        }
        public ActionResult EY(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("malzemeNo", id);
                return View(DP.Listeleme<MalzemeModel>("MalzemeViewByNo",param).FirstOrDefault<MalzemeModel>());
            }

        }
        [HttpPost]
        public ActionResult EY(MalzemeModel malzeme)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@malzemeNo", malzeme.malzemeNo);
            param.Add("@malzemeAdi", malzeme.malzemeAdi);
            param.Add("@malzemeTutar", malzeme.malzemeTutar);
            param.Add("@hizmetNo", malzeme.hizmetNo);
            DP.ExecuteReturn("MalzemeEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@malzemeNo",id);
            DP.ExecuteReturn("MalzemeDel", param);
            return RedirectToAction("Index");
        }
    }
}
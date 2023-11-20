using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using mvcdapperörnproje.Models;

namespace mvcdapperörnproje.Controllers
{
    public class GörevliController : Controller
    {
        // GET: Görevli
        public ActionResult Index()
        {
            return View(DP.Listeleme<GörevliModel>("GörevliViewAll"));
        }
        public ActionResult EY(int id = 0) 
        {
            if(id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("görevliNo", id);
                return View(DP.Listeleme<GörevliModel>("GörevliViewByNo",param).FirstOrDefault<GörevliModel>());
            }
        }
        [HttpPost]
        public ActionResult  EY (GörevliModel görevli)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@görevliNo", görevli.görevliNo);
            param.Add("@adSoyad", görevli.adSoyad);
            param.Add("@Yas", görevli.Yas);
            param.Add("@Tel", görevli.Tel);
            param.Add("@mesaiDurum", görevli.mesaiDurum);
            param.Add("@Maas", görevli.Maas);
            param.Add("@Prim", görevli.Prim);
            param.Add("@salonNo", görevli.salonNo);
            DP.ExecuteReturn("GörevliEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete (int id=0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add ("görevliNo", id);
            DP.ExecuteReturn("GörevliDel", param);
            return RedirectToAction("Index");
        }
    }
}
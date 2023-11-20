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
    public class HizmetlerController : Controller
    {
        // GET: Hizmetler
        public ActionResult Index()
        {
            return View(DP.Listeleme<HizmetlerModel>("HizmetViewAll"));
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
                param.Add("@hizmetNo", id);
                return View(DP.Listeleme<HizmetlerModel>("HizmetViewByNo", param).FirstOrDefault<HizmetlerModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(HizmetlerModel hizmet)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@hizmetNo", hizmet.hizmetNo);
            param.Add("@hizmetAdi", hizmet.hizmetAdi);
            param.Add("@hizmetAmaci", hizmet.hizmetAmaci);
            param.Add("@odemeTuru", hizmet.odemeTuru);
            param.Add("@görevliNo", hizmet.görevliNo);
            DP.ExecuteReturn("HizmetEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id=0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@hizmetNo",id);
            DP.ExecuteReturn("HizmetDel", param);
            return RedirectToAction("Index");
        }
    }
}
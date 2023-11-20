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
    public class SalonlarController : Controller
    {
        // GET: Salonlar
        public ActionResult Index()
        {
            return View(DP.Listeleme<SalonlarModel>("SalonViewAll"));
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
                param.Add("salonNo", id);
                return View(DP.Listeleme<SalonlarModel>("SalonViewByNo", param).FirstOrDefault<SalonlarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(SalonlarModel salon)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@salonNo", salon.salonNo);
            param.Add("@salonAdi", salon.salonAdi);
            param.Add("@salonKapiNo", salon.salonKapiNo);
            param.Add("@yapilanIslem", salon.yapilanIslem);
            param.Add("@islemSayisi", salon.islemSayisi);
            DP.ExecuteReturn("FirmaEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id=0) 
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@salonNo", id);
            DP.ExecuteReturn("SalonDel", param);
            return RedirectToAction("Index");
        }
    }
}
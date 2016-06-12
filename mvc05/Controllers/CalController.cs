using mvc05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc05.Controllers
{
    public class CalController : Controller
    {
        // GET: Cal
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CalAction(int? i1, int? i2, string remarks)
        {
            ViewBag.Method = "Get";
            if (i1 != null && i2 != null)
            {
                Cal c = new Cal();
                c.Input1 = i1.Value;
                c.Input2 = i2.Value;
                c.Remarks = remarks;
                c.Result = Convert.ToString(i1.Value + i2.Value);
                UpdateSession(c);
                ViewBag.RecentCal = (string)HttpContext.Session["RecentCal"];
                return View(c);
            }
            else
            {
                ViewBag.RecentCal = (string)Session["RecentCal"];
                return View();
            }
        }

        [HttpPost]
        public ActionResult CalAction(Cal c)
        {
            ViewBag.Method = "POST";

            //string remarks1 = ModelState["Remarks"].Value.AttemptedValue;
            //string remarks2 = c.Remarks;
            //string remarks3 = Request.Unvalidated.Form["remarks"];
            //string remarks4 = Request.Form["remarks"]; //Request.Form will perform its own validation independent of the modal class, so this will error out even if AllowHtml is configured on the model

            if (ModelState.IsValid)
            {
                if (c.Remarks.Contains("ABC"))
                {
                    ModelState.AddModelError("Remarks", "Cannnot contains ABC");
                }
                else
                {
                    c.Result = Convert.ToString(c.Input1 + c.Input2);
                    UpdateSession(c);
                }
            }
            else
            {
                string err = "Something wrong in your inputs!";
                ModelState.AddModelError("", err);
            }

            ViewBag.RecentCal = (string)Session["RecentCal"];
            return View(c);
        }

        public ActionResult CheckRemarks(string Remarks)
        {
            if (Remarks.Contains("ABC"))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private void UpdateSession(Cal c)
        {
            string str = "";
            if (HttpContext.Session["RecentCal"] != null)
            {
                str = (string)Session["RecentCal"];
            }

            Session["RecentCal"] = str + c.Input1 + "+" + c.Input2 + "=" + c.Result + "    ";
        }
    }
}
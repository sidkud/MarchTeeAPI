using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarchTeeAPI.Models;

namespace MarchTeeAPI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("home");
        }

        public ActionResult Grey()
        {
            PostgresqlWrapper oWrapper = new PostgresqlWrapper();
            var ret = oWrapper.GetVariants("grey");
            return View("grey", ret);
        }

        public ActionResult Blue()
        {
            PostgresqlWrapper oWrapper = new PostgresqlWrapper();
            var ret = oWrapper.GetVariants("blue");
            return View("blue", ret);
        }

        public ActionResult Black()
        {
            PostgresqlWrapper oWrapper = new PostgresqlWrapper();
            var ret = oWrapper.GetVariants("black");
            return View("black", ret);
        }

        public ActionResult CheckOut()
        {
            return View("~/Views/Order/checkout.cshtml");
        }

        public ActionResult Order()
        {
            return View("~/Views/Order/order.cshtml");
        }

        public ActionResult OrderCancel()
        {
            return View("~/Views/Order/order-cancelled.cshtml");
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(string color)
        {
            PostgresqlWrapper oWrapper = new PostgresqlWrapper();

            var ret = oWrapper.GetVariants(color);

            return View(ret);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

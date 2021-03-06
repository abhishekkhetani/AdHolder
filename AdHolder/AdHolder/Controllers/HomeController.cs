﻿using AdHolder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdHolder.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (var ctx = new EFCodeFirstContext())
            {
                ViewBag.Cities = new SelectList(ctx.City.ToList().Select(x => new { Value = x.CityId, Text = x.Name }), "Value", "Text");
            }
            return View();
        }

        public ActionResult CityArea()
        {
            using (var ctx = new EFCodeFirstContext())
            {
                ViewBag.Cities = new SelectList(ctx.City.ToList().Select(x => new { Value = x.CityId, Text = x.Name }), "Value", "Text");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCity(City city)
        {
            ModelState.Remove("CityId");
            ModelState.Remove("AreaName");
            city.AreaName = "tempOption";
            if (ModelState.IsValid)
            {
                using (var ctx = new EFCodeFirstContext())
                {
                    var exist = ctx.City.Where(s => s.Name == city.Name).FirstOrDefault();

                    if (exist != null)
                        return Json("exist", JsonRequestBehavior.AllowGet);
                    else
                    {
                        try
                        {
                            ctx.City.Add(city);
                            ctx.SaveChanges();
                        }
                        catch (DbEntityValidationException e)
                        {
                            throw e;
                        }
                        var citiesList = new SelectList(ctx.City.ToList().Select(x => new { Value = x.CityId, Text = x.Name }), "Value", "Text");
                        return Json(citiesList, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json("error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddArea(City city)
        {
            ModelState.Remove("AreaId");
            ModelState.Remove("Name");
            city.Name = "tempOption";
            if (ModelState.IsValid)
            {
                using (var ctx = new EFCodeFirstContext())
                {
                    var exist = ctx.Area.Where(s => s.Name == city.AreaName).FirstOrDefault();

                    if (exist != null)
                        return Json("exist", JsonRequestBehavior.AllowGet);
                    else
                    {
                        Area area = new Area()
                        {
                            Name = city.AreaName,
                            CityRefId = city.CityId
                        };
                        ctx.Area.Add(area);
                        ctx.SaveChanges();
                        return Json("success", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json("error", JsonRequestBehavior.AllowGet);
        }
    }
}

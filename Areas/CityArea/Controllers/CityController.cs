using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Areas.CityArea.Controllers
{
    
    public class CityController : Controller
    {
        // GET: CityArea/City
        public ActionResult CityList()
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                var data = new List<CityVM>();
                data = db.Cities.ToList().Select(x => new CityVM
                {
                    Id = x.id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).ToList();
                return View(data);
            }
        }

        //GET
        public ActionResult Create()
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                ViewBag.City = db.Cities.ToList();
                return View();
            }
        }

        //POST
        [OutputCache(Duration = 60)]
        [HttpPost]
        public ActionResult Create(CityVM cityModel)
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                if (ModelState.IsValid)
                {
                    var city = new City
                    {
                        Name = cityModel.Name,                        
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    db.Cities.Add(city);
                    db.SaveChanges();
                    return RedirectToAction("CityList", "City");
                }
                else
                {
                    return View();
                }
            }
        }

        //GET
        public ActionResult Edit(int id)
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                var city = db.Cities.Where(x => x.id == id).First();
                var data = new CityVM();
                data = db.Cities.Where(x => x.id == id).Select(x => new CityVM
                {
                    Id = x.id,
                    Name = x.Name,                   
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).First();
                return View(data);
            }
        }

        [HttpPost]
        public ActionResult Edit(CityVM cityVM)
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                if (ModelState.IsValid)
                {
                    var city = new City
                    {
                        id = cityVM.Id,
                        Name = cityVM.Name,                        
                        CreatedDate = cityVM.CreatedDate,
                        UpdatedDate = DateTime.Now
                    };
                    db.Entry(city).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("CityList", "City");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
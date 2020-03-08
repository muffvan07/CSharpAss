using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Areas.CustomerArea.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerArea/CustomerList
        public ActionResult CustomerList()
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                var data = new List<CustomerVM>();
                data = db.Customers.ToList().Select(x => new CustomerVM
                {
                    Id = x.id,
                    Name = x.Name,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    Citylist = x.City,
                    Country = x.Country,
                    PostCode = x.PostCode,
                    Email = x.Email,
                    BirthDate = x.BirthDate,
                    Mobile = x.Mobile,
                    Active = x.Active,
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
        [HttpPost]
        public ActionResult Create(CustomerVM customerModel)
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer
                    {
                        Name = customerModel.Name,
                        Address1 = customerModel.Address1,
                        Address2 = customerModel.Address2,
                        CityName = customerModel.City,
                        Country = customerModel.Country,
                        PostCode = customerModel.PostCode,
                        Email = customerModel.Email,
                        Mobile = customerModel.Mobile,
                        BirthDate = customerModel.BirthDate,
                        Active = customerModel.Active,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("CustomerList", "Customer");
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
                var city = db.Customers.Where(x => x.id == id).First();
                var data = new CustomerVM();
                data = db.Customers.Where(x => x.id == id).Select(x => new CustomerVM
                {
                    Id = x.id,
                    Name = x.Name,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.CityName,
                    Country = x.Country,
                    PostCode = x.PostCode,
                    Email = x.Email,
                    BirthDate = x.BirthDate,
                    Mobile = x.Mobile,
                    Active = x.Active,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).First();
                data.CityList1 = new SelectList(db.Cities.ToList(), "id", "Name", city.City);
                return View(data);
            }
        }

        [HttpPost]
        public ActionResult Edit(CustomerVM customerVM)
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer
                    {
                        id = customerVM.Id,
                        Name = customerVM.Name,
                        Address1 = customerVM.Address1,
                        Address2 = customerVM.Address2,
                        CityName = customerVM.City,
                        Country = customerVM.Country,
                        PostCode = customerVM.PostCode,
                        Email = customerVM.Email,
                        Mobile = customerVM.Mobile,
                        BirthDate = customerVM.BirthDate,
                        Active = customerVM.Active,
                        CreatedDate = customerVM.CreatedDate,
                        UpdatedDate = DateTime.Now
                    };
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("CustomerList", "Customer");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
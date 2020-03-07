using AutoMapper;
using CSharpAssignment.Models;
using CSharpAssignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpAssignment.Areas.CustomerArea.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerArea/Customer
        public ActionResult CustomerList()
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                var data = new List<CustomerVM>();
                data = db.Customers.ToList().Select(x => new CustomerVM
                {
                    Id = x.Id,
                    CustomerName = x.CustomerName,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    citylist = x.City1,
                    Country = x.Country,
                    PostCode = x.PostCode,
                    Email = x.Email,
                    BirthDate = x.BirthDate,
                    Mobile = x.Mobile,
                    Active = x.Active,
                }).ToList();
                return View(data);
            }
        }


        //GET
        public ActionResult Create()
        {
            CSharpAssignmentEntities db = new CSharpAssignmentEntities();
            ViewBag.City = db.Cities.ToList();
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(CustomerVM customerModel)
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer();
                    customer.CustomerName = customerModel.CustomerName;
                    customer.Address1 = customerModel.Address1;
                    customer.Address2 = customerModel.Address2;
                    customer.City = customerModel.City;
                    customer.Country = customerModel.Country;
                    customer.PostCode = customerModel.PostCode;
                    customer.Email = customerModel.Email;
                    customer.Mobile = customerModel.Mobile;
                    customer.BirthDate = customerModel.BirthDate;
                    customer.Active = customerModel.Active;
                    customer.CreatedDate = DateTime.Now;
                    customer.UpdatedDate = DateTime.Now;
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
        
        public ActionResult Edit(int id)
        {
            using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
            {
                var city = db.Customers.Where(x => x.Id == id).First();
                var data = new CustomerVM();
                data = db.Customers.Where(x => x.Id == id).Select(x => new CustomerVM
                {
                    Id = x.Id,
                    CustomerName = x.CustomerName,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    citylist = x.City1,
                    Country = x.Country,
                    PostCode = x.PostCode,
                    Email = x.Email,
                    BirthDate = x.BirthDate,
                    Mobile = x.Mobile,
                    Active = x.Active,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).First();
                data.CityList1 = new SelectList(db.Cities.ToList(), "Id", "CityName", city.City);
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
                    var customer = new Customer();
                    customer.Id = customerVM.Id;
                    customer.CustomerName = customerVM.CustomerName;
                    customer.Address1 = customerVM.Address1;
                    customer.Address2 = customerVM.Address2;
                    customer.City = customerVM.City;
                    customer.Country = customerVM.Country;
                    customer.PostCode = customerVM.PostCode;
                    customer.Email = customerVM.Email;
                    customer.Mobile = customerVM.Mobile;
                    customer.BirthDate = customerVM.BirthDate;
                    customer.Active = customerVM.Active;
                    customer.CreatedDate = customerVM.CreatedDate;
                    customer.UpdatedDate = DateTime.Now;
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (CSharpAssignmentEntities entities = new CSharpAssignmentEntities())
            {
                Customer customer = (from c in entities.Customers
                                     where c.Id == id
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }

            return View();
        }
    }
}
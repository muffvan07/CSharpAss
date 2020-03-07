using CSharpAssignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpAssignment.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<int> City { get; set; }
        public string Country { get; set; }
        public Nullable<int> PostCode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<bool> Active { get; set; }
        [Editable(false)]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Editable(false)]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public City citylist { get; set; }
        public SelectList CityList1 { get; set; }
    }
}
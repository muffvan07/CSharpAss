using Assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.ViewModels
{
    public class CustomerVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(2, ErrorMessage = "The Name must be atleast 5 characters")]
        [MaxLength(15, ErrorMessage = "The Name cannot be more than 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Address 1")]
        [MinLength(5, ErrorMessage = "The Address1 must be atleast 5 characters")]
        [MaxLength(100, ErrorMessage = "The Address1 cannot be more than 100 characters")]
        public string Address1 { get; set; }


        [Required(ErrorMessage = "Please Enter Address 2")]
        [MinLength(5, ErrorMessage = "The Address2 must be atleast 5 characters")]
        [MaxLength(100, ErrorMessage = "The Address2 cannot be more than 100 characters")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public Nullable<int> City { get; set; }

        [Required(ErrorMessage = "Please Enter Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please Enter Post Code")]
        [Display(Name = "Post Code")]
        public Nullable<int> PostCode { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No"), MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Birth Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [Required(ErrorMessage = "CheckIn your Activity")]
        [Display(Name = "isActive")]
        public Nullable<bool> Active { get; set; }

        [Editable(false)]
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }

        [Editable(false)]
        [Display(Name = "Updated Date")]
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public City Citylist { get; set; }

        public SelectList CityList1 { get; set; }
    }
}
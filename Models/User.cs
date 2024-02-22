using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject2.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; } = string.Empty;


        public int EventID { get; set; }

        public EventData Event { get; set; } = new EventData();

        public string EventName { get; set; } = string.Empty;

        public IEnumerable<SelectListItem> EventsData { get; set; } = Enumerable.Empty<SelectListItem>();


        [Required(ErrorMessage = "Selected Event is required.")]
        public int SelectedEventID { get; set; }
    }
}


// using System;
// namespace FinalProject2.Models
// {
//     public class User
//     {
//         public User()
//         {
//         }

//         public int UserID { get; set; }
//         public string? FirstName { get; set; }
//         public string? LastName { get; set; }
//         public string? EmailAddress { get; set; }
//         public string? PhoneNumber { get; set; }
//         public int EventID { get; set; }
//         public string? EventName { get; set; }
//         public IEnumerable<EventData>? EventsData { get; set; }
//         public int SelectedEventID { get; set; }
//     }
// }


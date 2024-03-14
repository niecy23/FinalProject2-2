using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject2.Models
{
    public class User
    {
        public User()
        {
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select an event.")]
        public int? EventID { get; set; }


        public EventData Event { get; set; }
        public string EventName { get; set; }
        public IEnumerable<SelectListItem> EventsData { get; set; }
        public int SelectedEventID { get; set; }
    }
}


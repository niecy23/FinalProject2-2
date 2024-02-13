using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject2.Models
{
    public class EventDetailsViewModel
    {
        public EventDetailsViewModel()
            {
                EventData = new EventData(); // Initialize EventData
                EventName = string.Empty;
                Location = string.Empty;
                Description = string.Empty;
                UsersAttending = new List<User>();
            }
        public EventData EventData { get; set; }

        [Required(ErrorMessage = "Event ID is required.")]
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event Name is required.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Date and Time is required.")]
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        // public IEnumerable<EventData> Events { get; set; }
        public List<User> UsersAttending { get; set; } = new List<User>();
    }

public class EventData
    {
       
        // Default constructor to initialize properties
        public EventData()
        {
            EventName = string.Empty;
            Location = string.Empty;
            Description = string.Empty;
            EventIE = new List<EventData>();
            UsersAttending = new List<User>();
        }

        // Correcting the property names here
        public EventData? Events { get; set; }

        [Required(ErrorMessage = "Event ID is required.")]
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event Name is required.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Date and Time is required.")]
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        // Correcting the property names here
        public IEnumerable<EventData> EventIE { get; set; }

        // Assuming UsersAttending cannot be null
        public List<User> UsersAttending { get; set; } = new List<User>();
    }
}

    // public class EventData
    // {
    //     // public EventData Events { get; set; }

    //     [Required(ErrorMessage = "Event ID is required.")]
    //     public int EventID { get; set; }

    //     [Required(ErrorMessage = "Event Name is required.")]
    //     public string EventName { get; set; }

    //     [Required(ErrorMessage = "Date and Time is required.")]
    //     public DateTime DateAndTime { get; set; }

    //     [Required(ErrorMessage = "Location is required.")]
    //     public string Location { get; set; }

    //     [Required(ErrorMessage = "Description is required.")]
    //     public string Description { get; set; }

    //     // public IEnumerable<User> UsersAttending { get; set; }

    //     // public IEnumerable<EventData> EventIE { get; set; }
    //     public List<User> UsersAttending { get; set; }
    // }
// }


// using System;
// using Microsoft.Extensions.Logging;

// namespace FinalProject2.Models
// {
// 	public class EventDetailsViewModel
// 	{
//         public EventData? EventData { get; set; }
//         public int EventID { get; set; }
//         public string? EventName { get; set; }
//         public DateTime DateAndTime { get; set; }
//         public string? Location { get; set; }
//         public string? Description { get; set; }

//         public IEnumerable<EventData>? Events { get; set; }
//         public List<User>? UsersAttending { get; set; }
//     }

//     public class EventData
//     {
//         public EventData? Events { get; set; }
//         public int EventID { get; set; }
//         public string? EventName { get; set; }
//         public DateTime DateAndTime { get; set; }
//         public string? Location { get; set; }
//         public string? Description { get; set; }

//         public IEnumerable<EventData>? EventIE { get; set; }
//         public List<User>? UsersAttending { get; set; }
//     }

// }


using System;
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
        public int EventID { get; set; }
        public string EventName { get; set; }
        public IEnumerable<EventData> EventsData { get; set; }
        public int SelectedEventID { get; set; }
    }
}


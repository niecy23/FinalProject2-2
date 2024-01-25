using System;
using Microsoft.Extensions.Logging;

namespace FinalProject2.Models
{
	public class EventDetailsViewModel
	{
        public EventData EventData { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public IEnumerable<EventData> Events { get; set; }
        public List<User> UsersAttending { get; set; }
    }

    public class EventData
    {
        public EventData Events { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public IEnumerable<EventData> EventIE { get; set; }
        public List<User> UsersAttending { get; set; }
    }

}


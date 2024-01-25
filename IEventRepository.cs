using System;
using FinalProject2.Models;

namespace FinalProject2
{
	public interface IEventRepository
	{
        public IEnumerable<EventData> GetAllEventsData();
        public EventData GetEventData(int id);
        public void UpdateEventData(EventData instance);
        public void InsertEventData(EventData instanceToInsert);
        public void DeleteEventData(EventData instance);


        public int GetRSVPCount(int id);
        public IEnumerable<EventData> GetUsersByEvent(int id);
        public IEnumerable<User> GetRSVPs(int id);

        public IEnumerable<User> GetAllUsers(int id);
        
    }
}


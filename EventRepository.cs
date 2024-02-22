using System.Data;
using Dapper;
using FinalProject2.Models;
using Microsoft.Extensions.Logging;
using Mysqlx.Crud;

namespace FinalProject2
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _conn;

        public EventRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteEventData(EventData instance)
        {
            _conn.Execute("DELETE FROM Events WHERE EventID = @id;", new { id = instance.EventID });
        }

        public IEnumerable<EventData> GetAllEventsData()
        {
            return _conn.Query<EventData>("SELECT * FROM EVENTS;");
        }

        public EventData GetEventData(int id)
        {
            return _conn.QuerySingle<EventData>("SELECT * FROM EVENTS WHERE EVENTID = @id", new { id = id });
        }

        public void InsertEventData(EventData instanceToInsert)
        {
            _conn.Execute("INSERT INTO Events (EVENTNAME, DATEANDTIME, LOCATION, DESCRIPTION) VALUES (@eventname, @dateandtime, @location, @description);",
            new { eventname = instanceToInsert.EventName, dateandtime = instanceToInsert.DateAndTime, Location = instanceToInsert.Location, description = instanceToInsert.Description });
        }

        public void UpdateEventData(EventData instance)
        {
            _conn.Execute("UPDATE Events SET EventName = @name, DateAndTime = @dateandtime, Location = @location, Description = @description WHERE EventID = @id",
            new { name = instance.EventName, dateandtime = instance.DateAndTime, location = instance.Location, description = instance.Description, id = instance.EventID });
        }

        public int GetRSVPCount(int id)
        {
            return _conn.Query<User>("SELECT * FROM USERS WHERE EventID = @id;").Count();
        }

        public IEnumerable<EventData> GetUsersByEvent(int id)
        {
            return _conn.Query<EventData>("SELECT Events.EventID, Users.FirstName, Users.LastName FROM Events INNER JOIN Users ON Events.EventID = Users.EventID WHERE Events.EventID = @id;");
        }

        public IEnumerable<User> GetRSVPs(int id)
        {
            return _conn.Query<User>("SELECT * FROM USERS WHERE EventID = @id;");
        }

        public IEnumerable<User> GetAllUsers(int id)
        {
            return _conn.Query<User>("SELECT Users.UserID, Users.FirstName, Users.LastName, Users.EmailAddress, Users.PhoneNumber, Events.EventID, Events.EventName FROM Events INNER JOIN Users ON Users.EventID = Events.EventID WHERE Events.EVENTID = @id ORDER BY Users.UserID;",
                new { id = id });
        }
    }
}


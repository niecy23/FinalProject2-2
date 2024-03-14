using System;
using System.Data;
using Dapper;
using FinalProject2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FinalProject2
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _conn;

        public UserRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public User AssignEvent()
        {
            var eventList = GetAllEventsData();
            var user = new User();
            user.EventsData = eventList.Select(e => new SelectListItem
            {
                Value = e.EventID.ToString(),
                Text = $"{e.EventID} {e.EventName}"
            });
            return user;
        }

        public void DeleteUser(User user)
        {
            _conn.Execute("DELETE FROM Users WHERE UserID = @id;", new { id = user.UserID });
        }

        public IEnumerable<EventData> GetAllEventsData()
        {
            return _conn.Query<EventData>("SELECT * FROM Events;");
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _conn.Query<User>("SELECT Users.UserID, Users.FirstName, Users.LastName, Users.EmailAddress, Users.PhoneNumber, Events.EventID, Events.EventName\nFROM Events INNER JOIN Users\nON Users.EventID = Events.EventID\nORDER BY  Users.UserID;");
        }

        public User GetUser(int id)
        {
            return _conn.QuerySingle<User>("SELECT Users.UserID, Users.FirstName, Users.LastName, Users.EmailAddress, Users.PhoneNumber, Events.EventID, Events.EventName\nFROM Events INNER JOIN Users ON Users.EventID = Events.EventID WHERE USERID = @id", new { id = id });
        }

        public void InsertUser(User userToInsert)
        {
            _conn.Execute("INSERT INTO Users (FIRSTNAME, LASTNAME, EMAILADDRESS, PHONENUMBER, EVENTID) VALUES (@firstname, @lastname, @emailaddress, @phonenumber, @eventid);",
            new { firstname = userToInsert.FirstName, lastname = userToInsert.LastName, emailaddress = userToInsert.EmailAddress, phonenumber = userToInsert.PhoneNumber, eventid = userToInsert.EventID });
        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE Users SET FirstName = @firstname, LastName = @lastname, EmailAddress = @emailaddress, PhoneNumber = @phonenumber, EventID = @eventid WHERE UserID = @id",
            new { firstname = user.FirstName, lastname = user.LastName, emailaddress = user.EmailAddress, phonenumber = user.PhoneNumber, eventid = user.EventID, id = user.UserID });
        }
    }
}


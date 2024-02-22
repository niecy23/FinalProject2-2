using System;
using FinalProject2.Models;

namespace FinalProject2
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(int id);
        public void UpdateUser(User user);
        public void InsertUser(User userToInsert);
        public IEnumerable<EventData> GetAllEventsData();
        public User AssignEvent();
        public void DeleteUser(User user);
    }
}


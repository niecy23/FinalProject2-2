using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace FinalProject2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult UserIndex()
        {
            var users = repo.GetAllUsers();
            return View(users);
        }

        public IActionResult ViewUser(int id)
        {
            var user = repo.GetUser(id);
            if (user == null)
            {
                return View("UserNotFound");
            }
            return View(user);
        }

        public IActionResult UpdateUser(int id)
        {
            User user = repo.GetUser(id);
            if (user == null)
            {
                return View("UserNotFound");
            }

            // Populate the EventsData property
            var allEvents = repo.GetAllEventsData().ToList();
            user.EventsData = allEvents.Select(e => new SelectListItem
            {
                Value = e.EventID.ToString(),
                Text = $"{e.EventID} {e.EventName}",
                Selected = e.EventID == user.EventID
            });

            return View(user);
        }

        public IActionResult UpdateUserToDatabase(User user)
        {
            repo.UpdateUser(user);

            return RedirectToAction("ViewUser", new { id = user.UserID });
        }

        public IActionResult InsertUser()
        {
            var user = repo.AssignEvent();
            return View(user);
        }

        public IActionResult InsertUserToDatabase(User userToInsert)
        {
            repo.InsertUser(userToInsert);
            return RedirectToAction("UserIndex");
        }

        public IActionResult DeleteUser(User user)
        {
            repo.DeleteUser(user);
            return RedirectToAction("UserIndex");
        }

        public IActionResult SortUsers(string column, string sortOrder)
        {
            //Assuming you have a repository method to retrieve all users
            var allUsers = repo.GetAllUsers();

            // Implement sorting logic based on the specified column and sortOrder
            IEnumerable<User> sortedUsers;

            switch (column)
            {
                case "UserID":
                    sortedUsers = sortOrder == "asc" ? allUsers.OrderBy(u => u.UserID) : allUsers.OrderByDescending(u => u.UserID);
                    break;

                case "LastName":
                    sortedUsers = sortOrder == "asc" ? allUsers.OrderBy(u => u.LastName) : allUsers.OrderByDescending(u => u.LastName);
                    break;

                case "EventID":
                    sortedUsers = sortOrder == "asc" ? allUsers.OrderBy(u => u.EventID) : allUsers.OrderByDescending(u => u.EventID);
                    break;

                // Add additional cases for other columns if needed
                default:
                    sortedUsers = allUsers;
                    break;

            }

            // Return a partial view with the sorted users
            return PartialView("_UserTablePartial", sortedUsers);

        }
    }
}
//public IActionResult InsertUser()
//{
//    var user = repo.AssignEvent();
//    return View(user);
//}
//public IActionResult ViewUser(int id)
//{
//    var user = repo.GetUser(id);
//    return View(user);
//}
//public IActionResult InsertUserToDatabase(User userToInsert)
//{
//    if (ModelState.IsValid)
//    {
//        repo.InsertUser(userToInsert);
//        return RedirectToAction("ViewUser");
//    }

//    // Populate EventsData to redisplay the form with valid event options
//    userToInsert.EventsData = repo.GetAllEventsData().Select(e => new SelectListItem
//    {
//        Value = e.EventID.ToString(),
//        Text = $"{e.EventID} {e.EventName}"
//    });

//    return View("ViewUser", userToInsert);
//}

//public IActionResult InsertUserToDatabase(User userToInsert)
//{
//    if (ModelState.IsValid)
//    {
//        repo.InsertUser(userToInsert);
//        return RedirectToAction("ViewUser", new { id = userToInsert.UserID });
//    }

//    // Populate EventsData to redisplay the form with valid event options
//    userToInsert.EventsData = repo.GetAllEventsData().Select(e => new SelectListItem
//    {
//        Value = e.EventID.ToString(),
//        Text = $"{e.EventID} {e.EventName}"
//    });

//    //return View("InsertUser", userToInsert);
//    return RedirectToAction("ViewUser", new { id = userToInsert.UserID });
//}


//public IActionResult UpdateUserToDatabase(User user)
//{
//    if (ModelState.IsValid)
//    {
//        repo.UpdateUser(user);
//        return RedirectToAction("ViewUser", new { id = user.UserID });
//    }

//    // Populate EventsData to redisplay the form with valid event options
//    user.EventsData = repo.GetAllEventsData().Select(e => new SelectListItem
//    {
//        Value = e.EventID.ToString(),
//        Text = $"{e.EventID} {e.EventName}"
//    });

//    return View("ViewUser", user);
//}

//public IActionResult UpdateUserToDatabase(User user)
//{
//    if (ModelState.IsValid)
//    {
//        repo.UpdateUser(user);
//        return RedirectToAction("ViewUser", new { id = user.UserID });
//    }

//    // Populate EventsData to redisplay the form with valid event options
//    user.EventsData = repo.GetAllEventsData().Select(e => new SelectListItem
//    {
//        Value = e.EventID.ToString(),
//        Text = $"{e.EventID} {e.EventName}"
//    });

//    //return View("UpdateUser", user);
//    return RedirectToAction("ViewUser", new { id = user.UserID });

//}

// UserController.cs
//public IActionResult UpdateUserToDatabase(User user)
//{
//    // Ensure that the ModelState is valid before proceeding
//    if (ModelState.IsValid)
//    {
//        // Retrieve the selected EventID from the form data and assign it to the User model
//        var selectedEventId = Request.Form["EventID"];
//        user.EventID = int.Parse(selectedEventId);

//        // Update the user record in the repository
//        repo.UpdateUser(user);

//        // Redirect to the ViewUser action with the updated user ID
//        return RedirectToAction("ViewUser", new { id = user.UserID });
//    }

//    // If ModelState is not valid, populate EventsData to redisplay the form with valid event options
//    user.EventsData = repo.GetAllEventsData().Select(e => new SelectListItem
//    {
//        Value = e.EventID.ToString(),
//        Text = $"{e.EventID} {e.EventName}"
//    });

//    // Return the UpdateUser view with the updated User model
//    return View("UpdateUser", user);
//}
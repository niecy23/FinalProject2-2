using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject2.Controllers
{
    public class EventDataController : Controller
    {
        private readonly IEventRepository repo;

        public EventDataController(IEventRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var events = repo.GetAllEventsData();
            return View(events);
        }

        public IActionResult ViewEventData(int id)
        {
            var instance = repo.GetUsersByEvent(id);
            return View(instance);
        }

        public IActionResult UpdateEventData(int id)
        {
            EventData instance = repo.GetEventData(id);
            if (instance == null)
            {
                return View("EventNotFound");
            }
            return View(instance);
        }

        public IActionResult UpdateEventToDatabase(EventData instance)
        {
            repo.UpdateEventData(instance);

            return RedirectToAction("ViewEventData", new { id = instance.EventID });
        }

        public IActionResult InsertEventData()
        {
            var instance = new EventData();
            return View(instance);
        }

        public IActionResult InsertEventToDatabase(EventData instanceToInsert)
        {
            repo.InsertEventData(instanceToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEventData(EventData instance)
        {
            repo.DeleteEventData(instance);
            return RedirectToAction("Index");
        }

        public IActionResult GetUsersByEvent(int id)
        {
            var rsvps = repo.GetUsersByEvent(id);
            return View(rsvps);
        }

        public IActionResult EventDetails(int id)
        {
            var eventData = repo.GetEventData(id);
            List<User> usersAttending = repo.GetAllUsers(id).ToList();

            var viewModel = new EventDetailsViewModel
            {
                EventData = eventData,
                UsersAttending = usersAttending
            };

            return View("ViewEventData", viewModel);
        }

        public IActionResult GetRSVPCount(int id)
        {
            var rsvps = repo.GetUsersByEvent(id);
            return View(rsvps);
        }
    }
}
        //public IActionResult EventDetails(int eventId)
        //{
        //    var eventData = repo.GetAllEvents().FirstOrDefault(e => e.EventID == eventId);
        //    var usersAttending = repo.GetAllUsers(eventId).Where(u => u.EventID == eventId).ToList();

        //    var viewModel = new EventDetailsViewModel
        //    {
        //        Event = eventData,
        //        UsersAttending = usersAttending
        //    };

        //    return View(viewModel);
        //}
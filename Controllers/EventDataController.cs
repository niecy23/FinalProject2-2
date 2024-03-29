﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            EventData eventData = repo.GetEventData(id);
            if (eventData == null)
            {
                return View("EventNotFound");
            }

            var viewModel = new EventDetailsViewModel
            {
                EventData = eventData
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateEventToDatabase(EventDetailsViewModel viewModel)
        {
            repo.UpdateEventData(viewModel.EventData);
            return RedirectToAction("EventDetails", new { id = viewModel.EventData.EventID });
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

        public IActionResult SortEvents(string column, string sortOrder)
        {
            var allEvents = repo.GetAllEventsData();

            IEnumerable<EventData> sortedEvents;

            switch (column)
            {
                case "EventID":
                    sortedEvents = sortOrder == "asc" ? allEvents.OrderBy(e => e.EventID) : allEvents.OrderByDescending(e => e.EventID);
                    break;


                case "EventName":
                    sortedEvents = sortOrder == "asc" ? allEvents.OrderBy(e => e.EventName) : allEvents.OrderByDescending(e => e.EventName);
                    break;

                case "DateAndTime":
                    sortedEvents = sortOrder == "asc" ? allEvents.OrderBy(e => e.DateAndTime) : allEvents.OrderByDescending(e => e.DateAndTime);
                    break;

                default:
                    sortedEvents = allEvents;
                    break;
            }

            return PartialView("_EventTablePartial", sortedEvents);

        }
    }
}

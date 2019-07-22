using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomManagement1.Models;
using Newtonsoft.Json;

namespace RoomManagement1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CheckDates();
            return View();
        }

        public void CheckDates()
        {
            string path = @"..\SohbiRoomManager\classes.json";
            var jsoncontent = System.IO.File.ReadAllText(path);
            var rooms = JsonConvert.DeserializeObject<Rooms>(jsoncontent);

            foreach(var room in rooms.rooms)
            {
                if(room.Godzina.Date <= DateTime.Now)
                {
                    int idx = rooms.rooms.IndexOf(room);
                    rooms.rooms[idx].Zajete = false;
                    var _jsonoutput = JsonConvert.SerializeObject(rooms, Formatting.Indented);
                    System.IO.File.WriteAllText(path, _jsonoutput);
                }
            }
        }

        public IActionResult All()
        {
            string path = @"..\SohbiRoomManager\classes.json";
            var jsoncontent = System.IO.File.ReadAllText(path);
            var rooms = JsonConvert.DeserializeObject<Rooms>(jsoncontent);
            ViewData["Title"] = "Zobacz";
            return View(rooms);
        }
        public IActionResult Choose()
        {
            return View();
        }
        public IActionResult Rezerwacja()
        {
            string path = @"..\SohbiRoomManager\classes.json";
            var jsoncontent = System.IO.File.ReadAllText(path);
            var rooms = JsonConvert.DeserializeObject<Rooms>(jsoncontent);
            ViewData["rooms"] = rooms;
            var model = new RoomData();
            return View(model);
        }
        [HttpPost]
        public IActionResult Rezerwacja(RoomData helper)
        {
            string path = @"..\SohbiRoomManager\classes.json";
            var jsoncontent = System.IO.File.ReadAllText(path);
            var rooms = JsonConvert.DeserializeObject<Rooms>(jsoncontent);

            if (!ModelState.IsValid)
            {
                return View(helper);
            }
            else
            {
                foreach (var y in rooms.rooms)
                {
                    if (y.Numer == helper.Numer)
                    {
                        y.Godzina = helper.Godzina;
                        y.Zajete = true;
                        var ser = JsonConvert.SerializeObject(rooms, Formatting.Indented);
                        System.IO.File.WriteAllText(path, ser);
                    }
                }
                return Redirect("Home/All");
            }
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


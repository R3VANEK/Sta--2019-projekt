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
            return View();
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
        public IActionResult Rezerwacja(RoomData room)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

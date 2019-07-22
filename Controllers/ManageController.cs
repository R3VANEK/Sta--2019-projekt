using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomManagement1.Models;
using RoomManagement1.Controllers;
using Newtonsoft.Json;


namespace SohbiRoomManager.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult AddRoom()
        {
            var model = new RoomData();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddRoom(RoomData roomData)
        {
            if (!ModelState.IsValid)
            {
                return View(roomData);
            }

            RoomData newRoom = new RoomData()
            {
                Zajete = false,
                Numer = roomData.Numer,
                Opis = $"{roomData.Opis}",
                Godzina = Convert.ToDateTime("01-01-2019 00:00:00"),
            };

            OpenAndWriteToTasks(newRoom);

            return RedirectToAction("AddRoom");
        }

        public IActionResult Delete(int numer)
        {
            string path = @"..\SohbiRoomManager\classes.json";
            var jsoncontent = System.IO.File.ReadAllText(path);
            var rooms = JsonConvert.DeserializeObject<Rooms>(jsoncontent);
            for (int i = 0; i < rooms.rooms.Count; i += 1)
            {
                if (rooms.rooms[i].Numer == numer)
                {
                    rooms.rooms.Remove(rooms.rooms[i]);
                }
            }
            var ser = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            System.IO.File.WriteAllText(path, ser);
            return Redirect("~/Home/All");
        }

        public void OpenAndWriteToTasks(RoomData _newRoom)
        {
            string path = @"..\SohbiRoomManager\classes.json";

            var _jsoncontent = System.IO.File.ReadAllText(path);

            var _jsonlist = JsonConvert.DeserializeObject<Rooms>(_jsoncontent);

            _jsonlist.rooms.Add(_newRoom);

            var _jsonoutput = JsonConvert.SerializeObject(_jsonlist, Formatting.Indented);

            System.IO.File.WriteAllText(path, _jsonoutput);
        }
    }
}
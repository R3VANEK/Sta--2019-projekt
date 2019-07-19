using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement1.Models
{
    public class RoomData
    {
        public int Id { get; set; }
        public int Numer { get; set; }
        public string Opis { get; set; }
        public bool Zajęte { get; set; }
        public string Godzina { get; set; }
    }
}

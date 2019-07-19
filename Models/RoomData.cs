using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement1.Models
{
    public class RoomData
    {
        [Required(ErrorMessage = "Numer sali jest wymagany")]
        [Range(0, int.MaxValue, ErrorMessage = "This value must be a number")]
        public int Numer { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [DataType(DataType.Text)]
        public string Opis { get; set; }
        public bool Zajete { get; set; }
        public string Godzina { get; set; }
    }
}

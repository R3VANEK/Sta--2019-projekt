using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SohbiRoomManager.Models
{
    public class UserData
    {
        [Required(ErrorMessage = "Login jest wymagany")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; }

        public static string Acceptedlogin { get; set; }
    }
}

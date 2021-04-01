using System;
using System.Collections.Generic;

namespace SoftwareII.Models
{
    public class User
    {
        public long Id { get; set; }

        public string DNI { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string LastSurname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string Image { get; set; }


    }
}
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public Permission Permission { get; set; }
        public User()
        {

        }

        public User(int iD, string name, string email, DateTime birthDate, string password, Permission permission)
        {
            ID = iD;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Permission = permission;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Race
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Race()
        {

        }

        public Race(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}

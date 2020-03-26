using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Territory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Territory()
        {

        }

        public Territory(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}

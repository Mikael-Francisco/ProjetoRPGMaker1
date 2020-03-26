using System;

namespace DTO
{
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Class()
        {

        }
        public Class(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}

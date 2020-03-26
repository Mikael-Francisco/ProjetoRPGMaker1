using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TypeItem Type { get; set; }
        public int Effect { get; set; }
        public Item()
        {

        }

        public Item(int iD, string name,TypeItem type,int effect)
        {
            ID = iD;
            Name = name;
            Type = type;
            Effect = effect;
        }
    }
}

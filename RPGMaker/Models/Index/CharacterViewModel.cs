using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGMaker.Models.Index
{
    public class CharacterViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public Class Class { get; set; }
        public Race Race { get; set; }
        public Territory HomeTerritory { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}

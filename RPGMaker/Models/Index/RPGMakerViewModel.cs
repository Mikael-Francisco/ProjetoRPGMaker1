using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGMaker.Models.Index
{
    public class RPGMakerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Class Classes { get; set; }
        public Race Race { get; set; }
        public Item Item { get; set; }
        public Territory Territory { get; set; }
        public Creature Creature { get; set; }
        public Character Character { get; set; }
    }
}

using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGMaker.Models.Inserts
{
    public class RPGInsertViewModel
    {
        public string Name { get; set; }
        public List<Class> Classes { get; set; }
        public List<Race> Race { get; set; }
        public List<Item> Item { get; set; }
        public List<Territory> Territory { get; set; }
        public List<Creature> Creature { get; set; }
        public List<Character> Character { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class RPGCreated
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Class> Classes  { get; set; }
        public ICollection<Race> Race  { get; set; }
        public ICollection<Item> Item  { get; set; }
        public ICollection<Territory> Territory  { get; set; }
        public ICollection<Creature> Creature { get; set; }
        public ICollection<Character> Character { get; set; }

        public RPGCreated()
        {

        }

        public RPGCreated(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}

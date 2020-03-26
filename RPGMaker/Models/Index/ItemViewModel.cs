using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGMaker.Models.Index
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TypeItem Type { get; set; }
        public int Effect { get; set; }
    }
}

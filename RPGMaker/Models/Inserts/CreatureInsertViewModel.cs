using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGMaker.Models.Inserts
{
    public class CreatureInsertViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "O nome deve conter 2 e 50 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A idade deve ser informado")]
        public int Age { get; set; }
        [Required(ErrorMessage = "A altura deve ser informado")]
        public double Height { get; set; }
        public Class Class { get; set; }
        public Race Race { get; set; }
        public Territory HomeTerritory { get; set; }
        public List<Item> Item { get; set; }
        public CreatureType Type { get; set; }
    }
}

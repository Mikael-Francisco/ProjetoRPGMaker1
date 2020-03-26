using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGMaker.Models.Inserts
{
    public class ItemInsertViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "O nome deve conter 2 e 50 caracteres")]
        public string Name { get; set; }
        public TypeItem Type { get; set; }
        public int Effect { get; set; }
    }
}

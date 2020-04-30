using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedPanda.WOL.Core.Model
{
    public class MacAddress
    {
        [Required]
        [StringLength(17)]
        public string Value { get; set; }
    }
}

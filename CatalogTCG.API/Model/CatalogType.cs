using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogTCG.API.Model
{
    public class CatalogType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }
    }
}

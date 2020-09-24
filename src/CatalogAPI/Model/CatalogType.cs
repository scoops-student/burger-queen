using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Model
{
    public class CatalogType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        public ICollection<CatalogItem> catalogitems {get; set;}
    }
}

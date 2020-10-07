using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Model
{
    public class CatalogData
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string[] Catalogitems { get; set; }
    }
}

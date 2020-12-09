namespace CatalogAPI.Domain.Models
{
    public class CatalogData
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string[] Catalogitems { get; set; }
    }
}
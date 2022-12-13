using System.ComponentModel.DataAnnotations;

namespace Favourite.Model
{
    public class FavouriteList
    {
        [Key]
        public string Title { get; set; }
        public string id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

    }
}

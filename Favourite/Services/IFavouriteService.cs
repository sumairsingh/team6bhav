using Favourite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite.Services
{
    public interface IFavouriteService
    {
        FavouriteList Add(FavouriteList fav);
        List<FavouriteList> Get();
        FavouriteList GetFavouriteByTitle(string title);
        bool DeleteFavourite(string title);
    }
}

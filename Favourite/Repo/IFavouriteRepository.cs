using Favourite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite.Repo
{
    public interface IFavouriteRepository
    {
        FavouriteList Add(FavouriteList fav);
        List<FavouriteList> Get();
        FavouriteList GetFavouriteByTitle(string title);
        bool DeleteFavourite(string title);

    }
}

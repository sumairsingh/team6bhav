using Favourite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite.Repo
{
    public class FavouriteRepository: IFavouriteRepository
    {
        private readonly FavouriteMgmtDBContext db;
        public FavouriteRepository(FavouriteMgmtDBContext _db)
        {
            this.db = _db;
        }
      public  FavouriteList Add(FavouriteList fav)
        {
            db.FavouritData.Add(fav);
            db.SaveChanges();
            return fav;

        }
        public List<FavouriteList> Get()
        {
            var favList = db.FavouritData.ToList();
            return favList;
        }
        public FavouriteList GetFavouriteByTitle(string title)
        {
            var favbytitle = db.FavouritData
                .Where(book => book.Title == title)
                .FirstOrDefault<FavouriteList>();
            return favbytitle;
        }
        public bool DeleteFavourite(string title)
        {
            bool _isDeleted = false;
            FavouriteList _b = null;
            _b = GetFavouriteByTitle(title);

            if (_b != null)
            {
                db.FavouritData.Remove(_b);
                db.SaveChanges();
                _isDeleted = true;
            }
            return _isDeleted;
        }
    }


    }


using Favourite.Error;
using Favourite.Model;
using Favourite.Repo;
using System.Collections.Generic;

namespace Favourite.Services
{
    public class FavouriteService : IFavouriteService
    {

        private readonly IFavouriteRepository repo;
        public FavouriteService(IFavouriteRepository _repo)
        {
            this.repo = _repo;
        }

        public FavouriteList Add(FavouriteList fav)
        {
            FavouriteList favIs = new FavouriteList
            {
                Title = fav.Title,
                id = fav.id,
                Url = fav.Url,
                Description = fav.Description
            };
            repo.Add(favIs);
            return favIs;

        }

        public bool DeleteFavourite(string title)
        {
            string FavTitle = title;
            var deleteBook = repo.DeleteFavourite(FavTitle);

            if (deleteBook)
            {
                return deleteBook;
            }
            else
            {
                throw new FavouriteTitleNotFoundException($"Favourite with title:{title} does not exist");
            }
        }

        public List<FavouriteList> Get()
        {
            var favourite = repo.Get();
            return favourite;
        //    throw new NotImplementedException();
        }

        public FavouriteList GetFavouriteByTitle(string title)
        {
            string favTitle = title;
            var favByTitle = repo.GetFavouriteByTitle(favTitle);
            if (favByTitle != null)
            {
                return favByTitle;
            }
            else
            {
                throw new FavouriteTitleNotFoundException($"Favourite with title: {title} does not exists");
            }
          
        }

       

        }
    }

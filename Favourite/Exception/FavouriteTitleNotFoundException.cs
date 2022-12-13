using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite.Error
{
    public class FavouriteTitleNotFoundException: ApplicationException
    {
        public FavouriteTitleNotFoundException() { }
        public FavouriteTitleNotFoundException(string message) : base(message) { }
    }
}

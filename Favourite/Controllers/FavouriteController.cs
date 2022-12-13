using Favourite.Error;
using Favourite.Model;
using Favourite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class FavouriteController : Controller
    {
        //   private FavouriteMgmtDBContext favMgmt;
        private readonly IFavouriteService service;

        public FavouriteController(IFavouriteService _service)
        {
            this.service=_service;
                 

    }

    [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var fav = service.Get();
                return StatusCode(200, fav);
            }
            catch (Exception)
            {
                return StatusCode(500, $"There is some server error");
            }
        }


        [HttpPost]
        public IActionResult  Add([FromBody] FavouriteList fav)
        {
            try
            {
                service.Add(fav);
                return StatusCode(201, "Favourite List Created");
            }
            catch (Exception)
            {
                return StatusCode(500, $"internal server error ");
            }
        }

        [HttpDelete("{title}")]
        public IActionResult DeleteFavourite(string title)
        {
            try
            {
                service.DeleteFavourite(title);
                return StatusCode(200, "Favourite Deleted");
            }
            catch (FavouriteTitleNotFoundException ue)
            {
                return Conflict(ue.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, $"server error");
            }

        }
    }
    }


using Microsoft.AspNetCore.Mvc;
using UpmeetApi.Models;

namespace UpmeetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        // GET: api/<FavoriteController>
        [HttpGet]
        public IEnumerable<Favorite> GetAllFavoritesByUserId(int userId)
        {
            List<Favorite> favoriteCollection = new List<Favorite>();
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                favoriteCollection = context.Favorites.ToList();
            }
            return favoriteCollection;
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public Favorite GetFavoriteById(int id)
        {
            Favorite result = null;
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                result = context.Favorites.Where(x => x.FavoriteId == id).First();
            }
            return result;
        }

        // POST api/<FavoriteController>
        [HttpPost]
        public void AddEventToFavorites(int userId, int eventId)
        {
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                Favorite favorite = new Favorite();
                favorite.UserId = userId;
                favorite.EventId = eventId;
                context.Favorites.Add(favorite);
                context.SaveChanges();
            }
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]
        public void DeleteFavoriteById(int id)
        {
            Favorite result = null;
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                result = context.Favorites.Where(x => x.FavoriteId == id).First();
                context.Favorites.Remove(result);
                context.SaveChanges();
            }
        }
    }
}

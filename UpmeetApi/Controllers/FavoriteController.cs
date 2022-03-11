using Microsoft.AspNetCore.Mvc;
using UpmeetApi.Models;

namespace UpmeetApi.Controllers
{
    public class FavoriteResults
    {
        public IEnumerable<Favorite> results { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        // GET: api/<FavoriteController>
        [HttpGet]
        public FavoriteResults GetAllFavoritesByUserId(int userId)
        {
            List<Favorite> favoriteCollection = new List<Favorite>();
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                favoriteCollection = context.Favorites.ToList();
            }
            FavoriteResults result = new FavoriteResults();
            result.results = favoriteCollection;
            return result;
        }

        // GET: api/<UserController>
        [HttpGet]
        public UserResults GetAllUsers()
        {
            List<User> userCollection = new List<User>();
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                userCollection = context.Users.ToList();
            }
            UserResults result = new UserResults();
            result.results = userCollection;
            return result;
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
